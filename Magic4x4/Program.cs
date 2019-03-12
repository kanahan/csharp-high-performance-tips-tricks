using System;

namespace Magic3x3
{
    class Program
    {
        static int NoOfPatterns = 0;
        static int NoOfAnswers = 0;
        static int Level = 0;
        static int[] slots = new int[16];

        static void Solve()
        {
            int n = 16;

            if (Level < n)
            {
                // Generate
                for (int d = 1; d <= n; d++)
                {
                    if (IsNotInUsed(d))
                    {
                        slots[Level] = d;
                        Level++;
                        if (Level % 3 == 0 && (slots[Level-3] + slots[Level - 2] + slots[Level - 1] + slots[Level] == 34))
                        {
                            Console.WriteLine(slots[Level - 3] + "," + slots[Level - 2] + "," + slots[Level - 1] + "," + slots[Level] + " = " + (slots[Level - 3] + slots[Level - 2] + slots[Level - 1] + slots[Level]));
                            Solve(); // Recursion
                        }
                        Level--; // Backtracking
                    }
                }

            }
            else
            {
                NoOfPatterns++;
                if (IsAnswer())
                {
                    NoOfAnswers++;
                    ShowAnswer();
                }
            }
        }

        static bool IsAnswer()
        {
            // 012
            // 345
            // 678
            int H1 = slots[0] + slots[1] + slots[2] + slots[3];
            int H2 = slots[4] + slots[5] + slots[6] + slots[7];
            int H3 = slots[8] + slots[9] + slots[10] + slots[11];
            int H4 = slots[12] + slots[13] + slots[14] + slots[15];
            int V1 = slots[0] + slots[4] + slots[8] + slots[12];
            int V2 = slots[1] + slots[5] + slots[9] + slots[13];
            int V3 = slots[2] + slots[6] + slots[10] + slots[14];
            int V4 = slots[3] + slots[7] + slots[8] + slots[12];
            int B1 = slots[0] + slots[5] + slots[10] + slots[16];
            int B2 = slots[3] + slots[6] + slots[9] + slots[12];

            return (H1 == H2) &&
                (H1 == H3) &&
                (H1 == V1) &&
                (H1 == V2) &&
                (H1 == V3) &&
                (H1 == B1) &&
                (H1 == B2);
        }

        static bool IsNotInUsed(int d)
        {
            for (int i = 0; i < Level; i++)
            {
                if (slots[i] == d)
                {
                    return false;
                }
            }
            return true;
        }

        static void ShowAnswer()
        {
            Console.WriteLine("{0}{1}{2}", slots[0], slots[1], slots[2]);
            Console.WriteLine("{0}{1}{2}", slots[3], slots[4], slots[5]);
            Console.WriteLine("{0}{1}{2}", slots[6], slots[7], slots[8]);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Solve();
            Console.WriteLine("No of Patterns Examined: {0}", NoOfPatterns);
            Console.WriteLine("No of Answers Found: {0}", NoOfAnswers);
            Console.ReadLine();
        }


    }
}
