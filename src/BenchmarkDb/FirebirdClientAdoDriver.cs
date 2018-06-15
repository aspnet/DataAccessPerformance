// Author: Jiri Cincura (jiri@cincura.net)

using System;
using System.Data.Common;
using FirebirdSql.Data.FirebirdClient;

namespace BenchmarkDb
{
	public sealed class FirebirdClientAdoDriver : AdoDriver
	{
		public FirebirdClientAdoDriver()
			: base(FirebirdClientFactory.Instance)
		{ }

		public override void Initialize(string connectionString, int _)
		{
			var settings = new FbConnectionStringBuilder(connectionString);

			if (settings.Enlist)
				throw new ArgumentException($"Enlist=false must be specified for {nameof(FirebirdSql.Data.FirebirdClient)}.");

			base.Initialize(connectionString, _);
		}
	}
}
