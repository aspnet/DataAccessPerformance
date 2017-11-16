// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchmarkDb
{
    public abstract class DriverBase
    {
        public static Func<string, Task> NotSupportedVariation = _ => null;

        protected static void CheckResults(ICollection<Fortune> results)
        {
            if (results.Count != 12)
            {
                throw new InvalidOperationException($"Unexpected number of results! Expected 12 got {results.Count}");
            }
        }

        public virtual Func<string, Task> TryGetVariation(string variationName)
        {
            switch (variationName)
            {
                case Variation.Sync:
                    return DoWorkSync;
                case Variation.SyncCaching:
                    return DoWorkSyncCaching;
                case Variation.Async:
                    return DoWorkAsync;
                case Variation.AsyncCaching:
                    return DoWorkAsyncCaching;
            }

            return default;
        }

        public virtual Task DoWorkSync(string connectionString)
        {
            throw VariationNotSupported(Variation.Sync);
        }

        public virtual Task DoWorkSyncCaching(string connectionString)
        {
            throw VariationNotSupported(Variation.SyncCaching);
        }

        public virtual Task DoWorkAsync(string connectionString)
        {
            throw VariationNotSupported(Variation.Async);
        }

        public virtual Task DoWorkAsyncCaching(string connectionString)
        {
            throw VariationNotSupported(Variation.AsyncCaching);
        }

        private static Exception VariationNotSupported(string variationName)
            => new NotSupportedException($"Variation {variationName} not supported on driver.");
    }
}
