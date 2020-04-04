using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PairSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            List<int> ints = new List<int>(1000000);
            for (int k = 0; k <= ints.Capacity-1; k++)
            {
                ints.Add(r.Next());
            }
            // Gurantee at least one pair sum
            int pairSum = 55533555;
            ints.Add(12321234);
            ints.Add(43212321);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var pair = GetPairSum(ints, pairSum);
            stopwatch.Stop();
            foreach (int item in pair)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Executed in {stopwatch.ElapsedMilliseconds} ms " +
                $"or {stopwatch.ElapsedTicks} ticks");
            
        }

        static int[] GetPairSum(List<int> ints, int sum)
        {
            int first = 0, firstIndex = -1;
            int second = 0, secondIndex = -1;

            // Much slower if used hashtable to help track indexes, although,
            // dictionary is suitable having hashset equivalent performance
            HashSet<int> seenInts = new HashSet<int>();
            foreach (int num in ints)
            {
                seenInts.Add(num);
            }

            for (int i = 0; i < ints.Count; i++)
            {
                if (seenInts.Contains(sum - ints[i]))
                {
                    first = ints[i];
                    firstIndex = i;
                    second = sum - ints[i];
                    break;
                }
            }

            secondIndex = ints.FindIndex(0, ints.Count, num => num == second);

            if (firstIndex == -1 || secondIndex == -1) return null;

            if (firstIndex <= secondIndex) return new int[] { first, second };
            else return new int[] { second, first };
        }

        private static int[] GetPairSumBrute(List<int> ints, int pairSum)
        {
            int first = 0;
            int second = 0;

            for (int i = 0; i < ints.Count; i++)
            {
                for (int j = i; j < ints.Count; j++)
                {
                    if (ints[i] + ints[j] == pairSum)
                    {
                        first = ints[i];
                        second = ints[j];
                        break;
                    }
                }
            }
            return new int[] { first, second };
        }

    }
}
