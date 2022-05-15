using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace multi_thread.asynchronous
{
    public class SyncTask
    {
        public void Execute()
        {
            var sw = new Stopwatch();
            sw.Start();

            f1();
            f2();
            f3();

            sw.Stop();

            var elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine($"elapsed: {elapsed} ms");
        }

        void f1() 
        {
            Console.WriteLine("f1 called on {0}", DateTime.Now.ToLongTimeString());
            Thread.Sleep(4000);
        }

        void f2() 
        {
            Console.WriteLine("f2 called on {0}", DateTime.Now.ToLongTimeString());
            Thread.Sleep(7000);
        }

        void f3() 
        {
            Console.WriteLine("f3 called on {0}", DateTime.Now.ToLongTimeString());
            Thread.Sleep(2000);
        }
    }
}