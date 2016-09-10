using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multiple.Tasks.Multiple.Cores
{
    public class Startup
    {
        public const int LogicalCoresCount = 8;

        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            var colors = GetPreferedConsoleColors();
            var tasks = new List<Task>(LogicalCoresCount);

            // Run stress test on multiple threads
            for (int task = 0; task < LogicalCoresCount; task++)
            {
                var taskColor = colors[task];

                tasks.Add(Task.Run(() =>
                {
                    var executionTime = EstimateExecutionTime(StressTest);

                    Console.ForegroundColor = taskColor;
                    Console.WriteLine($"{taskColor} => {executionTime.ToString()}");
                }));
            }

            // Wait for all tasks to finish their job, and then continue with the program execution flow
            Task.WaitAll(tasks.ToArray());
            stopwatch.Stop();

            Console.ResetColor();
            Console.WriteLine($"Total program execution time => {stopwatch.Elapsed.ToString()}");
        }

        public static List<ConsoleColor> GetPreferedConsoleColors()
        {
            return new List<ConsoleColor>()
            {
                ConsoleColor.Yellow,
                ConsoleColor.Green,
                ConsoleColor.Red,
                ConsoleColor.Magenta,
                ConsoleColor.Blue,
                ConsoleColor.White,
                ConsoleColor.DarkMagenta,
                ConsoleColor.DarkCyan
            };
        }

        public static TimeSpan EstimateExecutionTime(Action action)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        public static void StressTest()
        {
            var sum = default(BigInteger);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 1000000; j++)
                {
                    sum += j;
                }
            }
        }
    }
}
