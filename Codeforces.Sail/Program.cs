using System;
using System.Linq;

namespace Codeforces.Sail
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int time, out (int, int) source, out (int, int) destination, out string windDirections);
            Console.WriteLine(TimeToReachDestination(time, source, destination, windDirections));
        }

        private static int TimeToReachDestination(int time, (int, int) source, (int, int) destination, string windDirections)
        {
            int minTime = 0;
            int horDiff = destination.Item1 - source.Item1;
            int verDiff = destination.Item2 - source.Item2;

            for (int i = 0; i < (time <= windDirections.Length ? time : windDirections.Length); i++)
            {
                minTime++;
                var direction = windDirections[i];
                if (direction == 'E' && horDiff > 0) horDiff--;
                else if (direction == 'W' && horDiff < 0) horDiff++;
                else if (direction == 'N' && verDiff > 0) verDiff--;
                else if (direction == 'S' && verDiff < 0) verDiff++;
                if (horDiff == 0 && verDiff == 0) break;
            }

            return (horDiff == 0 && verDiff == 0) ? minTime : -1;
        }

        private static void ReadInput(out int time, out (int, int) source, out (int, int) destination, out string windDirections)
        {
            var numbers = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            time = numbers[0];
            source = (numbers[1], numbers[2]);
            destination = (numbers[3], numbers[4]);

            windDirections = Console.ReadLine();
        }
    }
}
