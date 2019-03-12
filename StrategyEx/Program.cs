using System;
namespace StrategyEx
{
    class Context
    {
        //Context state
        static public IStrategy byBus = new ByBus();
        static public IStrategy byUber = new ByUber();
        static public IStrategy byTrain = new ByTrain();
        static public IStrategy byTaxi = new ByTaxi();

        //Strategy aggregation
        IStrategy strategy = null;
        public IStrategy Strategy
        {
            set
            {
                strategy = value;
            }
        }

        // Algorithm invokes a strategy method
        public void GotoAirport()
        {
            Console.Write("Going to airport ");
            strategy.Transportation(this);
        }
    }

    interface IStrategy
    {
        void Transportation(Context c);
    }

    class ByBus : IStrategy
    {
        public void Transportation(Context c)
        {
            Console.WriteLine("by Bus");
        }
    }
    class ByUber : IStrategy
    {
        public void Transportation(Context c)
        {
            Console.WriteLine("by Uber");
        }
    }
    class ByTrain : IStrategy
    {
        public void Transportation(Context c)
        {
            Console.WriteLine("by Train");
        }
    }
    class ByTaxi : IStrategy
    {
        public void Transportation(Context c)
        {
            Console.WriteLine("by Taxi");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool cost = false, time = false;
            //Ask from the user about cost and time
            Console.WriteLine("is cost important? (y/n)");
            cost = Console.ReadLine().Equals("y", StringComparison.InvariantCultureIgnoreCase);


            Console.WriteLine("is time important? (y/n)");
            time = Console.ReadLine().Equals("y", StringComparison.InvariantCultureIgnoreCase);

            Context c = new Context();
            if (cost)
            {
                if (time)
                {
                    c.Strategy = Context.byUber;
                }
                else
                {
                    c.Strategy = Context.byBus;
                }
            }
            else
            {
                if (time)
                {
                    c.Strategy = Context.byTaxi;
                }
                else
                {
                    c.Strategy = Context.byTrain;
                }
            }
            c.GotoAirport();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
