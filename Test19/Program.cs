using System;
using Benchmarking;

namespace Test19
{
    class Program
    {
        static bool isWellFormed1(int n)
        {
            int[] flags = new int[9];

            for (int i = 0; i < 9; i++)
            {
                int d = n % 10;
                n /= 10;
                if (Array.IndexOf(flags, d) > -1)
                {
                    return false;
                }
            }
            return true;
        }

        static bool isWellFormed2(int n)
        {
            bool[] flags = new bool[9];

            for (int i = 0; i < 9; i++)
            {
                int d = n % 10;
                n /= 10;
                flags[d] = true;
            }

            for (int i = 0; i < 9; i++)
            {
                if (flags[i] == false) return false;
            }
            return true;
        }

        static bool isWellFormed3(int n)
        {
            int flags = 0x000001FF;

            for (int i = 0; i < 9; i++)
            {
                int d = n % 10;
                n /= 10;
                flags &= ~(1 << d);
            }
            return (n == 0) && (flags == 0);
        }

        static void Main(string[] args)
        {
            var gcCount = 0;
            const uint NoOfIteration = 1_000_000;

            Profiler.Profile("Array", NoOfIteration, () =>
            {
                isWellFormed1(123456780);
            }, out gcCount);
            Console.WriteLine("\tCount  is {0}", gcCount);

            Profiler.Profile("Array Boolean", NoOfIteration, () =>
            {
                isWellFormed2(123456780);
            }, out gcCount);
            Console.WriteLine("\tCount  is {0}", gcCount);

            Profiler.Profile("Bitwise", NoOfIteration, () =>
            {
                isWellFormed3(123456780);
            }, out gcCount);
            Console.WriteLine("\tCount  is {0}", gcCount);
        }
    }
}