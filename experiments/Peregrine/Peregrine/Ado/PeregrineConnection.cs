// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Peregrine.Ado
{
    public class PeregrineConnection : DbConnection
    {
        private sealed class Pool
        {
            private readonly PGSession[] _sessions;

            public Pool(int maximumRetained)
            {
                _sessions = new PGSession[maximumRetained];
            }

            public PGSession Rent()
            {
                for (var i = 0; i < _sessions.Length; i++)
                {
                    var item = _sessions[i];

                    if (item != null
                        && Interlocked.CompareExchange(ref _sessions[i], null, item) == item)
                    {
                        return item;
                    }
                }

                return null;
            }

            public void Return(PGSession session)
            {
                for (var i = 0; i < _sessions.Length; i++)
                {
                    if (Interlocked.CompareExchange(ref _sessions[i], session, null) == null)
                    {
                        return;
                    }
                }

                session.Dispose();
            }
        }

        private static readonly Pool _pool = new Pool(256);

        private PGSession _session;

        private bool _disposed;

        public override string ConnectionString { get; set; }

        public override ConnectionState State
            => _session?.IsConnected == true
                ? ConnectionState.Open
                : ConnectionState.Closed;

        public override Task OpenAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();

            if (_session != null)
            {
                return Task.CompletedTask;
            }

            _session = _pool.Rent();

            if (_session == null)
            {
                var parts
                    = (from s in ConnectionString.Split(';')
                       let kv = s.Split('=')
                       select kv)
                    .ToDictionary(p => p[0], p => p[1]);

                _session = new PGSession(
                    parts["host"],
                    port: 5432,
                    database: parts["database"],
                    user: parts["username"],
                    password: parts["password"]);
            }

            return _session.IsConnected ? Task.CompletedTask : _session.StartAsync();
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(PeregrineConnection));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_session != null)
            {
                _pool.Return(_session);
            }

            _disposed = true;
        }

        protected override DbCommand CreateDbCommand() => new PeregrineCommand(_session);

        public override void Close() => throw new NotImplementedException();
        public override string Database => throw new NotImplementedException();
        public override string DataSource => throw new NotImplementedException();
        public override string ServerVersion => throw new NotImplementedException();

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
            => throw new NotImplementedException();

        public override void ChangeDatabase(string databaseName)
            => throw new NotImplementedException();

        public override void Open()
            => throw new NotImplementedException();
    }
}
