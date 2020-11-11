using System;
using System.Text;

namespace Codeforces.PerfectPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(Console.ReadLine()));
        }

        private static string Solve(string input)
        {
            int n = Convert.ToInt32(input);
            if (n % 2 == 1) return "-1";

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < n; i += 2)
            {
                stringBuilder.Append($"{i + 2} {i + 1} ");
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            return stringBuilder.ToString();
        }
    }
}
