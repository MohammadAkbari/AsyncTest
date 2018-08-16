using System;
using System.Threading;

namespace ThreadPoolSample
{
    class ThreadPoolSample
    {
        static void Main(string[] args)
        {
            int minimumWorkerThreadCount, minimumIOCThreadCount, maximumWorkerThreadCount, maximumIOCThreadCount;
            int logicalProcessorCount = Environment.ProcessorCount;
            ThreadPool.GetMinThreads(out minimumWorkerThreadCount, out minimumIOCThreadCount);
            ThreadPool.GetMaxThreads(out maximumWorkerThreadCount, out maximumIOCThreadCount);

            Console.WriteLine("No.of processors: " + logicalProcessorCount);
            Console.WriteLine("Minimum no.of Worker threads: " + minimumWorkerThreadCount);
            Console.WriteLine("Minimum no.of IOCP threads: " + minimumIOCThreadCount);
            Console.WriteLine("Maximum no.of Worker threads: " + maximumWorkerThreadCount);
            Console.WriteLine("Maximum number of IOCP threads: " + maximumIOCThreadCount);
            Console.Read();

            Console.ReadKey();
        }
    }
}
