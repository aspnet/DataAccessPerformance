using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Npgsql;

namespace BenchmarkDb
{
    public class Program
    {
        static volatile int _counter = 0;
        static volatile int _stopping = 0;

        const int Warmup = 3;
        const string SqlQuery = "SELECT id,message FROM fortune";
        const string PostgreSql = nameof(PostgreSql);
        const string MySql = nameof(MySql);
        const string SqlServer = nameof(SqlServer);

        static object synlock = new object();

        public static async Task Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("usage: database connectionstring threads mode time(s) desc");
                Environment.Exit(1);
            }

            var database = args[0];
            var connectionString = args[1];

            if (!int.TryParse(args[2], out int numThreads))
            {
                Console.WriteLine($"Invalid threads value: {args[2]}");
                Environment.Exit(1);
            }

            string mode = args[3];

            if (mode != "async" && mode != "sync")
            {
                Console.WriteLine("Accepted mode values: sync, async, sync+conn, async+conn");
                Environment.Exit(1);
            }

            if (!int.TryParse(args[4], out int time))
            {
                Console.WriteLine($"Invalid time value: {args[4]}");
                Environment.Exit(1);
            }

            DbProviderFactory factory = null;

            switch (database)
            {
                case PostgreSql:
                    factory = NpgsqlFactory.Instance;
                    break;

                case MySql:
                    factory = MySqlClientFactory.Instance;
                    break;

                case SqlServer:
                    factory = SqlClientFactory.Instance;
                    break;

                default:
                    Console.WriteLine($"Accepted database values: {SqlServer}, {MySql}, {PostgreSql}");
                    Environment.Exit(2);
                    break;
            }

            var stopwatch = new Stopwatch();
            var startTime = DateTime.UtcNow;
            var stopTime = DateTime.UtcNow;
            var lastDisplay = DateTime.UtcNow;
            var totalTransactions = 0;
            var listOfResults = new List<double>();

            List<Task> tasks = null;
            switch (mode)
            {
                case "sync":
                    tasks = Enumerable.Range(1, numThreads).Select(_ => Task.Factory.StartNew(DoWorkSync, TaskCreationOptions.LongRunning)).ToList();
                    break;

                case "async":
                    tasks = Enumerable.Range(1, numThreads).Select(_ => Task.Factory.StartNew(DoWorkAsync, TaskCreationOptions.LongRunning).Unwrap()).ToList();
                    break;

                case "sync+conn":
                    tasks = Enumerable.Range(1, numThreads).Select(_ => Task.Factory.StartNew(DoWorkSyncReuseConnection, TaskCreationOptions.LongRunning)).ToList();
                    break;

                case "async+conn":
                    tasks = Enumerable.Range(1, numThreads).Select(_ => Task.Factory.StartNew(DoWorkAsyncReuseConnection, TaskCreationOptions.LongRunning).Unwrap()).ToList();
                    break;
            }

            // Displays and records the current status of the test
            tasks.Add(
                Task.Run(async () =>
                {
                    // Warmup
                    Console.Write($"Warming up... {Warmup}s");
                    await Task.Delay(TimeSpan.FromSeconds(Warmup));
                    Console.SetCursorPosition(0, Console.CursorTop);

                    startTime = DateTime.UtcNow;
                    Interlocked.Exchange(ref _counter, 0);

                    while (_stopping != 1)
                    {
                        await Task.Delay(200);
                        var now = DateTime.UtcNow;
                        var tps = (int) (_counter / (now - lastDisplay).TotalSeconds);
                        var remaining = (int) (time - (now - startTime).TotalSeconds);
                        listOfResults.Add(tps);

                        Console.Write($"{tps} tps, {remaining}s                     ");
                        Console.SetCursorPosition(0, Console.CursorTop);
                        lastDisplay = now;
                        totalTransactions += Interlocked.Exchange(ref _counter, 0);
                    }
                })
            );

            // Signals the beginning and the end of the test
            tasks.Add(
                Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(time + Warmup));

                    Interlocked.Exchange(ref _stopping, 1);
                    stopTime = DateTime.UtcNow;
                })
            );

            await Task.WhenAll(tasks);

            var totalTps = (int) (totalTransactions / (stopTime - startTime).TotalSeconds);


            listOfResults.Remove(listOfResults.Max());
            listOfResults.Remove(listOfResults.Min());
            var stddev = CalculateStdDev(listOfResults, listOfResults.Count);

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine($"{numThreads:D2} Threads, tps: {totalTps:F2}, stddev(w/o best+worst): {stddev:F2}");

            var desc = $"{database}+{mode}+{numThreads}";

            using (var sw = File.AppendText("results.md"))
            {
                sw.WriteLine($"|{desc}|{mode}|{numThreads:D2}|{totalTps:F0}|{stddev:F0}|");
            }

            using (var sw = File.AppendText("results.csv"))
            {
                sw.WriteLine($"{desc},{mode},{numThreads:D2},{totalTps:F0},{stddev:F0}");
            }

            double CalculateStdDev(IEnumerable<double> values, int count)
            {
                var avg = values.Sum() / count;
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                return Math.Sqrt((sum) / count);
            }

            async Task DoWorkAsync()
            {
                while (_stopping != 1)
                {
                    Interlocked.Increment(ref _counter);

                    try
                    {
                        var results = new List<Fortune>();
                        using (var connection = factory.CreateConnection())
                        {
                            connection.ConnectionString = connectionString;
                            await connection.OpenAsync();

                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = SqlQuery;
                                command.Prepare();

                                using (var reader = await command.ExecuteReaderAsync())
                                {
                                    while (await reader.ReadAsync())
                                    {
                                        results.Add(new Fortune
                                        {
                                            Id = reader.GetInt32(0),
                                            Message = reader.GetString(1)
                                        });
                                    }
                                }
                            }
                        }

                        if (results.Count != 12)
                        {
                            throw new InvalidDataException("Not 12");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            async Task DoWorkAsyncReuseConnection()
            {
                using (var connection = factory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;
                    await connection.OpenAsync();

                    while (_stopping != 1)
                    {
                        Interlocked.Increment(ref _counter);

                        try
                        {
                            var results = new List<Fortune>();
                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = SqlQuery;
                                command.Prepare();

                                using (var reader = await command.ExecuteReaderAsync())
                                {
                                    while (await reader.ReadAsync())
                                    {
                                        results.Add(new Fortune
                                        {
                                            Id = reader.GetInt32(0),
                                            Message = reader.GetString(1)
                                        });
                                    }
                                }
                            }

                            if (results.Count != 12)
                            {
                                throw new InvalidDataException("Not 12");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }

            void DoWorkSync()
            {
                while (_stopping != 1)
                {
                    Interlocked.Increment(ref _counter);

                    try
                    {
                        var results = new List<Fortune>();
                        using (var connection = factory.CreateConnection())
                        {
                            connection.ConnectionString = connectionString;
                            connection.Open();
                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = SqlQuery;
                                command.Prepare();
                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        results.Add(new Fortune
                                        {
                                            Id = reader.GetInt32(0),
                                            Message = reader.GetString(1)
                                        });
                                    }
                                }
                            }
                        }

                        if (results.Count != 12)
                        {
                            throw new InvalidDataException("Not 12");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            void DoWorkSyncReuseConnection()
            {
                using (var connection = factory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    while (_stopping != 1)
                    {
                        Interlocked.Increment(ref _counter);

                        try
                        {
                            var results = new List<Fortune>();

                            using (var command = connection.CreateCommand())
                            {
                                command.CommandText = SqlQuery;
                                command.Prepare();
                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        results.Add(new Fortune
                                        {
                                            Id = reader.GetInt32(0),
                                            Message = reader.GetString(1)
                                        });
                                    }
                                }
                            }

                            if (results.Count != 12)
                            {
                                throw new InvalidDataException("Not 12");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
        }        
    }
}
