using System;

namespace Codeforces.StonesOnTheTable
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = Console.ReadLine();
            var input = Console.ReadLine();
            Console.WriteLine(Solve(input));
        }

        private static int Solve(string input)
        {
            if (input.Length < 2) return 0;

            var minMoves = 0;
            //for (var (current, i) = (input[0], 1); i < input.Length; i++)
            char current = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == current) minMoves += 1;
                else current = input[i];
            }

            return minMoves;
        }
    }
}
