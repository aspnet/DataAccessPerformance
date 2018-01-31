// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Peregrine.Ado;

namespace BenchmarkDb
{
    public sealed class PeregrineAdoDriver : AdoDriver
    {
        public PeregrineAdoDriver(DbProviderFactory providerFactory)
            : base(providerFactory)
        {
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

                    using (var command = (PeregrineCommand)connection.CreateCommand())
                    {
                        command.CommandText = Program.TestQuery;

                        await command.PrepareAsync();

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

                using (var command = (PeregrineCommand)connection.CreateCommand())
                {
                    command.CommandText = Program.TestQuery;

                    await command.PrepareAsync();

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
