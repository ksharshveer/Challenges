using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.XeniaAndDivisors
{
    class Program
    {
        static readonly List<string> PossibleGroups = new List<string> { "1 2 4", "1 2 6", "1 3 6" };

        static void Main(string[] args)
        {
            ReadInput(out int count, out IEnumerable<int> numbers);

            if (GroupsExist(numbers, out int[] possibleGroupsCounts))
            {
                for (int g = 0; g < possibleGroupsCounts.Length; g++)
                {
                    for (int i = 0; i < possibleGroupsCounts[g]; i++)
                    {
                        Console.WriteLine(PossibleGroups[g]);
                    }
                }
            }
            else Console.WriteLine("-1");
        }

        private static bool GroupsExist(IEnumerable<int> numbers, out int[] possibleGroupsCounts)
        {
            possibleGroupsCounts = new int[3];

            // Just counting numbers. 1st array element counts occurence of 1, and so on
            var numOfNums = new int[7];
            foreach (var num in numbers)
            {
                numOfNums[num-1]++;
            }

            // Infeasible conditions
            var groupsCount = numOfNums.Count(n => n > 0);
            var onesCount = numOfNums[0];
            if (groupsCount <= 2 || onesCount == 0) return false;

            // Possible solutions
            for (int i = 0; i < onesCount; i++)
            {
                if (numOfNums[0] > 0 && numOfNums[1] > 0)
                {
                    var found = false;
                    if (numOfNums[3] > 0)
                    {
                        found = true;
                        numOfNums[3]--;
                        possibleGroupsCounts[0] += 1;
                    }
                    else if (numOfNums[5] > 0)
                    {
                        found = true;
                        numOfNums[5]--;
                        possibleGroupsCounts[1] += 1;
                    }
                    if (found)
                    {
                        numOfNums[0]--;
                        numOfNums[1]--;
                    }
                }

                if (numOfNums[0] > 0 && numOfNums[2] > 0 && numOfNums[5] > 0)
                {
                    numOfNums[0]--;
                    numOfNums[2]--;
                    numOfNums[5]--;
                    possibleGroupsCounts[2] += 1;
                }
            }

            // Just confirming that if solutions exists, no ungrouped items were left
            if (numOfNums.Count(n => n > 0) > 0) return false;

            return true;
        }

        private static void ReadInput(out int count, out IEnumerable<int> numbers)
        {
            count = Convert.ToInt32(Console.ReadLine());
            numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(s => Convert.ToInt32(s));
        }
    }
}
