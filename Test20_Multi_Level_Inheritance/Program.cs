using System;
using System.Runtime.CompilerServices;
using Benchmarking;

namespace Test20
{
    class Program
    {
        class Person
        {
            public string Name;

            [MethodImplAttribute(MethodImplOptions.NoInlining)]
            public Person(string name)
            {
                Name = name;
            }
        }

        class Staff : Person
        {
            public double Salary;

            [MethodImplAttribute(MethodImplOptions.NoInlining)]
            public Staff(string name, double salary) : base(name)
            {
                Salary = salary;
            }
        }

        class Staff2
        {
            public string Name;
            public double Salary;

            [MethodImplAttribute(MethodImplOptions.NoInlining)]
            public Staff2(string name, double salary)
            {
                Name = name;
                Salary = salary;
            }
        }

        class Manager : Staff
        {
            public float CarAllowance;
            
            public Manager(string name, double salary, float carAllowance) : base(name, salary)
            {
                CarAllowance = carAllowance;
            }
        }

        class Manager2 : Staff2
        {
            public float CarAllowance;
            
            public Manager2(string name, double salary, float carAllowance) : base(name, salary)
            {
                CarAllowance = carAllowance;
            }
        }

        class Manager3
        {
            public string Name;
            public double Salary;
            public float CarAllowance;
            
            public Manager3(string name, double salary, float carAllowance)
            {
                Name = name;
                Salary = salary;
                CarAllowance = carAllowance;
            }
        }


        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000_000_000;

            Profiler.Profile("Manager", NoOfIteration, () =>
            {
                new Manager("Ali", 5000.0, 500.0F);
            });

            Profiler.Profile("Manager2", NoOfIteration, () =>
            {
                new Manager2("Ali", 5000.0, 500.0F);
            });

            Profiler.Profile("Manager3", NoOfIteration, () =>
            {
                new Manager3("Ali", 5000.0, 500.0F);
            });
        }
    }
}
