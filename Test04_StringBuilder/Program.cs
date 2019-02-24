using System;
using Benchmarking;
using System.Text;

namespace Test04_StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 100;
            int gcCount;

            Profiler.Profile("string concatenation", NoOfIteration, () =>
            {
                string s = "";
                for (int i = 0; i < 10_000; i++)
                {
                    s += i;
                }
            }, out gcCount);
            Console.WriteLine("\tCG activation count: {0}", gcCount);

            Profiler.Profile("string builder", NoOfIteration, () =>
            {
                StringBuilder sb = new StringBuilder("");
                for (int i = 0; i < 10_000; i++)
                {
                    sb.Append(i);
                }
                string s = sb.ToString();
            }, out gcCount);
            Console.WriteLine("\tCG activation count: {0}", gcCount);
        }
    }
}
