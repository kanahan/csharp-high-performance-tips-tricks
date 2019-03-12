using System;
using static Hexagon.CH;

namespace Hexagon
{
    enum CH { A = 'A', B = 'B', C = 'C', D = 'D', E = 'E', F = 'F' };

    class Program
    {
        static CH[] h1 = { E, A, C, F, B, D };
        static CH[] h2 = { D, F, E, C, A, B };
        static CH[] h3 = { F, E, D, A, B, C };
        static CH[] h4 = { A, F, D, E, B, C };
        static CH[] h5 = { D, C, B, A, E, F };
        static CH[] h6 = { A, C, B, E, F, D };
        static CH[] h7 = { A, F, E, D, C, B };
        static CH[][] hexs = { h1, h2, h3, h4, h5, h6, h7 };
        static int[] hs = new int[7];
        static int[] rs = new int[7];
        static int level = 0;
        static int noOfAnswers = 0;
        static void Solve()
        {
            if (level == 7)
            {
                noOfAnswers++;
                showAnswer();
            }
            else
            {
                int r;
                for (int h = 0; h < 7; h++)
                {
                    if (isValidHex(h, out r))
                    {
                        hs[level] = h;
                        rs[level] = r;
                        level++;
                        Solve();
                        level--;
                    }
                }
            }
        }
        static void showAnswer()
        {
            for (int h = 0; h < 7; h++)
            {
                Console.WriteLine("Slot{0}: h{1} rotate {2}X", h, hs[h], rs[h]);
            }
            Console.WriteLine();
        }
        static bool isValidHex(int h, out int r)
        {
            r = 0;
            //Ensure unique permutation
            for (int i = 0; i < level; i++)
            {
                if (hs[i] == h) return false;
            }

            if (level == 0) return true;//No rotation needed to prevent symmetric answers
                                        //Ensure found rotate match
            CH[] chex = hexs[hs[0]];//Centre Hex
            CH[] hex = hexs[h];
            for (r = 0; r < 6; r++)
            {
                if (chex[level - 1] != hex[r]) continue;//Attempt other rotation
                if (level > 1)
                {
                    CH[] hexb4 = hexs[hs[level - 1]];
                    int rb4 = rs[level - 1];
                    if (hex[(r + 1) % 6] != hexb4[(rb4 + 5) % 6]) continue;
                }
                else
                {
                    if (level == 6)
                    {
                        if (hex[(r + 5) % 6] != hexs[hs[1]][rs[1] + 1]) continue;
                    }
                }
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Solve();
            Console.WriteLine("No of Answers found is {0}", noOfAnswers);
            Console.ReadKey();
        }
    }
}
