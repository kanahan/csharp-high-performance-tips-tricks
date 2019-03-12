using Benchmarking;
using System;
using System.Collections.Generic;

namespace Test31_Static
{
    class Account
    {
        public double Balance;
        public float InterestRate = 0.05F;
        public Account(double initAMount)
        {
            Balance = initAMount;
        }
        public Account() : this(0.0)
        {

        }
    }

    class Account2
    {
        public double Balance;
        static public float InterestRate = 0.05F;
        public Account2(double initAMount)
        {
            Balance = initAMount;
        }
        public Account2() : this(0.0)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000;

            Profiler.Profile("Instance Member", NoOfIteration, () =>
            {
                List<Account> accounts = new List<Account>();
                for (int i = 0; i < 1000; i++)
                {
                    accounts.Add(new Account());
                }
                foreach (var account in accounts) account.InterestRate = 0.06F;
            });
            Profiler.Profile("Class Member", NoOfIteration, () =>
            {
                List<Account2> accounts = new List<Account2>();
                for (int i = 0; i < 1000; i++)
                {
                    accounts.Add(new Account2());
                }
                Account2.InterestRate = 0.06F;
            });
        }
    }
}
