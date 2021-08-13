using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.RankList
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out List<(int ProblemsSolved, int PenaltyTime)> teams, out int kthRank);

            var rankedTeams = teams.OrderBy(t => t.PenaltyTime)  // First, sort by penalty time
                .OrderByDescending(t => t.ProblemsSolved)  // only then sort descending by problems solved
                .ToList();

            var kthTeam = rankedTeams.ElementAt(kthRank - 1);  // kthRank is between 1 and 50, so the -1
            var kthTeamsCount = rankedTeams.Count(t => t == kthTeam);

            Console.WriteLine(kthTeamsCount);
        }

        private static void ReadInput(out List<(int ProblemsSolved, int PenaltyTime)> teams, out int kthRank)
        {
            var nums = ReadRow_Integers();
            int teamsCount = nums[0];
            kthRank = nums[1];

            teams = new List<(int ProblemsSolved, int PenaltyTime)>();
            for (int i = 0; i < teamsCount; i++)
            {
                nums = ReadRow_Integers();
                teams.Add((nums[0], nums[1]));
            }
        }

        public static int[] ReadRow_Integers()
        {
            return Console.ReadLine().Split()
                .Select(num => Convert.ToInt32(num))
                .ToArray();
        }


    }
}
