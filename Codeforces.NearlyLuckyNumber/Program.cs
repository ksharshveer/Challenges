using System;
using System.Collections.Generic;

namespace Codeforces.NearlyLuckyNumber
{
    class Program
    {
        static HashSet<char> luckyNumbers = new HashSet<char> { '4', '7' };

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(Solve(ref input));
        }

        private static string Solve(ref string input)
        {

            var luckyNumsCount = 0;
            foreach (var c in input)
            {
                if (luckyNumbers.Contains(c)) luckyNumsCount++;
            }

            if (luckyNumbers.Contains(luckyNumsCount.ToString()[0])) return "YES";
            return "NO";
        }
    }
}
