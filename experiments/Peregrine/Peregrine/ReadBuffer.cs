// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Peregrine
{
    public class ReadBuffer
    {
        private const int DefaultBufferSize = 8192;

        private readonly AwaitableSocket _awaitableSocket;

        private readonly byte[] _buffer = new byte[DefaultBufferSize];

        private int _position;

        internal ReadBuffer(AwaitableSocket awaitableSocket)
        {
            _awaitableSocket = awaitableSocket;
        }

        public byte ReadByte()
        {
            return _buffer[_position++];
        }

        public byte[] ReadBytes(int length)
        {
            var bs = new byte[length];

            Buffer.BlockCopy(_buffer, _position, bs, 0, length);

            _position += length;

            return bs;
        }

        public short ReadShort()
        {
            var s = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(_buffer, _position));

            _position += sizeof(short);

            return s;
        }

        public ushort ReadUShort()
        {
            var us = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToUInt16(_buffer, _position));

            _position += sizeof(ushort);

            return us;
        }

        public int ReadInt()
        {
            var i = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(_buffer, _position));

            _position += sizeof(int);

            return i;
        }

        public uint ReadUInt()
        {
            var ui = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToUInt32(_buffer, _position));

            _position += sizeof(uint);

            return ui;
        }

        public string ReadNullTerminatedString()
        {
            var start = _position;

            while (_buffer[_position++] != 0
                   && _position < _buffer.Length)
            {
            }

            var s = PG.UTF8.GetString(_buffer, start, _position - start - 1);

            return s;
        }

        public string ReadString(int length)
        {
            var s = PG.UTF8.GetString(_buffer, _position, length);

            _position += length;

            return s;
        }

        public async Task ReceiveAsync()
        {
            _awaitableSocket.SetBuffer(_buffer, 0, _buffer.Length);

            await _awaitableSocket.ReceiveAsync();

            var bytesTransferred = _awaitableSocket.BytesTransferred;

            if (bytesTransferred == 0)
            {
                throw new EndOfStreamException();
            }

            _position = 0;
        }

        public void Receive()
        {
            _awaitableSocket.SetBuffer(_buffer, 0, _buffer.Length);

            var bytesTransferred = _awaitableSocket.Receive();

            if (bytesTransferred == 0)
            {
                throw new EndOfStreamException();
            }

            _position = 0;
        }
    }
}
