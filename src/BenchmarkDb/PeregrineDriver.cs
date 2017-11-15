// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using Peregrine;

namespace BenchmarkDb
{
    public sealed class PeregrineDriver : DriverBase
    {
        public override async Task DoWorkAsync(string connectionString)
        {
            var npgsqConnectionStringBuilder
                = new NpgsqlConnectionStringBuilder(connectionString);

            while (Program.IsRunning)
            {
                var results = new List<Fortune>();

                Fortune CreateFortune()
                {
                    var fortune = new Fortune();

                    results.Add(fortune);

                    return fortune;
                }

                void BindColumn(Fortune fortune, ReadBuffer readBuffer, int index, int length)
                {
                    switch (index)
                    {
                        case 0:
                            fortune.Id = readBuffer.ReadInt();
                            break;
                        case 1:
                            fortune.Message = readBuffer.ReadString(length);
                            break;
                    }
                }

                using (var session = new PGSession(
                    npgsqConnectionStringBuilder.Host,
                    npgsqConnectionStringBuilder.Port,
                    npgsqConnectionStringBuilder.Database,
                    npgsqConnectionStringBuilder.Username,
                    npgsqConnectionStringBuilder.Password))
                {
                    await session.StartAsync();
                    await session.PrepareAsync("_p0", "select id, message from fortune");
                    await session.ExecuteAsync("_p0", CreateFortune, BindColumn);
                }

                CheckResults(results);

                Program.IncrementCounter();
            }
        }

        public override async Task DoWorkAsyncCaching(string connectionString)
        {
            var npgsqConnectionStringBuilder
                = new NpgsqlConnectionStringBuilder(connectionString);

            using (var session = new PGSession(
                npgsqConnectionStringBuilder.Host,
                npgsqConnectionStringBuilder.Port,
                npgsqConnectionStringBuilder.Database,
                npgsqConnectionStringBuilder.Username,
                npgsqConnectionStringBuilder.Password))
            {
                await session.StartAsync();
                await session.PrepareAsync("_p0", "select id, message from fortune");

                while (Program.IsRunning)
                {
                    var results = new List<Fortune>();

                    Fortune CreateFortune()
                    {
                        var fortune = new Fortune();

                        results.Add(fortune);

                        return fortune;
                    }

                    void BindColumn(Fortune fortune, ReadBuffer readBuffer, int index, int length)
                    {
                        switch (index)
                        {
                            case 0:
                                fortune.Id = readBuffer.ReadInt();
                                break;
                            case 1:
                                fortune.Message = readBuffer.ReadString(length);
                                break;
                        }
                    }

                    await session.ExecuteAsync("_p0", CreateFortune, BindColumn);

                    CheckResults(results);

                    Program.IncrementCounter();
                }
            }
        }
    }
}
