using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Awaiting.Tasks
{
    public class Program
    {
        public static ManualResetEvent resetEvent = new ManualResetEvent(false);

        public static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            var t1 = Task.Run(() => RunHundredMillionIterations());

            ThreadPool.QueueUserWorkItem(x =>
            {
                RunHundredMillionIterations();
                resetEvent.Set();
            });

            // Wait for queued work item
            resetEvent.WaitOne();

            // Wait for task
            Task.WaitAll(t1);

            stopwatch.Stop();
            // around 600 ms
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
        }

        //public static void Main(string[] args)
        //{
        //    var stopwatch = Stopwatch.StartNew();

        //    var t1 = new Thread(RunHundredMillionIterations);
        //    var t2 = new Thread(RunHundredMillionIterations);
        //    var t3 = new Thread(RunHundredMillionIterations);
        //    var t4 = new Thread(RunHundredMillionIterations);
        //    var t5 = new Thread(RunHundredMillionIterations);


        //    t1.Start();
        //    t2.Start();
        //    t3.Start();
        //    t4.Start();
        //    t5.Start();

        //    t1.Join();
        //    t2.Join();
        //    t3.Join();
        //    t4.Join();
        //    t5.Join();

        //    // 1289 ms in total
        //    stopwatch.Stop();
        //    Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
        //}

        public static void RunOneMillionIterations()
        {
            Console.WriteLine("One million iterations - Started!");

            var sum = 0;
            for (int i = 0; i < 1000000; i++)
            {
                sum += i;
            }

            Console.WriteLine("One million iterations - Done!");
        }

        public static void RunHundredMillionIterations()
        {
            Console.WriteLine("Hundred million iterations - Started!");

            var sum = 0;
            for (int i = 0; i < 100000000; i++)
            {
                sum += i;
            }

            Console.WriteLine("Hundred million iterations - Done!");
        }
    }
}
