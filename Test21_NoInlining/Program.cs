using System;
using System.Runtime.CompilerServices;
using Benchmarking;

namespace Test20
{
    class Program
    {

        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        static int Sum1(int x, int y)
        {
            return x + y;
        }

        [MethodImplAttribute(MethodImplOptions.AggressiveInlining)]
        static int Sum2(int x, int y)
        {
            return x + y;
        }

        static int Sum3(int x, int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000_000_000;

            Profiler.Profile("No Inlining", NoOfIteration, () =>
            {
                int result = Sum1(10, 20);
            });

            Profiler.Profile("With Inlining", NoOfIteration, () =>
            {
                int result = Sum2(10, 20);
            });

            Profiler.Profile("Default", NoOfIteration, () =>
            {
                int result = Sum3(10, 20);
            });

            Profiler.Profile("No Method Call", NoOfIteration, () =>
            {
                int result = 10 + 20;
            });
        }
    }
}
