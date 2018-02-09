// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data.Common;

namespace BenchmarkDb
{
    public sealed class SqliteAdoDriver : AdoDriver
    {
        public SqliteAdoDriver(DbProviderFactory providerFactory)
            : base(providerFactory)
        {
        }
    }
}
