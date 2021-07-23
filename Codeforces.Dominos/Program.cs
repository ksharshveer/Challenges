using System;
using System.Linq;

namespace Codeforces.Dominos
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int n, out int[] upperHalves, out int[] lowerHalves);

            Console.WriteLine(SwapTimeToGet_DominoEvenHalfSums(upperHalves, lowerHalves));
        }

        private static int SwapTimeToGet_DominoEvenHalfSums(int[] upperHalves, int[] lowerHalves)
        {
            int time = -1;

            int upperSum = upperHalves.Sum();
            int lowerSum = lowerHalves.Sum();

            bool upperSumIsEven = upperSum % 2 == 0;
            bool lowerSumIsEven = lowerSum % 2 == 0;

            for (int i = 0; i < upperHalves.Length; i++)
            {
                if (upperSumIsEven && lowerSumIsEven)
                {
                    time = 0;
                    break;
                }
                else if (!upperSumIsEven && !lowerSumIsEven && Math.Abs(upperHalves[i] - lowerHalves[i]) % 2 == 1)
                {
                    //(upperHalves[i], lowerHalves[i]) = (lowerHalves[i], upperHalves[i]);
                    time = 1;
                    break;
                }
            }

            return time;
        }

        private static void ReadInput(out int n, out int[] upperHalves, out int[] lowerHalves)
        {
            n = Convert.ToInt32(Console.ReadLine());

            upperHalves = new int[n];
            lowerHalves = new int[n];
            int[] twoNums = new int[2];

            for (int i = 0; i < n; i++)
            {
                twoNums = Console.ReadLine().Split().Select(s => Convert.ToInt32(s)).ToArray();
                upperHalves[i] = twoNums[0];
                lowerHalves[i] = twoNums[1];
            }
        }
    }
}
