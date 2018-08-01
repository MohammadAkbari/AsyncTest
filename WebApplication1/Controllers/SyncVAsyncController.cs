using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/syncvasync")]
    public class SyncVAsyncController : Controller
    {
        private readonly string _connectionString;
        public SyncVAsyncController()
        {
            _connectionString = "Data Source=.;Initial Catalog=BlogDb;Integrated Security=true;";
        }

        [HttpGet("sync")]
        public IActionResult SyncGet()
        {
            Method();
            Method();

            return Ok(GetThreadInfo());
        }

        [HttpGet("async")]
        public async Task<IActionResult> AsyncGet()
        {
            await MethodAsync();
            await MethodAsync();

            await Log();

            return Ok(GetThreadInfo());
        }

        [HttpGet("parallel")]
        public async Task<IActionResult> ParallelGet()
        {
            var task1 = MethodAsync();
            var task2 = MethodAsync();

            await task1;
            await task2;

            await Log();

            return Ok(GetThreadInfo());
        }

        private void Method()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute("WAITFOR DELAY '00:00:02';");
            }
        }

        private async Task MethodAsync()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync("WAITFOR DELAY '00:00:02';");
            }
        }

        private async Task Log()
        {
            //const string logPath = @"C:\Temp\threadlog.txt";

            //ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out int availableAsyncIOThreads);

            //string text = $"Worker: {availableWorkerThreads}, IO: {availableAsyncIOThreads}, time: {DateTime.Now}";

            //await System.IO.File.AppendAllLinesAsync(logPath, new string[] { text });

            await Task.FromResult(0);
        }

        private dynamic GetThreadInfo()
        {
            ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out int availableAsyncIOThreads);
            return new { AvailableAsyncIOThreads = availableAsyncIOThreads, AvailableWorkerThreads = availableWorkerThreads };
        }
    }
}
