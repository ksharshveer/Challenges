using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexProblems
{
    class Codeforces_StringTask : IRunnable
    {
        public void Run()
        {
            var line = Console.ReadLine();
            Solve(line);
        }

        private static void Solve(string line)
        {
            var vowelsPat = new Regex(@"[aeiouyAEIOUY]", RegexOptions.Compiled);
            var sb = new StringBuilder();
            foreach (var c in line)
            {
                if (!vowelsPat.IsMatch(c.ToString()))
                {
                    sb.Append('.');
                    sb.Append(char.ToLower(c));
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
