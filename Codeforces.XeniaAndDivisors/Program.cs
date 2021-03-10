using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.XeniaAndDivisors
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int count, out List<int> numbers);
            if (GroupsExist(numbers, out List<List<int>> groups))
            {
                foreach (var g in groups)
                {
                    Console.WriteLine(string.Join(" ", g.OrderBy(n => n)));
                }
            }
            else Console.WriteLine("-1");
        }

        private static bool GroupsExist(List<int> numbers, out List<List<int>> groups)
        {
            groups = new List<List<int>>();

            var numOfNums = new int[7];
            foreach (var num in numbers)
            {
                numOfNums[num-1]++;
            }

            var groupsCount = numOfNums.Count(n => n > 0);
            var onesCount = numOfNums[0];
            if (groupsCount <= 2 || onesCount == 0) return false;

            for (int i = 0; i < onesCount; i++)
            {
                if (numOfNums[0] > 0 && numOfNums[1] > 0)
                {
                    var found = false;
                    if (numOfNums[3] > 0)
                    {
                        found = true;
                        numOfNums[3]--;
                        groups.Add(new List<int> { 1, 2, 4 });
                    }
                    else if (numOfNums[5] > 0)
                    {
                        found = true;
                        numOfNums[5]--;
                        groups.Add(new List<int> { 1, 2, 6 });
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
                    groups.Add(new List<int> { 1, 3, 6 });
                }
            }

            if (numOfNums.Count(n => n > 0) > 0) return false;

            return true;
        }

        private static void ReadInput(out int count, out List<int> numbers)
        {
            count = Convert.ToInt32(Console.ReadLine());
            numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(s => Convert.ToInt32(s))
                    .ToList();
        }
    }
}
