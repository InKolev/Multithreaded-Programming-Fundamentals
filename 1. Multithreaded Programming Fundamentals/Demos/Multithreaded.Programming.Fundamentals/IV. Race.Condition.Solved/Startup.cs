using System;
using System.Threading;

namespace IV.Race.Condition.Solved
{
    public class Startup
    {
        private static volatile int counter = 0;
        private static object counterLock = new object();

        public static void Main(string[] args)
        {
            // Run the operation 10 times
            // To get more clear results
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(new string('*', 60));
                StartCounterConcurrently();
                counter = 0;
            }
        }

        public static void StartCounterConcurrently()
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
                Thread.Sleep(100);

                lock (counterLock)
                {
                    if (counter < 10)
                    {
                        counter++;
                        Console.ForegroundColor = foregroundColor;
                        Console.WriteLine($"[Thread:{threadId}] - {counter}");
                    }
                }
            }
        }
    }
}
