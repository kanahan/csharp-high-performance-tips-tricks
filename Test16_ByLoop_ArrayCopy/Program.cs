using System;
using Benchmarking;

namespace Test16_ByLoop_ArrayCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] source = new int[1000];

            for (int i = 0; i < source.Length; i++)
            {
                source[i] = i;
            }

            int[] target = new int[2000];

            const uint NoOfIteration = 1_000_000;

            Profiler.Profile("By Loop", NoOfIteration, () =>
            {
                for (int i = 0; i < source.Length; i++)
                {
                    target[i] = source[i];
                }
            });

            Profiler.Profile("Array.Copy", NoOfIteration, () =>
            {
                Array.Copy(source, target, 1000);
            });
        }
    }
}