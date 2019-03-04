using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestIsland
{
    class X
    {
        public string Name;
        public X Sibling;
        public X (string name)
        {
            Name = name;
        }

        ~X()
        {
            Console.WriteLine("{0} is destroyed..", Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            X a = new X("A");
            X b = new X("B");
            X c = new X("C");
            a.Sibling = b;
            b.Sibling = c;
            c.Sibling = a;

            GC.SuppressFinalize(a);

            new X("D"); // Immediaetly became garbage
            GC.Collect();
            Thread.Sleep(2000);
            Console.WriteLine(a.Name);
            Console.WriteLine("Program end...");
        }
    }
}
