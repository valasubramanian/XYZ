using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace multi_thread.asynchronous
{
    public class AsyncTaskWaitAll
    {
        public async Task Execute()
        {
            var sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("started all tasks");
            Task.WaitAll(f1(), f2(), f3());
            Console.WriteLine("finished all tasks");
            
            sw.Stop();

            var elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine($"elapsed: {elapsed} ms");
        }


        async Task f1()
        {
            Console.WriteLine("f1 started on {0}", DateTime.Now.ToLongTimeString());
            await Task.Delay(4000);
            Console.WriteLine("f1 finished on {0}", DateTime.Now.ToLongTimeString());
        }

        async Task f2()
        {
            Console.WriteLine("f2 started on {0}", DateTime.Now.ToLongTimeString());
            await Task.Delay(7000);
            Console.WriteLine("f2 finished on {0}", DateTime.Now.ToLongTimeString());
        }

        async Task f3()
        {
            Console.WriteLine("f3 started on {0}", DateTime.Now.ToLongTimeString());
            await Task.Delay(2000);
            Console.WriteLine("f3 finished on {0}", DateTime.Now.ToLongTimeString());
        }
    }







}