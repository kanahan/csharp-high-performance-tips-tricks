using System;
using Benchmarking;
using System.Collections.Generic;

namespace Test07_Initialized
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 10;

            Profiler.Profile("default", NoOfIteration, () =>
            {
                List<int> items = new List<int>();
                for (int i = 0; i < 1_000_000; i++)
                {
                    items.Add(i);
                }
            });

            Profiler.Profile("initialized", NoOfIteration, () =>
            {
                List<int> items = new List<int>(1_000_000);
                for (int i = 0; i < 1_000_000; i++)
                {
                    items.Add(i);
                }
                items.TrimExcess();
            });
        }
    }
}
