using System;
using Benchmarking;

namespace Test10_Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000_000;
            int gcCount = 0;

            string s1 = "Hyderabad";
            string s2 = "hyderabad";

            Profiler.Profile("ToLower", NoOfIteration, () =>
            {
                if (s1.ToLower() == s2.ToLower())
                {

                }
            }, out gcCount);
            Console.WriteLine("\tcount is {0}", gcCount);

            Profiler.Profile("Compare", NoOfIteration, () =>
            {
                if (string.Compare(s1, s2, true) == 0)
                {

                }
            }, out gcCount);
            Console.WriteLine("\tcount is {0}", gcCount);
        }
    }
}