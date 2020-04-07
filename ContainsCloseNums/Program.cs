using System;
using System.Collections.Generic;

namespace ContainsCloseNums
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int> { 0, 1, 2, 3, 5, 2 };

            // Find indices, i & j such that nums[i] == nums[j],
            // and abs(i-j) <= k
            int k = 3;

            var res = GetCloseNumsIndices(nums, k);
            if (res is null) Console.WriteLine("No close numbers found!");
            else
            { 
                foreach (var index in res)
                {
                    Console.Write(index + " ");
                }
            }
        }

        private static int[] GetCloseNumsIndices(List<int> nums, int k)
        {
            // Keep track of numbers, and their indices in order for duplicate numbers
            Dictionary<int, List<int>> numsWithListedIndices = new Dictionary<int, List<int>>();
            for (int x = 0; x < nums.Count; x++)
            {
                if (numsWithListedIndices.ContainsKey(nums[x]))
                {
                    numsWithListedIndices[nums[x]].Add(x);
                }
                else
                {
                    numsWithListedIndices[nums[x]] = new List<int> { x };
                }
            }

            // Filter the dictionary to exculde non relevant results
            // Remove all numbers which are unique
            foreach (var pair in numsWithListedIndices)
            {
                // pair.Value is a list of unique integers in ascending order
                if (pair.Value.Count == 1) numsWithListedIndices.Remove(pair.Key);
            }

            // No duplicate numbers exist
            if (numsWithListedIndices.Count == 0) return null;

            // Find the first indices pair i & j, satisfying close numbers criteria
            foreach (var pair in numsWithListedIndices)
            {
                var indices = pair.Value;
                for (int i = 0; i < indices.Count-1; i++)
                {
                    if (Math.Abs(indices[i] - indices[i+1]) <= k)
                    {
                        return new int[] { indices[i], indices[i+1] };
                    }
                }
            }

            // There are duplicate nums, but one of our criteria
            // for close numbers was not satisfied
            return null;
        }
    }
}
