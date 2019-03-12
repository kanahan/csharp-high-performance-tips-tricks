using System;
using System.Threading;
using Benchmarking;
namespace Test33_MemberwiseClone
{
    class X
    {
        public int a, b, c;
        public X()
        {
            a = 10;
            b = 100;
            c = 2000;
            Thread.Sleep(1);//Simulate the delay in object creation
        }
        public X Clone()
        {
            return (X)this.MemberwiseClone();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000;
            X x = new X();
            X x2 = new X() { a = x.a, b = x.b, c = x.c };
            X x3 = x2.Clone();
            Console.WriteLine("x2.c is {0}", x2.c);
            Console.WriteLine("x3.c is {0}", x3.c);

            int count;
            Profiler.Profile("Normal Instantiation", NoOfIteration, () => {
                for (int i = 0; i < 100; i++) new X() { a = x.a, b = x.b, c = x.c };
            }, out count);
            Console.WriteLine("No of GC activation is {0}", count);
            Profiler.Profile("Cloning", NoOfIteration, () => {
                for (int i = 0; i < 100; i++) x.Clone();
            }, out count);
            Console.WriteLine("No of GC activation is {0}", count);
        }
    }
}