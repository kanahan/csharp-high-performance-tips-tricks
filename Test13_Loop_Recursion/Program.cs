using System;
using Benchmarking;

namespace Test13_Loop_Recursion
{
    class Program
    {
        static uint calRecursion(uint n)
        {
            if (n < 2)
            {
                return 1;
            }
            else
            {
                return n * calRecursion(n - 1);
            }
        }

        static uint calLoop(uint n)
        {
            uint total = 1;
            for (uint i = 1; i <= n; i++)
            {
                total *= i;
            }
            return total;
        }

        static void Main(string[] args)
        {
            const uint NoOfIteration = 1000000;

            Profiler.Profile("Recursion", NoOfIteration, () =>
            {
                calRecursion(4);
            });

            Profiler.Profile("Loop", NoOfIteration, () =>
            {
                calLoop(4);
            });

        }
    }
}