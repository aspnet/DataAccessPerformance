// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LibPQNet;

namespace BenchmarkDb
{
    public sealed class LibPQDriver : DriverBase
    {
        public override Func<string, Task> TryGetVariation(string variationName)
        {
            switch (variationName)
            {
                case Variation.SyncCaching:
                    return DoWorkSyncCaching;
                default:
                    return NotSupportedVariation;
            }
        }
        
        public override Task DoWorkSyncCaching(string connectionString)
        {
            const string query = "select id, message from Fortune";

            var dbconn = LibPQ.PQconnectdb(connectionString);
            try
            {
                while (Program.IsRunning)
                {
                    var results = new List<Fortune>();
                    
                    var result = LibPQ.PQexec(dbconn, query);

                    var status = LibPQ.PQresultStatus(result);

                    if (status != ExecStatusType.PGRES_TUPLES_OK)
                    {
                        LibPQ.PQclear(result);
                        throw new ApplicationException("Failed to connect");
                    }

                    var count = LibPQ.PQntuples(result);

                    for (uint i = 0; i < count; i++)
                    {
                        var id = Marshal.PtrToStringAnsi(LibPQ.PQgetvalue(result, i, 0));
                        var message = Marshal.PtrToStringUTF8(LibPQ.PQgetvalue(result, i, 1));

                        var fortune = new Fortune
                        {
                            Id = int.Parse(id),
                            Message = message
                        };

                        results.Add(fortune);
                    }

                    LibPQ.PQclear(result);

                    CheckResults(results);

                    Program.IncrementCounter();
                }

            }
            finally
            {
                LibPQ.PQfinish(dbconn);
            }

            return Task.CompletedTask;
        }
    }
}
