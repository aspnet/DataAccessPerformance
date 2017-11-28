// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace BenchmarkDb
{
    public class AdoDriver : DriverBase
    {
        protected readonly DbProviderFactory _providerFactory;
        protected string _connectionString;

        public AdoDriver(DbProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;
        }

        public override void Initialize(string connectionString, int _)
        {
            _connectionString = connectionString;
        }

        public override Task DoWorkSync()
        {
            while (Program.IsRunning)
            {
                var results = new List<Fortune>();

                using (var connection = _providerFactory.CreateConnection())
                {
                    connection.ConnectionString = _connectionString;
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

        public override Task DoWorkSyncCaching()
        {
            using (var connection = _providerFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();

                using (var command = connection.CreateCommand())
                {
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

        public override async Task DoWorkAsync()
        {
            while (Program.IsRunning)
            {
                var results = new List<Fortune>();

                using (var connection = _providerFactory.CreateConnection())
                {
                    connection.ConnectionString = _connectionString;

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

        public override async Task DoWorkAsyncCaching()
        {
            using (var connection = _providerFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
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
