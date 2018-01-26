// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Peregrine.Ado
{
    public class PeregrineCommand : DbCommand
    {
        private readonly PGSession _session;
        private readonly PeregrineDataReader _reader;
        private readonly ReadBuffer _readBuffer;

        public PeregrineCommand(PGSession session)
        {
            _session = session;
            _readBuffer = session.ReadBuffer;
            _reader = new PeregrineDataReader(session.ReadBuffer);
        }

        public Task PrepareAsync() => _session.PrepareAsync("p", CommandText);

        protected override async Task<DbDataReader> ExecuteDbDataReaderAsync(
            CommandBehavior behavior, CancellationToken cancellationToken)
        {
            await _session.ExecuteAsync("p");
            await _readBuffer.ReceiveAsync();

            var message = _readBuffer.ReadMessage();

            switch (message)
            {
                case MessageType.BindComplete:
                    return _reader;

                case MessageType.ErrorResponse:
                    throw new InvalidOperationException(_readBuffer.ReadErrorMessage());

                default:
                    throw new NotImplementedException(message.ToString());
            }
        }
        
        public override int ExecuteNonQuery()
            => throw new NotImplementedException();

        public override void Cancel()
            => throw new NotImplementedException();

        public override object ExecuteScalar()
            => throw new NotImplementedException();

        public override void Prepare()
            => throw new NotImplementedException();

        public override string CommandText { get; set; }

        public override int CommandTimeout
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override CommandType CommandType
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        protected override DbConnection DbConnection
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        protected override DbParameterCollection DbParameterCollection
            => throw new NotImplementedException();

        protected override DbTransaction DbTransaction
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override bool DesignTimeVisible
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        protected override DbParameter CreateDbParameter()
            => throw new NotImplementedException();

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
            => throw new NotImplementedException();
    }
}
