namespace I.Sum.Problem
{
    public class Range<T>
    {
        public Range(T lowerBound, T upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        public T LowerBound { get; set; }

        public T UpperBound { get; set; }
    }
}