using System;
using System.Collections.Generic;

namespace Codeforces.ComparingStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out string s1, out string s2);

            if (AreEqualSwappingTwoCharacters(s1, s2)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }

        private static bool AreEqualSwappingTwoCharacters(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            List<(int Index, char C1, char C2)> unmatchedParts = new List<(int, char, char)>();
            for (int i=0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    unmatchedParts.Add((i, s1[i], s2[i]));
                }
            }

            if (unmatchedParts.Count != 2) return false;

            var (p1, p2) = (unmatchedParts[0], unmatchedParts[1]);
            if (p1.C1 != p2.C2 || p1.C2 != p2.C1) return false;

            return true;
        }

        private static void ReadInput(out string s1, out string s2)
        {
            s1 = Console.ReadLine();
            s2 = Console.ReadLine();
        }
    }
}
