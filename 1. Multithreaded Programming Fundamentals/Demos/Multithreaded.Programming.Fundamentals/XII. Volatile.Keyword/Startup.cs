using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XII.Volatile.Keyword
{
    public class Startup
    {
        private bool isRunning = true;
        //private volatile bool isRunning = true;

        public static void Main(string[] args)
        {
            var program = new Startup();

            var thread = new Thread((arg) =>
            {
                var o = arg as Startup;

                Console.WriteLine("Entered 'while' loop");
                while (o.isRunning)
                {
                    // Cycle untill the variable is set to 'false'
                }
                Console.WriteLine("Exited 'while' loop");
            });

            thread.Start(program);

            Thread.Sleep(1000);
            program.isRunning = false;
            Console.WriteLine("Value of 'isRunning' set to false");
        }
    }
}
