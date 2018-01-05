using System;
using PostgreSql;
using PostgreSql.Native;

namespace ConsoleApplication1
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class Class1
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // https://github.com/brianc/node-libpq - native wrapper around libpq for nodejs
            // https://github.com/brianc/node-pg-native - user friendly api around node-libpq


            var connectionString = "Server=172.16.228.78;Database=hello_world;User Id=benchmarkdbuser;Password=benchmarkdbpass;Maximum Pool Size=200;NoResetOnClose=true";
            // "postgresql://benchmarkdbuser@asp-perf-db/hello_world?password=benchmarkdbpass"

            var factory = new ConnectionFactory(connectionString);
            var connection = factory.Get();

            if (connection == null)
            {
                Console.WriteLine("Failed to connect");
            }
            else
            {
                using (connection)
                {
                    Console.WriteLine("Successful connection");

                    // Simple query
                    //var query = "select id, message from Fortune";
                    //connection.Exec(query);

                    // Parameterized query string
                    //var queryParams = "select id, message from Fortune where id = 2 or message = $1";
                    //connection.ExecParams(queryParams, new string[] { "fortune: No such file or directory" });

                    // Parameterized query int
                    //var queryParams = "select id, message from Fortune where id = 2 or id = $1";
                    //connection.ExecParams(queryParams, new string[] { "1" });

                    // Prepared query
                    var queryParams = "select id, message from fortune where id = $1 or id = 1";
                    connection.Prepare("p0", queryParams, 1);
                    EnsureStatus(ExecStatusType.PGRES_COMMAND_OK);

                    connection.ExecPrepared("p0", new string[] { "2" });

                    EnsureStatus(ExecStatusType.PGRES_TUPLES_OK);

                    var count = connection.Rows;
                    Console.WriteLine($"{count} results");

                    var fields = connection.Fields;
                    Console.WriteLine($"{fields} column(s)");

                    for (int i = 0; i < count; i++)
                    {
                        var id = connection.Value(i, 0);
                        var message = connection.Value(i, 1);

                        Console.WriteLine($"{id} {message}");
                    }
                }
            }

            void EnsureStatus(ExecStatusType expected)
            {
                var status = connection.ExecStatus;

                if (status != expected)
                {
                    throw new Exception(connection.ErrorMessage);
                }
            }
        }
    }
}