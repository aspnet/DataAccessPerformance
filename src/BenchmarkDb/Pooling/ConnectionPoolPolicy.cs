using System.Data.Common;
using Microsoft.Extensions.ObjectPool;

namespace BenchmarkDb.Pooling
{
    public class ConnectionPoolingPolicy : IPooledObjectPolicy<DbConnection>
    {
        private readonly DbProviderFactory _dbProviderFactory;

        public ConnectionPoolingPolicy(DbProviderFactory dbProviderFactory)
        {
            _dbProviderFactory = dbProviderFactory;
        }
        public DbConnection Create()
        {
            return _dbProviderFactory.CreateConnection();
        }

        public bool Return(DbConnection obj)
        {
            return true;
        }
    }
}
