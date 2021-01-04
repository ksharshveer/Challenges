using System;
using System.Buffers;
using System.Linq;

namespace Codeforces.CodersPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = Console.ReadLine();
            var input = Console.ReadLine().Split()
                .Select(num => Convert.ToInt32(num))
                .ToArray();

            Console.WriteLine(GetBestWorstCount(input));
        }

        private static int GetBestWorstCount(int[] scores)
        {
            int bestWorstCount = 0;
            if (scores.Length == 1) return bestWorstCount;

            int lowestSoFar;
            int highestSoFar;
            lowestSoFar = highestSoFar = scores[0];

            foreach (var score in scores)
            {
                if (score < lowestSoFar)
                {
                    lowestSoFar = score;
                    bestWorstCount += 1;
                }
                if (score > highestSoFar)
                {
                    highestSoFar = score;
                    bestWorstCount += 1;
                }
            }

            return bestWorstCount;
        }
    }
}
