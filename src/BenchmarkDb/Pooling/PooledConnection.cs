using System.Data;
using System.Data.Common;
using Microsoft.Extensions.ObjectPool;

namespace BenchmarkDb.Pooling
{
    public class PooledConnection : DbConnection
    {
        private readonly DbConnection _dbConnection;
        private readonly ObjectPool<DbConnection> _objectPool;
        private readonly PoolingDbFactory _poolingDbFactory;

        public PooledConnection(DbConnection dbConnection, ObjectPool<DbConnection> objectPool)
        {
            _dbConnection = dbConnection;
            _objectPool = objectPool;
        }

        ~PooledConnection()
        {
            _dbConnection.Dispose();
        }

        public override string ConnectionString { get => _dbConnection.ConnectionString; set => _dbConnection.ConnectionString = value; }

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
            _objectPool.Return(_dbConnection);
        }

        public override void Open()
        {
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
    }
}
