using Benchmarking;
using System;

namespace Test30_Swap_Array
{
    unsafe class Program
    {
        static void Main(string[] args)
        {
            const int ARRAY_SIZE = 50;
            int[] Data1 = new int[ARRAY_SIZE];
            int[] Data2 = new int[ARRAY_SIZE];
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                Data1[i] = i;
                Data2[i] = ARRAY_SIZE - i - 1;
            }
            const uint NoOfIteration = 1_000_000;

            Profiler.Profile("Conventional Way", NoOfIteration, () =>
            {
                for (int i = 0; i < ARRAY_SIZE; i++)
                {
                    int temp = Data1[i];
                    Data1[i] = Data2[i];
                    Data2[i] = temp;
                }
            });

            Profiler.Profile("Use pointer", NoOfIteration, () =>
            {
                fixed (int* p1 = &Data1[0], p2 = &Data2[0])
                {
                    for (int i = 0; i < ARRAY_SIZE; i++)
                    {
                        int temp = *(p1 + i);
                        *(p1 + i) = *(p2 + i);
                        *(p2 + i) = temp;
                    }
                }
            });

            foreach (var item in Data2) Console.Write("{0} ", item);
        }
    }
}