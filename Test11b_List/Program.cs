using System;
using System.Collections;
using System.Collections.Generic;
using Benchmarking;

namespace Test11b_List
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 100;

            ArrayList data1 = new ArrayList();
            List<int> data2 = new List<int>();
            int total = 0;

            Profiler.Profile("ArrayList", NoOfIteration, () =>
            {
                total = 0;
                for (int i = 0; i < 100; i++)
                {
                    data1.Add(i);
                }
                foreach (var item in data1)
                {
                    total += (int)item;
                }
            });
            Console.WriteLine("\ttotal is {0}", total);

            Profiler.Profile("List", NoOfIteration, () =>
            {
                total = 0;
                for (int i = 0; i < 100; i++)
                {
                    data2.Add(i);
                }
                foreach (var item in data2)
                {
                    total += item;
                }
            });
            Console.WriteLine("\ttotal is {0}", total);
        }
    }
}