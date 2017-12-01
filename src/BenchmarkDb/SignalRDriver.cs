using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BenchmarkDb
{
    class SignalRDriver : DriverBase
    {
        private string _connectionString;
        private List<ConnectionData> _connections;
        private Stopwatch _watch = new Stopwatch();

        public override void Initialize(string connectionString, int threadCount)
        {
            _connectionString = connectionString;
            threadCount = 20;
            _connections = new List<ConnectionData>(threadCount);
            for (var i = 0; i < threadCount; ++i)
            {
                var hubConnection = new HubConnectionBuilder().WithUrl(connectionString).WithTransport(Microsoft.AspNetCore.Sockets.TransportType.WebSockets).Build();
                var results = new List<long>(20000);

                hubConnection.On<long>("Echo", timestamp => { results.Add(Stopwatch.GetTimestamp() - timestamp); });
                _connections.Add(new ConnectionData {Connection = hubConnection, Latency = results });
            }
        }

        public override async Task DoWorkAsync()
        {
            foreach (var connectionData in _connections)
            {
                await connectionData.Connection.StartAsync();
            }

            var results = new List<long>(20000);

            _watch.Start();
            while (Program.IsRunning)
            {
                var time = Stopwatch.GetTimestamp();
                results.Add(time);
                await _connections[0].Connection.SendAsync("Echo", time);
                Program.IncrementCounter();
            }
            _watch.Stop();

            var lat = new List<float>();

            foreach (var connectionData in _connections)
            {
                await connectionData.Connection.DisposeAsync();
                long total = 0;
                for (var i = 0; i < connectionData.Latency.Count; ++i)
                {
                    total += connectionData.Latency[i];
                }
                lat.Add((total / (float)connectionData.Latency.Count) / Stopwatch.Frequency * 1000);
                Console.WriteLine("mean latency: {0}ms", (total / (float)connectionData.Latency.Count) / Stopwatch.Frequency * 1000);
            }

            float meanLatency = 0;
            foreach (var la in lat)
            {
                meanLatency += la;
            }
            meanLatency /= lat.Count;

            using (var sw = File.AppendText("signalrresults.csv"))
            {
                sw.WriteLine($"signalr,signalr,{_connections.Count:D2},{meanLatency:F0},{CalculateStdDev(lat):F0}");
            }

            double CalculateStdDev(List<float> values)
            {
                var avg = values.Average();
                var sum = values.Sum(d => Math.Pow(d - avg, 2));

                return Math.Sqrt(sum / values.Count);
            }
        }

        private struct ConnectionData
        {
            public HubConnection Connection;
            public List<long> Latency;
        }
    }
}
