using System;
using Benchmarking;

namespace Test03_ReadOnly
{
    class Person
    {
        string _Name1;
        public string Name1
        {
            get
            {
                return _Name1;
            }

            private set
            {
                _Name1 = value;
            }
        }

        public readonly string Name2;

        public Person(string name)
        {
            Name1 = name;
            Name2 = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000_000_000;
            Person p = new Person("Tong Sam Pah");

            Profiler.Profile("readonly property", NoOfIteration, () =>
            {
                string name = p.Name1;
            });

            Profiler.Profile("readonly field", NoOfIteration, () =>
            {
                string name = p.Name2;
            });
        }
    }
}
