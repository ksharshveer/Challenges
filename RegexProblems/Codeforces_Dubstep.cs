using System;
using System.Text.RegularExpressions;

namespace RegexProblems
{
    class Codeforces_Dubstep: IRunnable
    {
        public void Run()
        {
            const string dubWord = "WUB";
            var dubSong = Console.ReadLine();
            var origSong = RestoreDub(dubSong, dubWord);
            Console.WriteLine(origSong);
        }

        private static string RestoreDub(string dubSong, string dubWord)
        {
            Regex exp = new Regex($@"({dubWord})+", RegexOptions.Compiled);
            var res = exp.Replace(dubSong, " ");
            return res.Trim();
        }

    }
}

