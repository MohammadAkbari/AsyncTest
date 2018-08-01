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
            _connectionString = "Data Source=.;Initial Catalog=BlogDb;User ID=BlogDbUser;Password=BlogDbUser;TrustServerCertificate=True;MultipleActiveResultSets=true";
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

            return Ok(GetThreadInfo());
        }

        [HttpGet("parallel")]
        public async Task<IActionResult> ParallelGet()
        {
            var task1 = MethodAsync();
            var task2 = MethodAsync();

            await task1;
            await task2;

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

        private dynamic GetThreadInfo()
        {
            ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out int availableAsyncIOThreads);
            return new { AvailableAsyncIOThreads = availableAsyncIOThreads, AvailableWorkerThreads = availableWorkerThreads };
        }
    }
}
