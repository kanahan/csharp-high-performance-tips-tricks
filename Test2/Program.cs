using System;
using Benchmarking;

namespace Test2
{
    class C1
    {
        double r;
        public C1(double r)
        {
            this.r = r;
        }

        public double Area
        {
            get { return Math.PI * r * r; }
        }

        public double Circumference
        {
            get { return 2 * Math.PI * r; }
        }
    }

    struct C2
    {
        double r;
        public C2(double r)
        {
            this.r = r;
        }

        public double Area
        {
            get { return Math.PI * r * r; }
        }

        public double Circumference
        {
            get { return 2 * Math.PI * r; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 100_000_000;
            Profiler.Profile("class", NoOfIteration, () =>
            {
                C1 c = new C1(100);
                double area = c.Area;
                double circumference = c.Circumference;
            });
            Profiler.Profile("struct", NoOfIteration, () =>
            {
                C2 c = new C2(100);
                double area = c.Area;
                double circumference = c.Circumference;
            });
        }
    }
}
