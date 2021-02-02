using System;
using System.Linq;

namespace Codeforces.Reconnaissance
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(Console.ReadLine());
            var heights = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            ReconnaissancePair(heights, out int soldier1, out int soldier2);
            Console.WriteLine($"{soldier1} {soldier2}");
        }

        private static void ReconnaissancePair(int[] heights, out int soldier1, out int soldier2)
        {
            int minDiff = Math.Abs(heights[0] - heights[heights.Length - 1]);
            soldier2 = 1;
            soldier1 = heights.Length;

            if (minDiff == 0) return;

            for (int i = 0; i < heights.Length - 1; i++)
            {
                int newMin = Math.Abs(heights[i] - heights[i + 1]);
                if (newMin == 0)
                {
                    soldier1 = i + 1;
                    soldier2 = i + 2;
                    return;
                }
                else if (newMin < minDiff)
                {
                    minDiff = newMin;
                    soldier1 = i + 1;
                    soldier2 = i + 2;
                }
            }
        }
    }
}
