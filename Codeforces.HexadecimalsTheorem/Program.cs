using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.HexadecimalsTheorem
{
    class Program
    {

        const string UnsolvedMsg = "I'm too stupid to solve this problem";

        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());

            var fibNums = GetFibonacciNumbers(number);
            if (IsSumOfThree(number, fibNums, out List<int> threeNums)) 
            {
                threeNums.ForEach(n => Console.Write($"{n} "));
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(UnsolvedMsg);
            }
        }

        private static bool IsSumOfThree(int number, List<int> nums, out List<int> threeNums)
        {
            bool found = false;
            threeNums = new List<int>();

            var myFixedThirdsSet = nums
                .Select(n => number - n)
                .ToHashSet();

            foreach (var fib1 in nums)
            {
                foreach (var fib2 in nums)
                {
                    int sumOfTwo = fib1 + fib2;
                    if (myFixedThirdsSet.Contains(sumOfTwo))
                    {
                        threeNums.Add(fib1);
                        threeNums.Add(fib2);
                        threeNums.Add(number - sumOfTwo);
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            return found;
        }

        /// <summary>
        /// Get's a list of fibonacci number less than maxNum
        /// </summary>
        /// <param name="maxNum"></param>
        private static List<int> GetFibonacciNumbers(int maxNum)
        {
            List<int> nums = new List<int>();

            if (maxNum >= 0) nums.Add(0);
            if (maxNum >= 1)
            {
                nums.Add(1);
                nums.Add(1);
            }

            if (nums.Count < 2) return nums;

            int nextFib;
            while ((nextFib = nums[^1] + nums[^2]) < maxNum)
            {
                nums.Add(nextFib);
            }

            return nums;
        }
    }
}
