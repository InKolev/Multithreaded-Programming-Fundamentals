using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace I.Sum.Problem
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var processorsCount = Environment.ProcessorCount;
            var tasks = new List<Task>(processorsCount);
            var ranges = GetRanges(Environment.ProcessorCount);

            // Run N tasks to deal with N problems
            var stopwatch = Stopwatch.StartNew();
            var sum = new BigInteger();

            for (int i = 0; i < processorsCount; i++)
            {
                var rangeIndex = i;

                tasks.Add(
                    Task.Run(
                        () =>
                            SumNumbersInRange(ranges[rangeIndex].LowerBound, ranges[rangeIndex].UpperBound))
                        .ContinueWith((result) => sum += result.Result));
            }

            //for (int i = 0, iteratorAmount = 15000; i < processorsCount / 2; i++)
            //{
            //    var rangeIndex = i;

            //    tasks.Add(
            //        Task.Run(
            //            () => SumNumbersInRange(ranges[rangeIndex].LowerBound, ranges[rangeIndex].LowerBound + iteratorAmount))
            //            .ContinueWith((result) =>
            //            {
            //                sum += result.Result;
            //            }));

            //    tasks.Add(
            //        Task.Run(
            //            () => SumNumbersInRange(ranges[rangeIndex].LowerBound + iteratorAmount, ranges[rangeIndex].UpperBound))
            //            .ContinueWith((result) =>
            //            {
            //                sum += result.Result;
            //            }));
            //}

            // Wait for the tasks to finish
            Task.WaitAll(tasks.ToArray());
            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds}");
            Console.WriteLine($"Sum: {sum}");
        }

        // 28799880000 8 Threads    Elapsed time: 15.3304
        // 28799880000 16 Threads   Elapsed time: 26.0391

        public static BigInteger SumNumbersInRange(long lowerBound, long upperBound)
        {
            Console.WriteLine($"{lowerBound} - {upperBound}");

            var sum = new BigInteger();

            for (long i = lowerBound; i < upperBound; i++)
            {
                sum += i;
            }

            return sum;
        }

        public static IList<Range<long>> GetRanges(int count)
        {
            const long iteratorAmount = 30000;

            var ranges = new List<Range<long>>();
            for (long i = 0; i < count * iteratorAmount; i += iteratorAmount)
            {
                ranges.Add(new Range<long>(i, i + iteratorAmount));
            }

            return ranges;
        }
    }
}
