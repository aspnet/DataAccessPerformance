// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Data.Common;
using Npgsql;

namespace BenchmarkDb
{
    public sealed class NpgsqlAdoDriver : AdoDriver
    {
        public NpgsqlAdoDriver() : base(NpgsqlFactory.Instance) {}

        public override void Initialize(string connectionString, int _)
        {
            var settings = new NpgsqlConnectionStringBuilder(connectionString);

            if (!settings.NoResetOnClose)
                throw new ArgumentException("No Reset On Close=true must be specified for Npgsql");
            if (settings.Enlist)
                throw new ArgumentException("Enlist=false must be specified for Npgsql");

            _connectionString = connectionString;
        }
    }
}
