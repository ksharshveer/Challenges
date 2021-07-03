using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.PythagoreanTheoremII
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CountSatisfyingPythagoreans(num));
        }

        private static int CountSatisfyingPythagoreans(int num)
        {
            if (num < 5) return 0;

            // This will help access if `c^2` is present quickly
            // It will also help avoid repeated square computations
            HashSet<int> squares = new HashSet<int>();
            for (int i = 1; i <= num; i++)
            {
                var square = i * i;
                if (!squares.Contains(square)) squares.Add(square);
            }

            int count = 0;
            var sortedSquares = squares.OrderBy(i => i).ToArray();

            for (int i = 0; i < sortedSquares.Length; i++)
            {
                // Starting `j` from `i` prevents duplicates which were already found, like
                // `x + y = z` and `y + x = z`, where x, y, and z are respective squares of a, b, and c
                for (int j = i; j < sortedSquares.Length; j++)
                {
                    var sum = sortedSquares[i] + sortedSquares[j];
                    if (squares.Contains(sum))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
