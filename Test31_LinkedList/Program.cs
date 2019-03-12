using Benchmarking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test31_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {   
            const uint NoOfIteration = 10_000;
            var items1 = new List<int>();
            var items2 = new LinkedList<int>();

            Console.WriteLine("\nInsert in Front:");
            Profiler.Profile("\tList", NoOfIteration, () =>
            {
                items1.Insert(0, 100);
            });
            Profiler.Profile("\tLinked-List", NoOfIteration, () =>
            {
                items2.AddFirst(100);
            });

            items1.Clear();
            items2.Clear();


            Console.WriteLine("\nInsert at the Back:");
            Profiler.Profile("\tList", NoOfIteration, () =>
            {
                items1.Add(100);
            });
            Profiler.Profile("\tLinked-List", NoOfIteration, () =>
            {
                items2.AddLast(100);
            });

            items1.Clear();
            items2.Clear();


            Console.WriteLine("\nInsert at the Middle:");
            for (var i = 0; i < 50; i++)
            {
                items1.Add(i);
                items2.AddLast(i);
            }

            Profiler.Profile("\tList", NoOfIteration, () =>
            {
                items1.Insert(50, 100);
            });
            LinkedListNode<int> n = items2.Last;
            Profiler.Profile("\tLinked-List", NoOfIteration, () =>
            {
                items2.AddAfter(n, 100);
            });


            Console.WriteLine("\nAccess First Item:");
            Profiler.Profile("\tList", NoOfIteration, () =>
            {
                int v = items1[0];
            });
            Profiler.Profile("\tLinked-List", NoOfIteration, () =>
            {
                int v = items2.First.Value;
            });


            Console.WriteLine("\nAccess Last Item:");
            Profiler.Profile("\tList", NoOfIteration, () =>
            {
                int v = items1[items1.Count - 1];
            });
            Profiler.Profile("\tLinked-List", NoOfIteration, () =>
            {
                int v = items2.Last.Value;
            });


            Console.WriteLine("\nIterate Every Item:");
            Profiler.Profile("\tList", NoOfIteration, () =>
            {
                foreach(int i in items1)
                {
                    int v = i;
                }
            });
            Profiler.Profile("\tLinked-List", NoOfIteration, () =>
            {
                foreach (int i in items2)
                {
                    int v = i;
                }
            });

            items1.Clear();
            items2.Clear();
        }
    }
}
