using Benchmarking;
using System;

namespace Test25
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ARRAY_SIZE = 1000;
            int[] Source = new int[ARRAY_SIZE];
            int[] Destination = new int[ARRAY_SIZE + 10];

            const uint NoOfIteration = 1_000_000;

            Profiler.Profile("Use Loop", NoOfIteration, () =>
            {
                for (int i = 0; i < ARRAY_SIZE; i++)
                {
                    Destination[i] = Source[i];
                }
            });

            Profiler.Profile("Use Array Copy", NoOfIteration, () =>
            {
                Array.Copy(Source, Destination, ARRAY_SIZE);
            });

            Profiler.Profile("Use Buffer.BlockCopy", NoOfIteration, () =>
            {
                Buffer.BlockCopy(Source, 0, Destination, 0, ARRAY_SIZE);
            });
        }
    }
}