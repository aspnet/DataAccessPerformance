using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace BenchmarkDb.Pooling
{
    public class PooledConnection : DbConnection, IDisposable
    {
        private readonly DbConnection _dbConnection;
        private readonly ObjectPool<PooledConnection> _objectPool;

        public PooledConnection(DbConnection dbConnection, ObjectPool<PooledConnection> objectPool)
        {
            _dbConnection = dbConnection;
            _objectPool = objectPool;
        }

        public override string ConnectionString
        {
            get => _dbConnection.ConnectionString;

            set
            {
                if (String.IsNullOrEmpty(_dbConnection.ConnectionString))
                {
                    _dbConnection.ConnectionString = value;
                }
            }
        }

        public override string Database => _dbConnection.Database;

        public override string DataSource => _dbConnection.DataSource;

        public override string ServerVersion => _dbConnection.ServerVersion;

        public override ConnectionState State => _dbConnection.State;

        public override void ChangeDatabase(string databaseName)
        {
            _dbConnection.ChangeDatabase(databaseName);
        }

        public override void Close()
        {
            // Don't close the underlying connection
        }

        public override Task OpenAsync(CancellationToken cancellationToken)
        {
            if (State != ConnectionState.Open)
            {
                return _dbConnection.OpenAsync();
            }

            return Task.CompletedTask;
        }

        public override void Open()
        {
            // The underlying connection might already be open
            if (State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
        }
        
        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return _dbConnection.BeginTransaction();
        }

        protected override DbCommand CreateDbCommand()
        {
            return _dbConnection.CreateCommand();
        }

        void IDisposable.Dispose()
        {
            if (!_objectPool.Return(this))
            {
                _dbConnection.Dispose();
            }
        }
    }
}
