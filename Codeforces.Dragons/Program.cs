using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.Dragons
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadProblem(out uint strength, out List<uint> enemyStrengths, out List<uint> winBonusStrengths);

            if (CanClearLevel(strength, enemyStrengths, winBonusStrengths))
                Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }

        private static bool CanClearLevel(uint strength, List<uint> enemyStrengths, List<uint> winBonusStrengths)
        {
            // Ordering by weakest enemies first
            var pairs = Enumerable.Zip(enemyStrengths, winBonusStrengths)
                .OrderBy(tup => tup.First)
                .ToList();

            var heroStrength = strength;
            bool res = true;
            foreach (var p in pairs)
            {
                // Level fail. Can't defeat weakest enemy
                if (heroStrength <= p.First)
                {
                    res = false;
                    break;
                }
                // Strength bonus for defeating this enemy
                else heroStrength += p.Second;
            }

            return res;
        }

        private static void ReadProblem(out uint strength, out List<uint> enemyStrengths, out List<uint> winBonusStrengths)
        {
            var input = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToUInt32(s))
            .ToArray();

            strength = input[0];
            enemyStrengths = new List<uint>();
            winBonusStrengths = new List<uint>();

            for (int i = 0; i < input[1]; i++)
            {
                var xi_yi = Console.ReadLine()
                .Split(' ')
                .Select(s => Convert.ToUInt32(s))
                .ToArray();

                enemyStrengths.Add(xi_yi[0]);
                winBonusStrengths.Add(xi_yi[1]);
            }
        }

    }
}
