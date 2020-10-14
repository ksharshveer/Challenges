using System;

namespace Codeforces.WordCorrector
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Solve(input);
        }

        private static void Solve(string input)
        {
            int lowerCaseCount = 0;
            int half = (int) Math.Ceiling(input.Length / (2.0));
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLower(input[i])) lowerCaseCount += 1;
            }

            if (lowerCaseCount >= half) Console.WriteLine(input.ToLower());
            else Console.WriteLine(input.ToUpper());
        }

    }
}
