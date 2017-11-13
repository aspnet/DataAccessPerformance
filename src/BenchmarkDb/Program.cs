// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Npgsql;

namespace BenchmarkDb
{
    public static class Program
    {
        private const int DefaultThreadCount = 16;
        private const int DefaultExecutionTimeSeconds = 10;
        private const int WarmupTimeSeconds = 3;

        private const string TestQuery = "SELECT id, message FROM fortune";

        private static int _counter;
        private static int _stopping;

        private static readonly IDictionary<string, DbProviderFactory> _drivers
            = new Dictionary<string, DbProviderFactory>
            {
                { "ado-npgsql", NpgsqlFactory.Instance },
                { "ado-mysql", MySqlClientFactory.Instance },
                { "ado-sqlclient", SqlClientFactory.Instance }
            };

        private static readonly IDictionary<string, Func<DbProviderFactory, string, Task>> _variations
            = new Dictionary<string, Func<DbProviderFactory, string, Task>>
            {
                { "sync", DoWorkSync },
                { "sync-caching", DoWorkSyncCaching },
                { "async", DoWorkAsync },
                { "async-caching", DoWorkAsyncCaching }
            };

        public static async Task<int> Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("WARNING! Using DEBUG build.");
#endif
            int Help((string option, string value) invalid = default)
            {
                Console.WriteLine("Usage: <driver> <connection-string> [threads] [variation] [time]");
                Console.WriteLine();
                Console.WriteLine("Arguments:");
                Console.WriteLine($"  <driver>            The target database driver ({string.Join(", ", _drivers.Keys.Select(k => $"'{k}'"))}).");
                Console.WriteLine("  <connection-string> The target database connection string.");
                Console.WriteLine($"  <variation>:        The specific variation to run ({string.Join(", ", _variations.Keys.Select(k => $"'{k}'"))}).");
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine("  [threads]:   The number of threads to spawn (default 16).");
                Console.WriteLine("  [time]:      The number of seconds to run for (default 10).");
                Console.WriteLine();

                if (invalid.option != null)
                {
                    Console.WriteLine($"  '{invalid.value}' is not a valid value for parameter '{invalid.option}'!");
                    Console.WriteLine();
                }

                return 1;
            }

            if (args.Length < 3)
            {
                return Help();
            }

            var driverName = args[0];

            if (!_drivers.TryGetValue(driverName, out var driver))
            {
                return Help(("driver", driverName));
            }

            var connectionString = args[1];

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return Help(("connection-string", connectionString));
            }

            var variationName = args[2];

            if (!_variations.TryGetValue(variationName, out var variation))
            {
                return Help(("variation", variationName));
            }

            var threadCount = DefaultThreadCount;
            var time = DefaultExecutionTimeSeconds;

            if (args.Length > 3
                && !int.TryParse(args[3], out threadCount))
            {
                return Help(("threads", args[3]));
            }

            if (args.Length > 4
                && !int.TryParse(args[4], out time))
            {
                return Help(("time", args[4]));
            }

            DateTime startTime = default, stopTime = default;

            var totalTransactions = 0;
            var results = new List<double>();

            IEnumerable<Task> CreateTasks()
            {
                yield return Task.Run(
                    async () =>
                        {
                            Console.Write($"Warming up for {WarmupTimeSeconds}s...");

                            await Task.Delay(TimeSpan.FromSeconds(WarmupTimeSeconds));

                            Console.SetCursorPosition(0, Console.CursorTop);

                            Interlocked.Exchange(ref _counter, 0);

                            startTime = DateTime.UtcNow;
                            var lastDisplay = startTime;

                            while (_stopping != 1)
                            {
                                await Task.Delay(200);

                                var now = DateTime.UtcNow;
                                var tps = (int)(_counter / (now - lastDisplay).TotalSeconds);
                                var remaining = (int)(time - (now - startTime).TotalSeconds);

                                results.Add(tps);

                                Console.Write($"{tps} tps, {remaining}s                     ");
                                Console.SetCursorPosition(0, Console.CursorTop);

                                lastDisplay = now;
                                totalTransactions += Interlocked.Exchange(ref _counter, 0);
                            }
                        });

                yield return Task.Run(
                    async () =>
                        {
                            await Task.Delay(TimeSpan.FromSeconds(WarmupTimeSeconds + time));

                            Interlocked.Exchange(ref _stopping, 1);

                            stopTime = DateTime.UtcNow;
                        });

                foreach (var task in Enumerable.Range(0, threadCount)
                    .Select(
                        _ => Task.Factory
                            .StartNew(() => variation(driver, connectionString), TaskCreationOptions.LongRunning)
                            .Unwrap()))
                {
                    yield return task;
                }
            }

            await Task.WhenAll(CreateTasks());

            var totalTps = (int)(totalTransactions / (stopTime - startTime).TotalSeconds);

            results.Sort();
            results.RemoveAt(0);
            results.RemoveAt(results.Count - 1);

            double CalculateStdDev(ICollection<double> values)
            {
                var avg = values.Average();
                var sum = values.Sum(d => Math.Pow(d - avg, 2));

                return Math.Sqrt(sum / values.Count);
            }

            var stdDev = CalculateStdDev(results);

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine($"{threadCount:D2} Threads, tps: {totalTps:F2}, stddev(w/o best+worst): {stdDev:F2}");

            var desc = $"{driver}+{variationName}+{threadCount}";

            using (var sw = File.AppendText("results.md"))
            {
                sw.WriteLine($"|{desc}|{variationName}|{threadCount:D2}|{totalTps:F0}|{stdDev:F0}|");
            }

            using (var sw = File.AppendText("results.csv"))
            {
                sw.WriteLine($"{desc},{variationName},{threadCount:D2},{totalTps:F0},{stdDev:F0}");
            }

            return 0;
        }

        private static Task DoWorkSync(DbProviderFactory providerFactory, string connectionString)
        {
            while (_stopping != 1)
            {
                Interlocked.Increment(ref _counter);

                var results = new List<Fortune>();

                using (var connection = providerFactory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = TestQuery;
                        command.Prepare();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(
                                    new Fortune
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
                    throw new InvalidOperationException("Unexpected number of results!");
                }
            }

            return Task.CompletedTask;
        }

        private static Task DoWorkSyncCaching(DbProviderFactory providerFactory, string connectionString)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    command.CommandText = TestQuery;
                    command.Prepare();

                    while (_stopping != 1)
                    {
                        Interlocked.Increment(ref _counter);

                        var results = new List<Fortune>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(
                                    new Fortune
                                    {
                                        Id = reader.GetInt32(0),
                                        Message = reader.GetString(1)
                                    });
                            }
                        }

                        if (results.Count != 12)
                        {
                            throw new InvalidOperationException("Unexpected number of results!");
                        }
                    }
                }
            }

            return Task.CompletedTask;
        }

        private static async Task DoWorkAsync(DbProviderFactory providerFactory, string connectionString)
        {
            while (_stopping != 1)
            {
                Interlocked.Increment(ref _counter);

                var results = new List<Fortune>();

                using (var connection = providerFactory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;

                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = TestQuery;
                        command.Prepare();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                results.Add(
                                    new Fortune
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
                    throw new InvalidOperationException("Unexpected number of results!");
                }
            }
        }

        private static async Task DoWorkAsyncCaching(DbProviderFactory providerFactory, string connectionString)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    connection.ConnectionString = connectionString;

                    await connection.OpenAsync();

                    command.CommandText = TestQuery;
                    command.Prepare();

                    while (_stopping != 1)
                    {
                        Interlocked.Increment(ref _counter);

                        var results = new List<Fortune>();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                results.Add(
                                    new Fortune
                                    {
                                        Id = reader.GetInt32(0),
                                        Message = reader.GetString(1)
                                    });
                            }
                        }

                        if (results.Count != 12)
                        {
                            throw new InvalidOperationException("Unexpected number of results!");
                        }
                    }
                }
            }
        }
    }
}
