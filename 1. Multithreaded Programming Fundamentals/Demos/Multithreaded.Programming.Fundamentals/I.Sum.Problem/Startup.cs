using System;
using System.Diagnostics;

namespace I.Sum.Problem
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var coresCount = Environment.ProcessorCount;

            // Build array
            var arraySize = 500000;
            var array = GetArray(arraySize);

            // Run N tasks to deal with N problems
            var stopwatch = Stopwatch.StartNew();

            var startIndex = 0;
            var elementsToProcessCount = arraySize;
            var arrayProcessor = new ArrayProcessor(array, startIndex, elementsToProcessCount);
            arrayProcessor.GenerateSum();

            var totalSum = arrayProcessor.GeneratedSum;
            stopwatch.Stop();

            // Sum: 1249975000
            // Time elapsed: 80 ms
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
