using System;
using Benchmarking;

namespace Test18_TryCatch_TryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000_000;

            Profiler.Profile("TryCatch", NoOfIteration, () =>
            {
                try
                {
                    string i = "0a";
                    int result = int.Parse(i);
                }
                catch (Exception e)
                {

                }
            });

            Profiler.Profile("TryParse", NoOfIteration, () =>
            {
                string i = "0a";
                int result;
                int.TryParse(i, out result);
            });
        }
    }
}
