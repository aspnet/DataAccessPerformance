// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchmarkDb
{
    public abstract class DriverBase
    {
        public static class Variation
        {
            public const string Sync = "sync";
            public const string SyncCaching = "sync-caching";
            public const string Async = "async";
            public const string AsyncCaching = "async-caching";
        }

        public static IEnumerable<string> VariationNames
        {
            get
            {
                yield return Variation.Sync;
                yield return Variation.SyncCaching;
                yield return Variation.Async;
                yield return Variation.AsyncCaching;
            }
        }

        public abstract Func<string, Task> TryGetVariation(string variationName);

        protected static void CheckResults(ICollection<Fortune> results)
        {
            if (results.Count != 12)
            {
                throw new InvalidOperationException($"Unexpected number of results! Expected 12 got {results.Count}");
            }
        }
    }
}
