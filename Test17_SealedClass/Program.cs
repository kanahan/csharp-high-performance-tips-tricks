using System;
using Benchmarking;

namespace Test17_SealedClass
{
    abstract class Staff
    {
        public string Name;
        private double _Salary;
        virtual public double Salary
        {
            get
            {
                return _Salary;
            }

            set
            {
                if (value < 1100) throw new Exception("Invalid Salary");
                _Salary = value;
            }
        }

        public Staff(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        abstract public double getMonthlySalary();

    }


    class Manager : Staff
    {
        public float CarAllowance;
        public Manager(string name, double salary, float carAllowance) : base(name, salary)
        {
            CarAllowance = carAllowance;
        }

        public override double getMonthlySalary()
        {
            return (1.0 - 0.11) * Salary + CarAllowance;
        }
    }

    sealed class Lecturer : Staff
    {
        public float Allowance;
        public Lecturer(string name, double salary, float allowance) : base(name, salary)
        {
            Allowance = allowance;
        }

        public override double getMonthlySalary()
        {
            return (1.0 - 0.11) * Salary + Allowance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const uint NoOfIteration = 100_000_000;
            Manager m = new Manager("Ali", 5000, 500);
            Lecturer l = new Lecturer("Abu", 5000, 500);


            Profiler.Profile("Normal Class", NoOfIteration, () =>
            {
                m.Salary = 5000;
                double monthlySalary = m.getMonthlySalary();
            });

            Profiler.Profile("Sealed Class", NoOfIteration, () =>
            {
                l.Salary = 5000;
                double monthlySalary = l.getMonthlySalary();
            });

        }
    }
}
