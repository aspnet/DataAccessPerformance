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
        private PGSession _session;

        public override string ConnectionString { get; set; }

        public override ConnectionState State
            => _session?.IsConnected == true
                ? ConnectionState.Open
                : ConnectionState.Closed;

        public override Task OpenAsync(CancellationToken cancellationToken)
        {
            if (_session == null)
            {
                var connectionInfo
                    = (from s in ConnectionString.Split(';')
                       let kv = s.Split('=')
                       select kv)
                    .ToDictionary(p => p[0], p => p[1]);

                _session
                    = new PGSession(
                        connectionInfo["host"],
                        5432,
                        connectionInfo["database"],
                        connectionInfo["username"],
                        connectionInfo["password"]);

                return _session.StartAsync();
            }

            return Task.CompletedTask;
        }

        public new PeregrineCommand CreateCommand()
        {
            return new PeregrineCommand(_session);
        }

        protected override DbCommand CreateDbCommand()
        {
            return new PeregrineCommand(_session);
        }

        public override void Close()
        {
            _session?.Dispose();
            _session = null;
        }

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
