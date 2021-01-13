using System;
using System.Collections.Generic;

namespace Codeforces.BoyOrGirl
{
    class Program
    {
        static void Main(string[] args)
        {
            const string OutputForGirl = "CHAT WITH HER!";
            const string OutputForBoy = "IGNORE HIM!";

            var name = Console.ReadLine();
            if (IsMale(ref name)) Console.WriteLine(OutputForBoy);
            else Console.WriteLine(OutputForGirl);
        }

        private static bool IsMale(ref string name)
        {
            HashSet<char> chars = new HashSet<char>();
            for (int i = 0; i < name.Length; i++)
            {
                if (!chars.Contains(name[i])) chars.Add(name[i]);
            }

            if (chars.Count % 2 == 1) return true;
            return false;
        }
    }
}
