using System.Data;
using System.Data.Common;
using Microsoft.Extensions.ObjectPool;

namespace BenchmarkDb.Pooling
{
    public class PoolingDbFactory : DbProviderFactory
    {
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly ObjectPool<DbConnection> _connectionPool;

        public PoolingDbFactory(DbProviderFactory dbProviderFactory)
        {
            _dbProviderFactory = dbProviderFactory;
            _connectionPool = new DefaultObjectPoolProvider().Create(new ConnectionPoolingPolicy(dbProviderFactory));
        }

        public override DbParameter CreateParameter()
        {
            return _dbProviderFactory.CreateParameter();
        }

        public override bool CanCreateDataSourceEnumerator => _dbProviderFactory.CanCreateDataSourceEnumerator;

        public override DbCommandBuilder CreateCommandBuilder()
        {
            return _dbProviderFactory.CreateCommandBuilder();
        }

        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return _dbProviderFactory.CreateConnectionStringBuilder();
        }

        public override DbDataAdapter CreateDataAdapter()
        {
            return _dbProviderFactory.CreateDataAdapter();
        }

        public override DbDataSourceEnumerator CreateDataSourceEnumerator()
        {
            return _dbProviderFactory.CreateDataSourceEnumerator();
        }

        public override DbConnection CreateConnection()
        {
            var connection = _connectionPool.Get();
            var pooledConnection = new PooledConnection(connection, _connectionPool);

            return pooledConnection;
        }

        public override DbCommand CreateCommand()
        {
            return _dbProviderFactory.CreateCommand();
        }
    }
}
