using System;
using System.Threading;

namespace IV.Race.Condition
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
                Console.WriteLine(new string('*',60));
                StartCounterConcurrently();
                counter = 0;
            }
        }

        public static void StartCounterConcurrently()
        {
            var t1 = new Thread(()=> Run(ConsoleColor.Green));
            var t2 = new Thread(()=> Run(ConsoleColor.Red));

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

                // Variable assign is not propaah
                // In order to avoid the race condition
                // Execute this code in a thread-safe manner
                counter++;
                Console.ForegroundColor = foregroundColor;
                Console.WriteLine($"[Thread:{threadId}] - {counter}");
            }
        }
    }
}
