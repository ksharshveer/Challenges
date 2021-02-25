using System;
using System.Text.RegularExpressions;

namespace RegexProblems
{
    class Codeforces_ChatRoom : IRunnable
    {
        public void Run()
        {
            var line = Console.ReadLine();
            if (Solve(line)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }

        private static bool Solve(string line)
        {
            var helloPattern = new Regex(@"h\w*e\w*l\w*l\w*o", RegexOptions.Compiled);
            return helloPattern.IsMatch(line);
        }
    }
}
