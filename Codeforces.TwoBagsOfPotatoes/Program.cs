using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codeforces.TwoBagsOfPotatoes
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int potatoesIn2ndBag, out int divisorK, out int potatoesLimit);
            if (PossiblePotatoesIn1stBag(potatoesIn2ndBag, divisorK, potatoesLimit, out List<int> potatoCounts))
            {
                StringBuilder sb = new StringBuilder();
                foreach (var pCount in potatoCounts)
                {
                    sb.Append(pCount);
                    sb.Append(" ");
                }

                var result = sb.ToString().Trim();
                Console.WriteLine(result);
            }
            else Console.WriteLine("-1");
        }

        private static bool PossiblePotatoesIn1stBag(int potatoesIn2ndBag, int divisorK, int potatoesLimit, out List<int> potatoCounts)
        {
            potatoCounts = new List<int>();

            if (potatoesIn2ndBag >= potatoesLimit) return false;

            var modded = potatoesIn2ndBag % divisorK;
            var possibleFirst = divisorK - modded;
            var potatoesSum = possibleFirst + potatoesIn2ndBag;
            if (potatoesSum <= potatoesLimit && potatoesSum % divisorK == 0) potatoCounts.Add(possibleFirst);

            if (potatoCounts.Count <= 0) return false;

            int nextCount = potatoCounts[0] + divisorK;
            while (nextCount + potatoesIn2ndBag <= potatoesLimit)
            {
                potatoCounts.Add(nextCount);
                nextCount += divisorK;
            }

            return true;
        }

        private static void ReadInput(out int potatoesIn2ndBag, out int divisorK, out int potatoesLimit)
        {
            var numbers = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            potatoesIn2ndBag = numbers[0];
            divisorK = numbers[1];
            potatoesLimit = numbers[2];
        }
    }
}
