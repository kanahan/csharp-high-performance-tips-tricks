using System;
using Benchmarking;
using System.Collections.Generic;

namespace Test8
{
    class Program
    {
        static List<int> Odd1(int[] data)
        {
            List<int> items = new List<int>();
            foreach (var item in data)
            {
                if ((item % 2) == 1)
                {
                    Console.Write("*");
                    items.Add(item);
                }
            }
            return items;
        }

        static IEnumerable<int> Odd2(int[] data)
        {
            foreach (var item in data)
            {
                if ((item % 2) == 1)
                {
                    Console.Write("*");
                    yield return item;
                }
            }
        }

        // to make sure both data are correct
        //static void Main(string[] args)
        //{
        //    int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        //    foreach (var item in Odd1(data))
        //    {
        //        Console.WriteLine("\t {0}", item);
        //    }

        //    foreach (var item in Odd2(data))
        //    {
        //        Console.WriteLine("\t {0}", item);
        //    }
        //}

        static void Main(string[] args)
        {
            int[] data = new int[100];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            const uint NoOfIteration = 1;
            int gcCount = 0;

            Profiler.Profile("Use List", NoOfIteration, () =>
            {
                int n = 0;
                foreach (var item in Odd1(data))
                {
                    n += item;
                }
            }, out gcCount);
            Console.WriteLine("\t GC Count is {0}", gcCount);

            Profiler.Profile("yield return", NoOfIteration, () =>
            {
                int n = 0;
                foreach (var item in Odd2(data))
                {
                    n += item;
                }
            }, out gcCount);
            Console.WriteLine("\t GC Count is {0}", gcCount);
        }
    }
}
