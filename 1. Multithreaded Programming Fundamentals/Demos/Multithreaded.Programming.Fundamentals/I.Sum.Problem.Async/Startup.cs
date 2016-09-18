using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading;

namespace I.Sum.Problem.Async
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var coresCount = Environment.ProcessorCount;
            var threads = new List<Thread>(coresCount);
            var arrayProcessors = new List<ArrayProcessor>(coresCount);

            // Build array
            var arraySize = 500000;
            var array = GetArray(arraySize);

            // Run N tasks to deal with N problems
            var stopwatch = Stopwatch.StartNew();
            var elementsPerCore = arraySize / coresCount;
            var elementsLeftOver = arraySize % coresCount;

            for (int i = 0; i < coresCount; i++)
            {
                var startIndex = i * elementsPerCore;
                var elementsToProcessCount = elementsPerCore;

                if (i == coresCount - 1)
                {
                    elementsToProcessCount += elementsLeftOver;
                }

                var arrayProcessor = new ArrayProcessor(array, startIndex, elementsToProcessCount);
                arrayProcessors.Add(arrayProcessor);

                var thread = new Thread(arrayProcessor.GenerateSum);
                threads.Add(thread);

                thread.Start();
            }

            // Wait for the tasks to finish and calculate final sum
            BigInteger totalSum = 0;
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Join();
                totalSum += arrayProcessors[i].GeneratedSum;
            }

            stopwatch.Stop();

            // Sum: 1249975000
            // Time elapsed: 30 ms
            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds}");
            Console.WriteLine($"Sum: {totalSum}");
        }

        public static int[] GetArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}

