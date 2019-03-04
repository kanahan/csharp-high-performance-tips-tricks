using System;
using Benchmarking;

namespace Test24
{
    class Program
    {
        static double Pmt(double p, float r, int n)
        {
            return p * ((r * Math.Pow(1.0+r, n)) / (Math.Pow(1.0 + r, n) -1));
        }

        static double Pmt2(double p, float r, int n)
        {
            double d = Math.Pow(1.0 + r, n);
            return p * ((r * d) / (d - 1));
        }
        
        static double Pmt3(double p, float r, int n)
        {
            double d = Math.Pow(1.0 + r, n);
            return p * ((r * d) / (d - 1));
        }

        static void Main(string[] args)
        {
            double loan = 1_000_000;
            float annualRate = 0.046F;
            int durationInYears = 30;

            Console.WriteLine("Monthly Installment is {0:c}", Pmt(loan, annualRate / 12, 12 * durationInYears));
            Console.WriteLine("Monthly Installment is {0:c}", Pmt2(loan, annualRate / 12, 12 * durationInYears));

            const uint NoOfIteration = 1_000_000;


            Profiler.Profile("Original", NoOfIteration, () =>
            {
                double monthlyInstallment = Pmt(loan, annualRate / 12, 12 * durationInYears);
            });

            Profiler.Profile("Removed Redundant Code", NoOfIteration, () =>
            {
                double monthlyInstallment = Pmt2(loan, annualRate / 12, 12 * durationInYears);
            });

            Profiler.Profile("Removed Redundant Code + Inlining", NoOfIteration, () =>
            {
                double monthlyInstallment = Pmt3(loan, annualRate / 12, 12 * durationInYears);
            });
        }
    }
}
