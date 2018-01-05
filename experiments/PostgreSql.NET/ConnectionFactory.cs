using System;
using System.Threading;
using static PostgreSql.Native.Libpq;

namespace PostgreSql
{
    /// <summary>
    /// A <see cref="Database"/> instance represents a PostgreSql server configuration.
    /// It is thread-safe and should be shared across the application for a single connection string.
    public class Database : IDisposable
    {
        /// TODO: A timer could clean the pool after some time when connections are not used

        public static int DefaultPoolSize = 100;

        private readonly Connection[] _connections;
        private readonly string _connectionString;

        public Database(string connectionString) : this(connectionString, DefaultPoolSize)
        {
        }

        public Database(string connectionString, int poolSize)
        {
            // Use the connection string as is if it is in a supported libpq format
            if (connectionString.StartsWith("postgresql://"))
            {
                _connectionString = connectionString;
            }
            else
            {
                // Try to extract the parameters from an ADO.NET connection string
                _connectionString = "";

                var segments = connectionString.Split(";");
                foreach (var segment in segments)
                {
                    var values = segment.Split("=");

                    switch (values[0].ToLowerInvariant())
                    {
                        case "server":
                            _connectionString += "host=" + values[1] + " ";
                            break;
                        case "database":
                            _connectionString += "dbname=" + values[1] + " ";
                            break;
                        case "user id":
                            _connectionString += "user=" + values[1] + " ";
                            break;
                        case "password":
                            _connectionString += "password=" + values[1] + " ";
                            break;
                    }
                }
            }

            _connections = new Connection[poolSize];
        }

        public string ConnectionString => _connectionString;

        public void Dispose()
        {
            foreach (var connection in _connections)
            {
                if (connection != null)
                {
                    connection.Dispose(false);
                    GC.SuppressFinalize(connection);
                }
            }
        }

        /// <summary>
        /// Creates an actual connection to the database.
        /// </summary>
        /// <returns>A <see cref="Connection"/> instance or <c>null</c> if the connection failed.</returns>
        public Connection Connect()
        {
            for (var i = 0; i < _connections.Length; i++)
            {
                var item = _connections[i];
                if (item != null && Interlocked.CompareExchange(ref _connections[i], null, item) == item)
                {
                    return item;
                }
            }

            return CreateConnection();
        }

        private Connection CreateConnection()
        {
            // Perf: parse the connection string and call PQsetdbLogin which should be faster
            var pgConn = PQconnectdb(_connectionString);

            if (pgConn == null)
            {
                return null;
            }

            var connection = new Connection(pgConn, this);

            return connection;
        }

        internal bool Return(Connection connection)
        {
            for (var i = 0; i < _connections.Length; i++)
            {
                if (Interlocked.CompareExchange(ref _connections[i], connection, null) == null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
