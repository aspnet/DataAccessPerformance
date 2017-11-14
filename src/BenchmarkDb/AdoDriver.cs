// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace BenchmarkDb
{
    public sealed class AdoDriver : DriverBase
    {
        private readonly DbProviderFactory _providerFactory;

        public AdoDriver(DbProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;
        }

        public override Func<string, Task> TryGetVariation(string variationName)
        {
            switch (variationName)
            {
                case Variation.Sync:
                    return s => DoWorkSync(_providerFactory, s);
                case Variation.SyncCaching:
                    return s => DoWorkSyncCaching(_providerFactory, s);
                case Variation.Async:
                    return s => DoWorkAsync(_providerFactory, s);
                case Variation.AsyncCaching:
                    return s => DoWorkAsyncCaching(_providerFactory, s);
            }

            return default;
        }

        public static Task DoWorkSync(DbProviderFactory providerFactory, string connectionString)
        {
            while (Program.IsRunning)
            {
                var results = new List<Fortune>();

                using (var connection = providerFactory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = Program.TestQuery;
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

                CheckResults(results);

                Program.IncrementCounter();
            }

            return Task.CompletedTask;
        }

        public static Task DoWorkSyncCaching(DbProviderFactory providerFactory, string connectionString)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    command.CommandText = Program.TestQuery;
                    command.Prepare();

                    while (Program.IsRunning)
                    {
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

                        CheckResults(results);

                        Program.IncrementCounter();
                    }
                }
            }

            return Task.CompletedTask;
        }

        public static async Task DoWorkAsync(DbProviderFactory providerFactory, string connectionString)
        {
            while (Program.IsRunning)
            {
                var results = new List<Fortune>();

                using (var connection = providerFactory.CreateConnection())
                {
                    connection.ConnectionString = connectionString;

                    await connection.OpenAsync();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = Program.TestQuery;
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

                CheckResults(results);

                Program.IncrementCounter();
            }
        }

        public static async Task DoWorkAsyncCaching(DbProviderFactory providerFactory, string connectionString)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    connection.ConnectionString = connectionString;

                    await connection.OpenAsync();

                    command.CommandText = Program.TestQuery;
                    command.Prepare();

                    while (Program.IsRunning)
                    {
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

                        CheckResults(results);

                        Program.IncrementCounter();
                    }
                }
            }
        }
    }
}
