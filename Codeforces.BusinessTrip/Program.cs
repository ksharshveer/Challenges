using System;
using System.Linq;

namespace Codeforces.BusinessTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            int minGrowth = Convert.ToInt32(Console.ReadLine());
            var growthsGivenMonth = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            // Solution
            int months = MonthsToWaterForMinGrowth(minGrowth, growthsGivenMonth);
            Console.WriteLine(months);
        }

        private static int MonthsToWaterForMinGrowth(int minGrowth, int[] growthsGivenMonth)
        {
            int monthsWatered = 0;
            int reachedGrowth = 0;
            foreach (var g in growthsGivenMonth.OrderByDescending(x => x))
            {
                if (reachedGrowth >= minGrowth) break;
                reachedGrowth += g;
                monthsWatered++;
            }
            return reachedGrowth >= minGrowth ? monthsWatered : -1;
        }
    }
}
