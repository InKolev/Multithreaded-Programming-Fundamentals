using System;
using System.Threading;

namespace LiveDemos
{
    public class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(DoWork);
            var threadStartOptions = new ThreadStartOptions
            {
                ForegroundColor = ConsoleColor.Magenta,
                Message = "Parameters, parameters, parameters..."
            };
            thread.Start(threadStartOptions);
        }

        static void DoWork(object threadStartOptions)
        {
            var opts = threadStartOptions as ThreadStartOptions;

            Console.ForegroundColor = opts.ForegroundColor;
            Console.WriteLine(opts.Message);
        }
    }

    public class ThreadStartOptions
    {
        public ConsoleColor ForegroundColor { get; set; }
        public string Message { get; set; }
    }
}
