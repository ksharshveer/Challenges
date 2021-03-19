using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            var heading = Console.ReadLine();
            var text = Console.ReadLine();
            if (CanMakeText(heading, text)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }

        private static bool CanMakeText(string heading, string text)
        {
            var make = true;
            var textChars = new Dictionary<char, int>();

            // Profiling the characters that we need
            foreach (char c in text)
            {
                if (c != ' ')
                {
                    if (textChars.ContainsKey(c)) textChars[c] += 1;
                    else textChars[c] = 1;
                }
            }

            // Making our text from heading. Negatives will show leftover characters.
            foreach (char c in heading)
            {
                if (textChars.ContainsKey(c))
                {
                    textChars[c] -= 1;
                }
            }

            if (textChars.Values.Any(i => i > 0)) make = false;

            return make;
        }
    }
}
