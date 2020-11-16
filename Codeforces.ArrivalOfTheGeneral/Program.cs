using System;
using System.Linq;

namespace Codeforces.ArrivalOfTheGeneral
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = Console.ReadLine();
            int[] input = Console.ReadLine()
                .Split()
                .Select(h => Convert.ToInt32(h))
                .ToArray();

            Console.WriteLine(Solve(input));
        }

        private static int Solve(int[] heights)
        {
            if (heights.Length < 2) return 0;

            int swapsNeeded = 0;

            int curMax = -1;
            int curMin = int.MaxValue;
            int maxInd = -1;
            int minInd = -1;

            for (int i = 0; i < heights.Length; i++)
            {
                // Finding index of first tallest soldier
                if (heights[i] > curMax)
                {
                    curMax = heights[i];
                    maxInd = i;
                }

                // Finding index of last shortest soldier
                if (heights[i] <= curMin)
                {
                    curMin = heights[i];
                    minInd = i;
                }
            }

            // If tallest and shortest height soldiers end up in a swap with
            // each other, this will result in overall 1 less swap.
            if (minInd < maxInd) swapsNeeded -= 1;

            // Swaps needed to get tallest soldier to first position
            swapsNeeded += maxInd;

            // Swaps needed to get shortest soldier to last position
            swapsNeeded += (heights.Length - 1) - minInd;

            return swapsNeeded;
        }
    }
}
