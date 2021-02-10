using System;

namespace Codeforces.Football
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(GetWinner(count));
        }

        private static string GetWinner(int matches)
        {
            string teamA = Console.ReadLine();
            string teamB = null;
            int teamACounter = 1;

            for (int i = 1; i < matches; i++)
            {
                var team = Console.ReadLine();
                if (team.Equals(teamA)) teamACounter += 1;
                else teamB ??= team;
            }

            if (teamACounter > Math.Floor((decimal)matches / 2)) return teamA;
            return teamB;
        }
    }
}
