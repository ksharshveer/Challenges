using System;

namespace Codeforces.PetyaAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            Console.WriteLine(CompareLexicographically(str1.ToLower(), str2.ToLower()));
        }

        private static int CompareLexicographically(string v1, string v2)
        {
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] < v2[i]) return -1;
                else if (v1[i] > v2[i]) return 1;
            }
            return 0;
        }
    }
}
