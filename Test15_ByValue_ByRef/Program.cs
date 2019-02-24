using System;
using Benchmarking;

namespace Test15_ByValue_ByRef
{
    struct Rec
    {
        public int v1;
        public double v2;
        public long v3;
        public float v4;
        public Rec(int v1, double v2, long v3, float v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }
    }

    class Program
    {
        static void ByValue(Rec rec1, Rec rec2)
        {
            var v = rec1.v3;
        }

        static void ByRef(ref Rec rec1, ref Rec rec2)
        {
            var v = rec1.v3;
        }

        static void Main(string[] args)
        {
            Rec r1 = new Rec(100, 200, 3000, 400);
            Rec r2 = new Rec(100, 200, 3000, 400);

            const uint NoOfIteration = 1000_000_000;

            Profiler.Profile("ByValue", NoOfIteration, () =>
            {
                ByValue(r1, r2);
            });

            Profiler.Profile("ByRef", NoOfIteration, () =>
            {
                ByRef(ref r1, ref r2);
            });
        }
    }
}