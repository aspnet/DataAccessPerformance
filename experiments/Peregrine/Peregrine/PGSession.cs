// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Peregrine
{
    public class PGSession : IDisposable
    {
        private const int DefaultConnectionTimeout = 2000; // ms

        private readonly string _host;
        private readonly int _port;
        private readonly string _database;
        private readonly string _user;
        private readonly string _password;

        private WriteBuffer _writeBuffer;

        private AwaitableSocket _awaitableSocket;

        private bool _disposed;

        private readonly HashSet<string> _prepared = new HashSet<string>();

        public PGSession(
            string host,
            int port,
            string database,
            string user,
            string password)
        {
            _host = host;
            _port = port;
            _database = database;
            _user = user;
            _password = password;
        }

        public bool IsConnected
        {
            get
            {
                ThrowIfDisposed();

                return _awaitableSocket?.IsConnected == true;
            }
        }

        public Task PrepareAsync(string statementName, string query)
        {
            ThrowIfDisposed();
            ThrowIfNotConnected();

            return _prepared.Contains(statementName)
                ? Task.CompletedTask
                : PrepareSlow(statementName, query);
        }

        private async Task PrepareSlow(string statementName, string query)
        {
            await _writeBuffer
                .StartMessage('P')
                .WriteString(statementName)
                .WriteString(query)
                .WriteShort(0)
                .EndMessage()
                .StartMessage('S')
                .EndMessage()
                .FlushAsync();

            await ReadBuffer.ReceiveAsync();

            var message = ReadBuffer.ReadMessage();

            switch (message)
            {
                case MessageType.ParseComplete:
                    _prepared.Add(statementName);
                    break;

                case MessageType.ErrorResponse:
                    throw new InvalidOperationException(ReadBuffer.ReadErrorMessage());

                default:
                    throw new NotImplementedException(message.ToString());
            }
        }

        public AwaitableSocket ExecuteAsync(string statementName)
        {
            ThrowIfDisposed();
            ThrowIfNotConnected();

            WriteExecStart(statementName, parameterCount: 0);

            return WriteExecFinish();
        }

        internal ReadBuffer ReadBuffer { get; private set; }

        public Task ExecuteAsync<TResult>(
            string statementName,
            Func<TResult> resultFactory,
            Action<TResult, ReadBuffer, int, int> columnBinder,
            int parameterValue)
        {
            ThrowIfDisposed();
            ThrowIfNotConnected();

            WriteExecStart(statementName, parameterCount: 1);

            _writeBuffer
                .WriteInt(4)
                .WriteInt(parameterValue);

            return WriteExecFinishAndProcess<object, TResult>(null, _ => resultFactory(), columnBinder);
        }

        public Task ExecuteAsync<TState, TResult>(
            string statementName,
            TState initialState,
            Func<TState, TResult> resultFactory,
            Action<TResult, ReadBuffer, int, int> columnBinder)
        {
            ThrowIfDisposed();
            ThrowIfNotConnected();

            WriteExecStart(statementName, parameterCount: 0);

            return WriteExecFinishAndProcess(initialState, resultFactory, columnBinder);
        }

        private void WriteExecStart(string statementName, short parameterCount)
            => _writeBuffer
                .StartMessage('B')
                .WriteNull()
                .WriteString(statementName)
                .WriteShort(1)
                .WriteShort(1)
                .WriteShort(parameterCount);

        private AwaitableSocket WriteExecFinish()
            => _writeBuffer
                .WriteShort(1)
                .WriteShort(1)
                .EndMessage()
                .StartMessage('E')
                .WriteNull()
                .WriteInt(0)
                .EndMessage()
                .StartMessage('S')
                .EndMessage()
                .FlushAsync();

        private async Task WriteExecFinishAndProcess<TState, TResult>(
            TState initialState,
            Func<TState, TResult> resultFactory,
            Action<TResult, ReadBuffer, int, int> columnBinder)
        {
            await WriteExecFinish();
            await ReadBuffer.ReceiveAsync();

            read:

            var message = ReadBuffer.ReadMessage();

            switch (message)
            {
                case MessageType.BindComplete:
                    goto read;

                case MessageType.DataRow:
                {
                    var result
                        = resultFactory != null
                            ? resultFactory(initialState)
                            : default;

                    var columns = ReadBuffer.ReadShort();

                    for (var i = 0; i < columns; i++)
                    {
                        var length = ReadBuffer.ReadInt();

                        columnBinder(result, ReadBuffer, i, length);
                    }

                    goto read;
                }

                case MessageType.CommandComplete:
                    return;

                case MessageType.ErrorResponse:
                    throw new InvalidOperationException(ReadBuffer.ReadErrorMessage());

                default:
                    throw new NotImplementedException(message.ToString());
            }
        }

        public Task StartAsync(int millisecondsTimeout = DefaultConnectionTimeout)
        {
            ThrowIfDisposed();

            return IsConnected
                ? Task.CompletedTask
                : StartSessionAsync(millisecondsTimeout);
        }

        private async Task StartSessionAsync(int millisecondsTimeout)
        {
            await OpenSocketAsync(millisecondsTimeout);

            _writeBuffer = new WriteBuffer(_awaitableSocket);
            ReadBuffer = new ReadBuffer(_awaitableSocket);

            await WriteStartupAsync();

            await ReadBuffer.ReceiveAsync();

            read:

            var message = ReadBuffer.ReadMessage();

            switch (message)
            {
                case MessageType.AuthenticationRequest:
                {
                    var authenticationRequestType
                        = (AuthenticationRequestType)ReadBuffer.ReadInt();

                    switch (authenticationRequestType)
                    {
                        case AuthenticationRequestType.AuthenticationOk:
                        {
                            return;
                        }

                        case AuthenticationRequestType.AuthenticationMD5Password:
                        {
                            var salt = ReadBuffer.ReadBytes(4);
                            var hash = Hashing.CreateMD5(_password, _user, salt);

                            await _writeBuffer
                                .StartMessage('p')
                                .WriteBytes(hash)
                                .EndMessage()
                                .FlushAsync();

                            await ReadBuffer.ReceiveAsync();

                            goto read;
                        }

                        default:
                            throw new NotImplementedException(authenticationRequestType.ToString());
                    }
                }

                case MessageType.ErrorResponse:
                    throw new InvalidOperationException(ReadBuffer.ReadErrorMessage());

                case MessageType.BackendKeyData:
                case MessageType.EmptyQueryResponse:
                case MessageType.ParameterStatus:
                case MessageType.ReadyForQuery:
                    throw new NotImplementedException($"Unhandled MessageType '{message}'");

                default:
                    throw new InvalidOperationException($"Unexpected MessageType '{message}'");
            }
        }

        private async Task OpenSocketAsync(int millisecondsTimeout)
        {
            var socket
                = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    NoDelay = true
                };

            _awaitableSocket
                = new AwaitableSocket(
                    new SocketAsyncEventArgs
                    {
                        RemoteEndPoint = new IPEndPoint(IPAddress.Parse(_host), _port)
                    },
                    socket);

            using (var cts = new CancellationTokenSource())
            {
                cts.CancelAfter(millisecondsTimeout);

                await _awaitableSocket.ConnectAsync(cts.Token);
            }
        }

        private AwaitableSocket WriteStartupAsync()
        {
            const int protocolVersion3 = 3 << 16;

            var parameters = new(string Name, string Value)[]
            {
                ("user", _user),
                ("client_encoding", "UTF8"),
                ("database", _database)
            };

            _writeBuffer
                .StartMessage()
                .WriteInt(protocolVersion3);

            for (var i = 0; i < parameters.Length; i++)
            {
                var p = parameters[i];

                _writeBuffer
                    .WriteString(p.Name)
                    .WriteString(p.Value);
            }

            return _writeBuffer
                .WriteNull()
                .EndMessage()
                .FlushAsync();
        }

        public void Terminate()
        {
            ThrowIfDisposed();

            if (IsConnected)
            {
                try
                {
                    _writeBuffer
                        .StartMessage('X')
                        .EndMessage()
                        .FlushAsync()
                        .GetAwaiter()
                        .GetResult();
                }
                catch (SocketException)
                {
                    // Socket may have closed
                }
            }

            _awaitableSocket?.Dispose();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Terminate();

                _disposed = true;
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(PGSession));
            }
        }

        private void ThrowIfNotConnected()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
