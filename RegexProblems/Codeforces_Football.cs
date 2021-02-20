using System;
using System.Text.RegularExpressions;

namespace RegexProblems
{
    class Codeforces_Football : IRunnable
    {
        public void Run()
        {
            var line = Console.ReadLine();
            Solve(line);
        }

        private static void Solve(string line)
        {
            var pattern = new Regex(@"1{7,}|0{7,}", RegexOptions.Compiled);
            if (pattern.IsMatch(line)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
