using System;
using System.Linq;

namespace Codeforces.OldTvsSale
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            var (numOfTvs, tvsCarryLimit) = (input[0], input[1]);

            var tvPrices = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            Console.WriteLine(MaximumProfitFromTakingOldTvs(numOfTvs, tvsCarryLimit, tvPrices));

        }

        private static int MaximumProfitFromTakingOldTvs(int numOfTvs, int tvsCarryLimit, int[] tvPrices)
        {
            Array.Sort(tvPrices);

            int tvsTaken = 0;
            int negativeMoneySum = 0;
            int index = 0;
            while (tvsTaken < tvsCarryLimit)
            {
                if (tvPrices[index] >= 0) break;
                negativeMoneySum -= tvPrices[index];
                index += 1;
                tvsTaken += 1;
            }

            return Math.Abs(negativeMoneySum);
        }
    }
}
