using System;
using Benchmarking;

namespace Test11_StronglyType
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000_000;

            Object[] data1 = new object[100];
            int[] data2 = new int[100];
            int total = 0;

            Profiler.Profile("boxing", NoOfIteration, () =>
            {
                total = 0;
                for (int i = 0; i < data1.Length; i++)
                {
                    data1[i] = i;
                }
                foreach(var item in data1)
                {
                    total += (int)item;
                }
            });
            Console.WriteLine("\ttotal is {0}", total);

            Profiler.Profile("strongly type", NoOfIteration, () =>
            {
                total = 0;
                for (int i = 0; i < data2.Length; i++)
                {
                    data2[i] = i;
                }
                foreach (var item in data2)
                {
                    total += item;
                }
            });
            Console.WriteLine("\ttotal is {0}", total);
        }
    }
}