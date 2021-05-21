using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.IncreaseAndDecrease
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int count, out List<int> nums);
            Console.WriteLine(MaxEqualElements(nums));
        }

        private static int MaxEqualElements(List<int> nums, int prevEqual=-1)
        {
            if (nums.Count == 1) return 1;

            nums.Sort();

            for (int i = 0; i < nums.Count / 2; i++)
            {
                // Equivalent to `nums.Count - 1 - i`
                Index j = ^(i + 1);
                if (nums[i] < nums[j])
                {
                    // End result from applying ai = ai + 1, aj = aj - 1 operations
                    // upto ai <= aj in a single step
                    int diff = nums[j] - nums[i];
                    int change = diff / 2;
                    nums[i] += change;
                    nums[j] -= change;
                }
            }

            int result;
            int eqNum;
            int halfInd = nums.Count / 2;
            if (nums.Count % 2 == 1)
            {
                result = nums.Where(n => n == nums[halfInd]).Count();
                eqNum = nums[halfInd];
            }
            else
            {
                var result1 = nums.Where(n => n == nums[halfInd]).Count();
                var result2 = nums.Where(n => n == nums[halfInd - 1]).Count();
                result = Math.Max(result1, result2);
                eqNum = result == result1 ? nums[halfInd] : nums[halfInd - 1];
            }

            var nonResultCount = nums.Count - result;
            if (nonResultCount > 1) result += (nums.Count - result) - 1;

            // Debug statements
            //nums.ForEach(n => Console.Write(n + ", "));
            //Console.WriteLine();

            if (result == prevEqual) return result;
            return MaxEqualElements(nums, result);
        }

        private static void ReadInput(out int count, out List<int> nums)
        {
            count = Convert.ToInt32(Console.ReadLine());

            nums = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToList();
        }
    }
}
