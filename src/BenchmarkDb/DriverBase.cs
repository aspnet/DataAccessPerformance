// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchmarkDb
{
    public abstract class DriverBase
    {
        protected static void CheckResults(ICollection<Fortune> results)
        {
            if (results.Count != 12)
            {
                throw new InvalidOperationException($"Unexpected number of results! Expected 12 got {results.Count}");
            }
        }

        public Func<string, Task> TryGetVariation(string variationName)
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

        public virtual async Task DoWorkSync(string connectionString)
        {
            while (Program.IsRunning)
            {
                await Task.Delay(100);
            }
        }

        public virtual async Task DoWorkSyncCaching(string connectionString)
        {
            while (Program.IsRunning)
            {
                await Task.Delay(100);
            }
        }

        public virtual async Task DoWorkAsync(string connectionString)
        {
            while (Program.IsRunning)
            {
                await Task.Delay(100);
            }
        }

        public virtual async Task DoWorkAsyncCaching(string connectionString)
        {
            while (Program.IsRunning)
            {
                await Task.Delay(100);
            }
        }

        private static Exception VariationNotSupported(string variationName)
            => new NotSupportedException($"Variation {variationName} not supported on driver.");
    }
}
