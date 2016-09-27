using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IV.Race.Condition
{
    public class Startup
    {
        private static volatile int counter = 0;
        private static object counterLock = new object();

        public static void Main(string[] args)
        {
            var t1 = new Thread(() => Run(ConsoleColor.Yellow));
            var t2 = new Thread(() => Run(ConsoleColor.Green));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.ResetColor();
        }

        public static void Run(ConsoleColor foregroundColor)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            while (counter < 10)
            {
                lock (counterLock)
                {
                    if(counter < 10)
                    {
                        counter++;
                        Console.ForegroundColor = foregroundColor;
                        Console.WriteLine($"[Thread:{threadId}] - {counter}");
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }
}
