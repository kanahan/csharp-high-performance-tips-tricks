using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens
{
    class Program
    {
        static int NoOfAnswers = 0;
        static int Row = 0;
        static int[] Qs = new int[8];
        static void Solve()
        {
            if (Row == 8)
            {
                NoOfAnswers++;
                ShowAnswer();
            }
            else
            {
                for (int c=0; c<8; c++)
                {
                    if (IsValidColumn(c))
                    {
                        Qs[Row] = c;
                        Row++;
                        Solve(); // Recursion
                        Row--; // Backtracking
                    }
                }
            }
        }

        static void ShowAnswer()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Console.Write((c==Qs[r] ? 'Q': '_'));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool IsValidColumn(int c)
        {
            for (int r = 0; r < Row; r++)
            {
                // Vertical Check
                if (Qs[r] == c) return false;

                //Diagonal Check
                int dR = Row - r;
                int dC = c - Qs[r];
                if (dC < 0) dC = -dC;
                if (dR == dC) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Solve();
            Console.WriteLine("No of Answers is {0}", NoOfAnswers);
        }
    }
}
