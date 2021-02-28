using System;
using System.Linq;

namespace Codeforces.PashamkAndFlowers
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = Console.ReadLine();
            var beauties = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            FindMinMax(beauties, out int min, out int max);
            long ways = FindMaxWays(beauties, min, max);
            Console.WriteLine($"{max - min} {ways}");
        }

        private static void FindMinMax(int[] beauties, out int min, out int max)
        {
            min = max = beauties[0];
            foreach (var num in beauties)
            {
                if (num < min) min = num;
                if (num > max) max = num;
            }
        }

        private static long FindMaxWays(int[] beauties, int min, int max)
        {
            long bCount, minCount, maxCount;
            bCount = beauties.Length;
            minCount = maxCount = 0;
            foreach (var num in beauties)
            {
                if (num == min) minCount++;
                if (num == max) maxCount++;
            }
            if (min != max) return minCount * maxCount;
            return bCount * (bCount - 1) / 2;
        }
    }
}
