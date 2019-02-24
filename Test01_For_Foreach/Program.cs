using System;
using Benchmarking;

namespace Test01_For_Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[100];
            const uint NoOfIteration = 10_000_000;
            Profiler.Profile("for", NoOfIteration, () =>
            {
                int v = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    v += data[i];
                }
            });

            Profiler.Profile("foreach", NoOfIteration, () =>
            {
                int v = 0;
                foreach(var item in data)
                {
                    v += item;
                }
            });
        }
    }
}
