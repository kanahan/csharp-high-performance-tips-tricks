using System;
using Benchmarking;

namespace Test09b_2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 1000;
            int[,] grid = new int[N,N];

            const uint NoOfIteration = 100;

            Profiler.Profile("Row First", NoOfIteration, () =>
            {
                int total = 0;
                for (int r = 0; r < N; r++)
                {
                    for (int c = 0; c < N; c++)
                    {
                        total += grid[r,c];
                    }
                }
            });

            Profiler.Profile("Column First", NoOfIteration, () =>
            {
                int total = 0;
                for (int c = 0; c < N; c++)
                {
                    for (int r = 0; r < N; r++)
                    {
                        total += grid[r,c];
                    }
                }
            });
        }
    }
}