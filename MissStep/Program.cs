using System;

namespace MissStep
{
    class Program
    {
        static int[,] tblMissStep =
        {
            /*      0  1  2  3  4  5  6  7  8 */
            /*0*/ { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            /*1*/ { 0, 1, 2, 1, 2, 3, 2, 3, 4 },
            /*2*/ { 1, 0, 1, 2, 1, 2, 3, 2, 3 },
            /*3*/ { 2, 1, 0, 3, 2, 1, 4, 3, 2 },
            /*4*/ { 3, 2, 1, 2, 1, 0, 3, 2, 1 },
            /*5*/ { 4, 3, 2, 3, 2, 1, 2, 1, 0 },
            /*6*/ { 3, 2, 3, 2, 1, 2, 1, 0, 1 },
            /*7*/ { 2, 3, 4, 1, 2, 3, 0, 1, 2 },
            /*8*/ { 1, 2, 3, 0, 1, 2, 1, 2, 3 }
        };

        static int TotalMissedSteps(int state)
        {
            int total = 0;
            for (int slot = 0; slot < 9; slot++)
            {
                int digit = state % 10;
                state /= 10;
                total += tblMissStep[digit, slot];
            }
            return total;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(TotalMissedSteps(523608417));
        }
    }
}
