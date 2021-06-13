using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Codeforces.BoysAndGirls
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int n, out int m);

            var result = GetBoyGirlSequence(n, m);
            File.WriteAllText("output.txt", result);
        }

        private static string GetBoyGirlSequence(int n, int m)
        {
            StringBuilder sb = new StringBuilder();

            int max = Math.Max(n, m);
            int abs = Math.Abs(n - m);

            char first, other;
            if (max == n)
            {
                first = 'B';
                other = 'G';
            }
            else
            {
                first = 'G';
                other = 'B';
            }

            MakeSequence(sb, max, max - abs, first, other);

            return sb.ToString();
        }

        private static void MakeSequence(StringBuilder sb, int max, int min, char first, char other)
        {
            while (max > 0)
            {
                sb.Append(first);
                max -= 1;
                if (min > 0)
                {
                    sb.Append(other);
                    min -= 1;
                }
            }
        }

        private static void ReadInput(out int n, out int m)
        {
            var input = File.ReadAllText("input.txt");
            var numbers = input
                .Trim()
                .Split()
                .Select(s => Convert.ToInt32(s))
                .ToArray();

            if (numbers.Length != 2)
                throw new ArgumentException("Invalid input! Expected two space separated integers.");

            n = numbers[0];
            m = numbers[1];
        }
    }
}
