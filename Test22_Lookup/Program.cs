using System;
using Benchmarking;
using System.Collections.Generic;
using static Test22.Month;

namespace Test22
{
    enum Month
    {
        JAN = 0,
        FEB,
        MAR,
        APR,
        MAY,
        JUN,
        JUL,
        AUG,
        SEP,
        OCT,
        NOV,
        DEC
    }

    class Program
    {
        static bool isLeapYear(int year)
        {
            if ((year % 4) != 0) return false;
            if ((year % 100) != 0) return true;
            if ((year % 400) != 0) return false;
            return true;
        }

        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000_000;

            int[] NoOfDays = new int[]
            {
                31, isLeapYear(DateTime.Now.Year) ? 29: 28,31,30,31,30,31,31,30,31,30,31
            };

            Dictionary<Month, int> NoOfDaysDict = new Dictionary<Month, int>()
            {
                {JAN, 31},
                {FEB, isLeapYear(DateTime.Now.Year)?29:28},
                {MAR, 31},
                {APR, 30},
                {MAY, 31},
                {JUN, 30},
                {JUL, 31},
                {AUG, 31},
                {SEP, 30},
                {OCT, 31},
                {NOV, 30},
                {DEC, 31}
            };

            Profiler.Profile("Swtich Case", NoOfIteration, () =>
            {
                int totalDays = 0;
                foreach (Month m in Enum.GetValues(typeof(Month)))
                {
                    switch (m)
                    {
                        case FEB:
                            totalDays += isLeapYear(DateTime.Now.Year) ? 29 : 28;
                            break;
                        case APR:
                        case JUN:
                        case SEP:
                        case NOV:
                            totalDays += 30;
                            break;
                        default:
                            totalDays += 31;
                            break;
                    }
                }
            });

            Profiler.Profile("Lookup with Dictionary", NoOfIteration, () =>
            {
                int totalDays = 0;
                foreach (Month m in Enum.GetValues(typeof(Month)))
                {
                    totalDays = NoOfDaysDict[m];
                }
            });

            Profiler.Profile("Lookup with Array", NoOfIteration, () =>
            {
                int totalDays = 0;
                foreach (Month m in Enum.GetValues(typeof(Month)))
                {
                    totalDays = NoOfDays[(int)m];
                }
            });
        }
    }
}
