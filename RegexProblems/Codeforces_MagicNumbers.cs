using System;
using System.Text.RegularExpressions;

namespace RegexProblems
{
    class Codeforces_MagicNumbers : IRunnable
    {
        public void Run()
        {
            var input = Console.ReadLine();
            if (IsMagicNumber(input))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static bool IsMagicNumber(string input)
        {
            var pattern = new Regex(@"^((1)|(14)|(144))+$", RegexOptions.Compiled);
            return pattern.IsMatch(input);
        }
    }
}

