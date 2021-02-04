using System;
using System.Linq;

namespace Codeforces.EvenOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(l => Convert.ToUInt64(l))
                .ToArray();

            ulong n = input[0];
            ulong k = input[1];

            Console.WriteLine(GetNumberInEvenOdds(n, k));
        }

        /// <summary>
        /// Gets number at position k in sequence made of odd numbers from
        /// 1 to n, then even numbers from 1 to n
        /// </summary>
        private static ulong GetNumberInEvenOdds(ulong n, ulong k)
        {
            ulong firstHalf = n % 2 == 0 ? n / 2 : (n / 2) + 1;
            bool isOdd = k <= firstHalf;

            // Min number of times a 2 must be added regardless of
            // whether the final number is even or odd
            ulong customIndex = isOdd ? k - 1 : k - firstHalf - 1;

            return (2 * customIndex) + (ulong) (isOdd ? 1 : 2);
        }
    }
}
