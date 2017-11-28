// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Peregrine.Ado;
using Xunit;

namespace Peregrine.Tests
{
    public class AdoTests
    {
        private const string ConnectionString
            = "host=127.0.0.1;database=aspnet5-Benchmarks;username=postgres;password=Password1";

        [Fact]
        public async Task Open_success()
        {
            using (var connection = new PeregrineConnection { ConnectionString = ConnectionString })
            {
                Assert.NotEqual(ConnectionState.Open, connection.State);

                await connection.OpenAsync();

                Assert.Equal(ConnectionState.Open, connection.State);
            }
        }

        [Fact]
        public async Task Execute_query_no_parameters_success()
        {
            using (var connection = new PeregrineConnection { ConnectionString = ConnectionString })
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id, message from fortune";

                    await command.PrepareAsync();

                    var fortunes = new List<Fortune>();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            fortunes.Add(
                                new Fortune
                                {
                                    Id = reader.GetInt32(0),
                                    Message = reader.GetString(1)
                                });
                        }
                    }

                    Assert.Equal(12, fortunes.Count);
                }
            }
        }

        public class Fortune
        {
            public int Id { get; set; }
            public string Message { get; set; }
        }

        public class World
        {
            public int Id { get; set; }
            public int RandomNumber { get; set; }
        }
    }
}
