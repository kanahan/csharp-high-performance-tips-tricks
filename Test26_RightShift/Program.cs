using System;
using Benchmarking;

namespace Test26
{
    class Program
    {

        static void Main(string[] args)
        {
            double x = 3;
            long y = 200;

            const uint NoOfIteration = 1_000_000;


            Profiler.Profile("Math.Pow", NoOfIteration, () =>
            {
                double result = Math.Pow(x, 2);
            });

            Profiler.Profile("Multiple", NoOfIteration, () =>
            {
                double result = x * x;
            });

            Profiler.Profile("Divide", NoOfIteration, () =>
            {
                long result = y / 16;
            });

            Profiler.Profile("Right Shift", NoOfIteration, () =>
            {
                long result = y >> 4;
            });
        }
    }
}
