using System;
using Benchmarking;

namespace Test12_Equals_ReferenceEquals
{
    class X
    {
        int N;

        public X(int n)
        {
            this.N = n;
        }

        public override bool Equals(object obj)
        {
            X rhs = obj as X;
            return this.N == rhs.N;
        }

        static public bool operator == (X lhs, X rhs)
        {
            return lhs.N == rhs.N;
        }

        static public bool operator != (X lhs, X rhs)
        {
            return lhs.N != rhs.N;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 10_000_000;

            X x1 = new X(100);
            X x2 = new X(100);

            Profiler.Profile("==", NoOfIteration, () =>
            {
                if (x1 == x2) { };
            });

            Profiler.Profile("Equals", NoOfIteration, () =>
            {
                if (x1.Equals(x2)) { };
            });

            Profiler.Profile("ReferenceEquals", NoOfIteration, () =>
            {
                if (X.ReferenceEquals(x1, x2)) { };
            });

            string v1 = "test";
            string v2 = "test1";
            v2 = "test";
            Console.WriteLine(String.ReferenceEquals(v1, v2));
        }
    }
}