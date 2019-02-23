using System;
using Benchmarking;

namespace Test6
{
    class Program
    {
        static bool isPrime(ulong n)
        {
            ulong i;
            for (i = 2; i < n; i++)
            {
                if ((n % 1) == 0)
                {
                    break;
                }
            }
            return (i == n);
        }
        
        static bool isEndedWith3(ulong n)
        {
            return (n % 10) == 3;
        }

        static void Main(string[] args)
        {
            const uint NoOfIteration = 1;
            int count = 0;

            Profiler.Profile("Prime AND 3", NoOfIteration, () =>
            {
                count = 0;
                for (ulong i = 0; i < 100_000; i++)
                {
                    if (isPrime(i) && isEndedWith3(i))
                    {
                        count++;
                    }
                }
            });
            Console.WriteLine("\tcount is {0}", count);

            Profiler.Profile("3 AND Prime", NoOfIteration, () =>
            {
                count = 0;
                for (ulong i = 0; i < 100_000; i++)
                {
                    if (isEndedWith3(i) && isPrime(i))
                    {
                        count++;
                    }
                }
            });
            Console.WriteLine("\tcount is {0}", count);
        }
    }
}
