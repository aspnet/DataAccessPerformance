using System.Data.Common;

namespace BenchmarkDb.Pooling
{
    public class PoolingDbFactory : DbProviderFactory
    {
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly ObjectPool<PooledConnection> _connectionPool;

        public PoolingDbFactory(DbProviderFactory dbProviderFactory, int pool)
        {
            _dbProviderFactory = dbProviderFactory;
            _connectionPool = new ObjectPool<PooledConnection>(pool, () => CreatePooledConnection(dbProviderFactory.CreateConnection()));
        }

        private PooledConnection CreatePooledConnection(DbConnection connection)
        {
            return new PooledConnection(connection, _connectionPool);
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
            return _connectionPool.Get();
        }

        public override DbCommand CreateCommand()
        {
            return _dbProviderFactory.CreateCommand();
        }
    }
}
