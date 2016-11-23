using System;
using System.Threading;

namespace V.Creating.Threads
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var banana = @"
                                 _
                                //\
                                V  \
                                 \  \_
                                  \,'.`-.
                                   |\ `. `.       
                                   ( \  `. `-.                        _,.-:\
                                    \ \   `.  `-._             __..--' ,-';/
                                     \ `.   `-.   `-..___..---'   _.--' ,'/
                                      `. `.    `-._        __..--'    ,' /
                                        `. `-_     ``--..''       _.-' ,'
                                          `-_ `-.___        __,--'   ,'
                                             `-.__  `----'''    __.- '
                                                  `--..____..--'";


            var thread = new Thread((opts) =>
            {
                var threadStartOptions = opts as ThreadStartOptions;
                if (threadStartOptions.IsNull())
                {
                    throw new ArgumentException("I require a valid ThreadStartOptions in order to execute propeeeeeeerly");
                }

                // First infinite loop
                while (true)
                {
                    Thread.Sleep(threadStartOptions.SleepTime);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(threadStartOptions.Message);
                }
            });

            //thread.Start();
            thread.Start(new ThreadStartOptions { Message = banana, SleepTime = 1000 });

            // Second infinite loop
            while (true)
            {
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Main thread working");
            }
        }
    }

    public class ThreadStartOptions
    {
        public string Message { get; set; }

        public int SleepTime { get; set; }
    }

    public static class ObjectExtensions
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
    }
}
