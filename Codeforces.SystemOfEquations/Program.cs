using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.SystemOfEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();
            var (n, m) = (input[0], input[1]);

            Console.WriteLine(CountSolutionPairs(n, m, out List<(int, int)> pairs));
        }

        private static int CountSolutionPairs(int n, int m, out List<(int, int)> pairs)
        {
            int aMax = (int)Math.Floor(Math.Sqrt(n));
            int bMax = (int)Math.Floor(Math.Sqrt(m));

            var aRange = Enumerable.Range(0, aMax+1);
            var bRange = Enumerable.Range(0, bMax+1);

            pairs = new List<(int, int)>();
            foreach (var a in aRange)
            {
                foreach (var b in bRange)
                {
                    if (SolvesEquation(n, m, a, b)) pairs.Add((a, b));
                }
            }

            return pairs.Count;
        }

        private static bool SolvesEquation(int n, int m, int a, int b)
        {
            bool valid = true;
            if ((int)Math.Pow(a, 2) != n - b) valid = false;
            if ((int)Math.Pow(b, 2) != m - a) valid = false;
            return valid;
        }
    }
}
