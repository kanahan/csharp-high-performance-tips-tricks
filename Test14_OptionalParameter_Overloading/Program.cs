using System;
using Benchmarking;

namespace Test14_OptionalParameter_Overloading
{
    class Program
    {
        static decimal Sum1(decimal x = 0, decimal y = 0, decimal z = 0)
        {
            return x + y + z;
        }

        static decimal Sum2(decimal x, decimal y, decimal z)
        {
            return x + y + z;
        }

        static decimal Sum2(decimal x, decimal y)
        {
            return x + y;
        }

        static decimal Sum2(decimal x)
        {
            return x;
        }

        static decimal Sum2()
        {
            return 0;
        }

        static void Main(string[] args)
        {
            const uint NoOfIteration = 10_000_000;

            Profiler.Profile("Optional Parameter", NoOfIteration, () =>
            {
                Sum1(1, 2, 3);
                Sum1(1, 2);
                Sum1(1);
                Sum1();
            });

            Profiler.Profile("Overloading", NoOfIteration, () =>
            {
                Sum2(1, 2, 3);
                Sum2(1, 2);
                Sum2(1);
                Sum2();
            });
        }
    }
}