using System;
namespace StrategyEx2
{
    class Context
    {
        //Context state
        static public IStrategy byInsertion = new ByInsertion();
        static public IStrategy byBubble = new ByBubble();

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
        public void SortArray(int[] data)
        {
            int asc = 0;
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i] < data[i + 1]) asc++;
            }

            if ((asc / (float)data.Length) > 0.5)
            {
                Strategy = byInsertion;
            }
            else
            {
                Strategy = byBubble;
            }
            strategy.Sort(this, data);
        }
    }

    interface IStrategy
    {
        void Sort(Context c, int[] data);
    }

    class ByInsertion : IStrategy
    {
        public void Sort(Context c, int[] data)
        {
            int val = 0;
            int flag = 0;
            for (int i = 1; i < data.Length; i++)
            {
                val = data[i];
                flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val < data[j])
                    {
                        data[j + 1] = data[j];
                        j--;
                        data[j + 1] = val;
                    }
                    else flag = 1;
                }
            }

            Console.WriteLine("Insertion");
            for (int i = 0; i < data.Length; i++)
                Console.Write(data[i] + " ");
        }
    }
    class ByBubble : IStrategy
    {
        public void Sort(Context c, int[] data)
        {
            int temp = 0;
            for (int write = 0; write < data.Length; write++)
            {
                for (int sort = 0; sort < data.Length - 1; sort++)
                {
                    if (data[sort] > data[sort + 1])
                    {
                        temp = data[sort + 1];
                        data[sort + 1] = data[sort];
                        data[sort] = temp;
                    }
                }
            }

            Console.WriteLine("Bubble");
            for (int i = 0; i < data.Length; i++)
                Console.Write(data[i] + " ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] data = new int[] { 2, 8, 6, 7, 3, 4, 5, 1, 0, 11 };
            Context c = new Context();
            c.SortArray(data);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
