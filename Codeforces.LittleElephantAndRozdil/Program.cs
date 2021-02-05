using System;
using System.Linq;

namespace Codeforces.LittleElephantAndRozdil
{
    class Program
    {
        const string NotTravellingMsg = "Still Rozdil";

        static void Main(string[] args)
        {
            int citiesCount = Convert.ToInt32(Console.ReadLine());

            var travelDistances = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            if (ShouldTravel(citiesCount, travelDistances, out int townNumber))
            {
                Console.WriteLine(townNumber);
            }
            else Console.WriteLine(NotTravellingMsg);

        }

        private static bool ShouldTravel(int citiesCount, int[] travelDistances, out int townNumber)
        {
            townNumber = 1;
            int minTownDistance = travelDistances.Min();
            int minCount = travelDistances.Count((d) => d == minTownDistance);
            if (minCount > 1) return false;

            // Find town number (travel distance + 1)
            for (int i = 0; i < citiesCount; i++)
            {
                if (travelDistances[i] != minTownDistance) townNumber += 1;
                else break;
            }

            return true;
        }
    }
}
