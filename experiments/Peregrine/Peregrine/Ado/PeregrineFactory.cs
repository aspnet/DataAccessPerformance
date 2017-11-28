// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data.Common;

namespace Peregrine.Ado
{
    public class PeregrineFactory : DbProviderFactory
    {
        public static readonly PeregrineFactory Instance = new PeregrineFactory();

        private PeregrineFactory()
        {
        }

        public override DbConnection CreateConnection()
        {
            return new PeregrineConnection();
        }
    }
}
