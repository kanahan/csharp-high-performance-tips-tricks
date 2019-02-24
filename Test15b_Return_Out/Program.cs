using System;
using Benchmarking;

namespace Test15b_Return_Out
{
    class Program
    {
        static void ByOut(int x, out int value)
        {
            value = x * 100;
        }

        static int ByReturn(int value)
        {
            return value * 100;
        }

        static void Main(string[] args)
        {
            int input = 5;
            int outValue;

            const uint NoOfIteration = 1_000_000;

            Profiler.Profile("ByOut", NoOfIteration, () =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    ByOut(input, out outValue);
                }
            });

            Profiler.Profile("ByReturn", NoOfIteration, () =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    ByReturn(input);
                }
            });
        }
    }
}