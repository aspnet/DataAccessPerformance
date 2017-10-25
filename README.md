# .NET Data Access Performance
The purpose of this repository is to host benchmarks and prototypes, as well as serve as the main forum for an open initiative to greatly improve the performance of storing and retrieving data using popular database systems through common .NET data access APIs.

## Background

While we have achieved great performance gains in other areas, .NET still lags behind other platforms in data access benchmarks.

As an example, the [TechEmpower Fortunes benchmark](https://www.techempower.com/benchmarks/) shows similar numbers across raw ADO.NET, Dapper and EF Core variations: throughput flatlines or even decreases as concurrent requests increase, which seems to indicate that bottlenecks are preventing efficient hardware utilization.

The performance of accessing databases using .NET should be much more competitive, and we (several people from Microsoft and the .NET developer community) are going to do something about it.

## Goals

- __Improve our understanding__ of how the performance of data access in .NET is affected by several factors (sensitivity analysis), in order to gain the  ability to answer questions like these:
   - What prevents .NET from scaling in the TechEmpower Fortunes benchmark as the number of concurrent requests increases?
   - Why are EF Core results comparatively worse on a "cloud setup" but almost the same as raw data access on a "physical setup"?
   - What can cause the significant differences we observe between different ADO.NET providers (e.g. SqlClient, Npgsql, MySqlConnect)?
   - How does our performance on Linux compare to Windows?
   - How async compares to sync for different number of concurrent requests?
   - How does our scalability improve when adding processors?


- __Identify and remove bottlenecks__ so that .NET can be much more competitive on data access performance

- __Identify additional common scenarios__ that our own benchmarks or TechEmpower could track

- Come up with __novel ways to increase performance__ as well as learn about  __clever things other platforms are doing__ to be more efficient in common scenarios

## Notes on methodology

Here are some general ideas we have discussed:

- __Everything is on the table right now:__

  - Although ideally we will find ways to speed up existing APIs (and hence existing application code that consumes those APIs) without changing their contracts, we will not stop there. E.g. if we find any API pattern in ADO.NET which fundamentally prevents writing code that reaches optimal performance, we will try to come up with better patterns.
  - We will be taking a deeper look at the networking code in database drivers: Although purely managed code solutions have several advantages, we will try with (and learn from) whatever makes things faster, including native APIs.
  - We must assume that we don't know much about what makes a data access APIs really fast (otherwise we wouldn't need to do this work, right?). For this reason we need to keep an open mind when looking at alternative lines of investigation, regardless of whether they have or not been tried before.


- __Performance baselines:__ for each type of database we will test, we'll need to identify an API or tool which we can rely on to produce performance results that we can assume equivalent to the theoretical optimal performance. E.g. for PostgreSQL we are using [pgbench](https://www.postgresql.org/docs/devel/static/pgbench.html). We will execute this on any machine/database setup we use, to find a baseline we can compare all other results of the same setup against.   

- __Strive for easily reproducible tests:__ Anyone should be able to clone and run our tests with minimal effort on their own machine setup. We have had good results using Docker for this, as the overhead seems to be usually low and the results still representative.
