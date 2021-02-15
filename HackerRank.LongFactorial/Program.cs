using System;
using System.Collections.Generic;
using System.Numerics;

namespace HackerRank.LongFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetLongFactorial(25));
        }

        private static Dictionary<string, BigInteger> FactorialsCache = new Dictionary<string, BigInteger>();
        private static BigInteger GetLongFactorial(BigInteger number)
        {
            if (number == 0 || number == 1) return 1;
            if (FactorialsCache.ContainsKey(number.ToString()))
            {
                Console.Write('.');
                return FactorialsCache[number.ToString()];
            }
            FactorialsCache[number.ToString()] = number * GetLongFactorial(number - 1);
            return FactorialsCache[number.ToString()];
        }
    }
}
