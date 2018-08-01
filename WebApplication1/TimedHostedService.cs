using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1
{
    internal class TimedHostedService : IHostedService, IDisposable
    {
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Log();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void Log()
        {
            const string logPath = @"C:\Temp\threadlog.txt";

            ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out int availableAsyncIOThreads);

            if (availableWorkerThreads < 3)
            {
                string text = $"Worker: {availableWorkerThreads}, IO: {availableAsyncIOThreads}, time: {DateTime.Now}";

                System.IO.File.AppendAllLines(logPath, new string[] { text });
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
