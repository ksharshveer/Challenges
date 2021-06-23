using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.EasyNumberChallenge
{
    class Program
    {
        const int TwoToThirty = 1073741824;
        readonly static Dictionary<int, int> NumOfDivisorsCache = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            ReadInput(out int a, out int b, out int c);

            Console.WriteLine(DivisorsSum(a, b, c, mod: TwoToThirty));
        }

        private static long DivisorsSum(int a, int b, int c, int mod = -1)
        {
            long sum = 0L;

            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    for (int k = 1; k <= c; k++)
                    {
                        var num = i * j * k;
                        if (!NumOfDivisorsCache.ContainsKey(num))
                        {
                            var result = NumOfDivisors(i * j * k);
                            NumOfDivisorsCache[num] = result;
                        }
                        sum += (long)NumOfDivisorsCache[num];
                    }
                }
            }

            return sum % mod;
        }

        private static int NumOfDivisors(int num)
        {
            if (num < 1) throw new ArgumentException();

            if (num == 1) return 1;

            int divisorsCount = 0;
            int max_iteration_number = (int)Math.Sqrt(num);

            for (int i = 1; i <= max_iteration_number; i++)
            {
                // If `i` is a divisor, then so is `num/i`
                if (num % i == 0)
                {
                    divisorsCount++;
                    if (num / i != i) divisorsCount++;
                }
            }

            return divisorsCount;
        }

        private static void ReadInput(out int a, out int b, out int c)
        {
            var numbers = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            a = numbers[0];
            b = numbers[1];
            c = numbers[2];
        }
    }
}
