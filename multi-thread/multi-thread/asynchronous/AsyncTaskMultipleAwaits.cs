using System;
using System.Diagnostics;

namespace multi_thread.asynchronous
{
    public class AsyncTaskMultipleAwaits
    {
        public async Task Execute()
        {
             var sw = new Stopwatch();
            sw.Start();

            await DoTaskWithDelay("f1", 4000);
            await DoTaskWithDelay("f2", 7000);
            await DoTaskWithDelay("f3", 2000);

            sw.Stop();

            var elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine($"elapsed: {elapsed} ms");
        }

        async Task DoTaskWithDelay(string name, int timeout)
        {
            Console.WriteLine("{0} started on {1}", name, DateTime.Now.ToLongTimeString());
            await Task.Delay(timeout);
            Console.WriteLine("{0} finished on {1}", name, DateTime.Now.ToLongTimeString());
        }
    }
}