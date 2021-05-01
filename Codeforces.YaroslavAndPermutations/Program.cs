using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.YaroslavAndPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int count, out List<int> numbers);
            if (CanHaveDistinctNeighbours(numbers)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }

        private static bool CanHaveDistinctNeighbours(List<int> numbers, int conflictsResolved=0)
        {
            if (numbers.Count == 1) return true;

            if (!IsDistinct(numbers, out int conflictIndex))
            {
                // Limiting recursion depth
                if (conflictsResolved > numbers.Count) return false;

                if (CanInsertDistinct(numbers, conflictIndex))
                {
                    conflictsResolved++;
                    // Debug statements
                    // Console.WriteLine("Conflict at index: " + conflictIndex);
                    // numbers.ForEach(n => Console.Write(n + " "));
                    // Console.WriteLine();
                    return CanHaveDistinctNeighbours(numbers, conflictsResolved);
                }
                else return false;
            }

            return true;
        }

        private static bool CanInsertDistinct(List<int> numbers, int conflictIndex)
        {
            // Note! Only neighbouring swaps are allowed

            // Inserting to the left of conflict point
            int itemToInsert = numbers[conflictIndex];

            for (int i = conflictIndex-1; i > 0; i--)
            {
                if (itemToInsert != numbers[i] && itemToInsert != numbers[i-1])
                {
                    numbers.RemoveAt(conflictIndex);
                    numbers.Insert(i, itemToInsert);
                    return true;
                }
            }
            if (itemToInsert != numbers[0])
            {
                numbers.RemoveAt(conflictIndex);
                numbers.Insert(0, itemToInsert);
                return true;
            }

            // Inserting to the right of conflict point
            for (int i = conflictIndex+1; i < numbers.Count-1; i++)
            {
                if (itemToInsert != numbers[i] && itemToInsert != numbers[i+1])
                {
                    numbers.RemoveAt(conflictIndex);
                    numbers.Insert(i, itemToInsert);
                    return true;
                }
            }
            if (itemToInsert != numbers[^1])
            {
                numbers.RemoveAt(conflictIndex);
                numbers.Add(itemToInsert);
                return true;
            }

            // Couldn't find a valid insert point
            return false;
        }

        private static bool IsDistinct(List<int> numbers, out int conflictIndex)
        {
            if (numbers is null) throw new ArgumentNullException(nameof(numbers));
            if (numbers.Count < 2) throw new ArgumentException("Must have at least two elements!", nameof(numbers));

            int prev = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                conflictIndex = i;
                if (numbers[i] == prev) return false;
                prev = numbers[i];
            }

            conflictIndex = -1;
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
