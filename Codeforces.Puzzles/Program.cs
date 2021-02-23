using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int studentsCount, out int puzzlesCount, out List<int> puzzles);

            Console.WriteLine(Solve(studentsCount, puzzles));
        }

        private static int Solve(int studentsCount, List<int> puzzles)
        {
            var orderedPuzzles = puzzles.OrderBy(i => i).ToArray();

            int newDiff;
            int diff = orderedPuzzles[studentsCount - 1] - orderedPuzzles[0];
            for (var (i, j) = (1, studentsCount); j < orderedPuzzles.Length; i++, j++)
            {
                newDiff = orderedPuzzles[j] - orderedPuzzles[i];
                if (newDiff < diff) diff = newDiff;
            }

            return diff;
        }

        private static void ReadInput(out int studentsCount, out int puzzlesCount, out List<int> puzzles)
        {
            var input = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            (studentsCount, puzzlesCount) = (input[0], input[1]);

            puzzles = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToList();
        }
    }
}
