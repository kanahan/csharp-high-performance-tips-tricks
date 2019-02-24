using System;
using Benchmarking;

namespace Test05_Checked
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 100;

            //checked
            //{
            //    var r = int.MaxValue;
            //    Console.WriteLine(r + 1);
            //}

            Profiler.Profile("no check", NoOfIteration, () =>
            {
                for (int i = 0; i < 1_000_000; i++)
                {
                    var x = i + 2;
                    x--;
                    x *= 10;
                    Console.WriteLine(x);
                }
            });

            Profiler.Profile("check", NoOfIteration, () =>
            {
                for (int i = 0; i < 1_000_000; i++)
                {
                    checked
                    {
                        var x = i + 2;
                        x--;
                        x *= 10;
                    }
                }
            });
        }
    }
}
