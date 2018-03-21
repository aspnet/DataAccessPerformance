// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace BenchmarkDb
{
    public sealed class MySqlAdoDriver : AdoDriver
    {
        public MySqlAdoDriver() : base(MySqlClientFactory.Instance) {}

        public override void Initialize(string connectionString, int threadCount)
        {
            var settings = new MySqlConnectionStringBuilder(connectionString);

            var message = "";
            if (settings.ConnectionIdlePingTime < 300)
                message += "* ConnectionIdlePingTime=300 (or higher)\n";
            if (settings.ConnectionReset)
                message += "* ConnectionReset=false\n";
            if (settings.DefaultCommandTimeout != 0)
                message += "* DefaultCommandTimeout=0\n";
            if (settings.SslMode != MySqlSslMode.None)
                message += "* SslMode=None\n";
            if (message.Length != 0)
                throw new ArgumentException("ado-mysql requires the following connection string settings:\n" + message);

            base.Initialize(connectionString, threadCount);
        }
    }
}
