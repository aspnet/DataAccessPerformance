// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace BenchmarkDb
{
    public static class Variation
    {
        public const string Sync = "sync";
        public const string SyncCaching = "sync-caching";
        public const string Async = "async";
        public const string AsyncCaching = "async-caching";

        public static IEnumerable<string> Names
        {
            get
            {
                yield return Sync;
                yield return SyncCaching;
                yield return Async;
                yield return AsyncCaching;
            }
        }
    }
}
