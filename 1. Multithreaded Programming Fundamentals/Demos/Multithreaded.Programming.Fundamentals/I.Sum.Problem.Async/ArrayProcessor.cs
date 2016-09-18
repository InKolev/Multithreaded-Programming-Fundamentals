using System;
using System.Linq;
using System.Numerics;

namespace I.Sum.Problem.Async
{
    public class ArrayProcessor
    {
        private int[] array;
        private int startIndex;
        private int elementsToProcessCount;

        public ArrayProcessor(int[] array, int startIndex, int elementsToProcessCount)
        {
            this.array = array;
            this.startIndex = startIndex;
            this.elementsToProcessCount = elementsToProcessCount;
        }

        public BigInteger GeneratedSum { get; set; } = 0;

        public void GenerateSum()
        {
            var lastIndex = this.startIndex + this.elementsToProcessCount;

            for (int i = this.startIndex; i < lastIndex; i++)
            {
                this.GeneratedSum += this.array[i];
            }
        }
    }
}