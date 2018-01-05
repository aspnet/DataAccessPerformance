// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostgreSql;
using PostgreSql.Native;

namespace BenchmarkDb
{
    public sealed class LibPQDriver : DriverBase
    {
        public override Func<string, Task> TryGetVariation(string variationName)
        {
            switch (variationName)
            {
                case Variation.Sync:
                    return DoWorkSync;
                case Variation.SyncCaching:
                    return DoWorkSyncCaching;
                default:
                    return NotSupportedVariation;
            }
        }
        
        public override Task DoWorkSyncCaching(string connectionString)
        {
            const string query = "select id, message from Fortune";

            using (var connectionFactory = new ConnectionFactory(connectionString, 1))
            {
                using (var connection = connectionFactory.Get())
                {
                    while (Program.IsRunning)
                    {
                        var results = new List<Fortune>();

                        connection.Prepare("p0", query);

                        connection.ExecPrepared("p0");

                        if (connection.ExecStatus != ExecStatusType.PGRES_TUPLES_OK)
                        {
                            throw new ApplicationException("Error");
                        }

                        var count = connection.Rows;

                        for (var i = 0; i < count; i++)
                        {
                            var id = connection.Value(i, 0);
                            var message = connection.Value(i, 1);

                            var fortune = new Fortune
                            {
                                Id = int.Parse(id),
                                Message = message
                            };

                            results.Add(fortune);
                        }

                        CheckResults(results);

                        Program.IncrementCounter();
                    }
                }
            }

            return Task.CompletedTask;
        }

        public override Task DoWorkSync(string connectionString)
        {
            const string query = "select id, message from Fortune";

            using (var connectionFactory = new ConnectionFactory(connectionString))
            {
                while (Program.IsRunning)
                {
                    using (var connection = connectionFactory.Get())
                    {
                        var results = new List<Fortune>();

                        connection.Prepare("p0", query);

                        connection.ExecPrepared("p0");

                        if (connection.ExecStatus != ExecStatusType.PGRES_TUPLES_OK)
                        {
                            throw new ApplicationException("Error");
                        }

                        var count = connection.Rows;

                        for (var i = 0; i < count; i++)
                        {
                            var id = connection.Value(i, 0);
                            var message = connection.Value(i, 1);

                            var fortune = new Fortune
                            {
                                Id = int.Parse(id),
                                Message = message
                            };

                            results.Add(fortune);
                        }

                        CheckResults(results);

                        Program.IncrementCounter();
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
