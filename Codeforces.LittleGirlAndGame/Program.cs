using System;
using System.Collections.Generic;

namespace Codeforces.LittleGirlAndGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            Console.WriteLine(FindWinningPlayer(str));
        }

        private static string FindWinningPlayer(string str)
        {
            HashSet<char> chars = new HashSet<char>();
            foreach (var c in str)
            {
                if (chars.Contains(c)) chars.Remove(c);
                else chars.Add(c);
            }

            if (chars.Count != 0 && chars.Count % 2 == 0) return "Second";
            return "First";
        }
    }
}
