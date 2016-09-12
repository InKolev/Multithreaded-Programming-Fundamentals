using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awaiting.Tasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            var task = Task.Run(() => RunFiveMillionIterations());

            RunOneMillionIterations();
            RunOneMillionIterations();
            RunOneMillionIterations();
            RunOneMillionIterations();
            RunOneMillionIterations();

            Task.WaitAll(task);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
        }

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

        public static void RunFiveMillionIterations()
        {
            Console.WriteLine("Five million iterations - Started!");

            var sum = 0;
            for (int i = 0; i < 10000000; i++)
            {
                sum += i;
            }

            Console.WriteLine("Five million iterations - Done!");
        }
    }
}
