using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.Airport
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int peopleCount, out int planesCount, out List<int> emptySeats);
            var (max, min) = Solve(peopleCount, emptySeats);
            Console.WriteLine($"{max} {min}");
        }

        private static (int, int) Solve(int peopleCount, List<int> emptySeats)
        {
            int min = CalculateMinCost(peopleCount, emptySeats);
            int max = CalculateMaxCost(peopleCount, emptySeats);

            return (max, min);
        }

        private static int CalculateMaxCost(int peopleCount, List<int> emptySeats)
        {
            int max = 0;
            int seatsTaken = 0;
            var rSortedSeats = emptySeats.OrderByDescending(n => n).ToArray();

            while (seatsTaken != peopleCount)
            {
                int i = 0;
                if (i == rSortedSeats.Length) break;
                int curMaxPrice = rSortedSeats[i];

                for (int j = 0; j < rSortedSeats.Length; j++)
                {
                    if (rSortedSeats[j] == curMaxPrice)
                    {
                        max += curMaxPrice;
                        seatsTaken += 1;
                        rSortedSeats[j] -= 1;
                    }
                    else
                    {
                        i += 1;
                        break;
                    }
                    if (seatsTaken == peopleCount) break;
                }
            }

            return max;
        }

        private static int CalculateMinCost(int peopleCount, List<int> emptySeats)
        {
            int min = 0;
            int seatsTaken = 0;
            var sortedSeats = emptySeats.OrderBy(n => n).ToArray();

            for (int i = 0; i < sortedSeats.Length; i++)
            {
                if (peopleCount - seatsTaken >= sortedSeats[i])
                {
                    seatsTaken += sortedSeats[i];
                    min += (sortedSeats[i] * (sortedSeats[i] + 1) / 2);
                }
                else
                {
                    int taken = peopleCount - seatsTaken;
                    seatsTaken += taken;
                    min += Enumerable.Range(sortedSeats[i] - taken + 1, taken).Sum();
                }

                if (seatsTaken == peopleCount) break;
            }

            return min;
        }

        private static void ReadInput(out int peopleCount, out int planesCount, out List<int> emptySeats)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(s => Convert.ToInt32(s))
                .ToArray();

            (peopleCount, planesCount) = (input[0], input[1]);
            emptySeats = Console.ReadLine()
                .Split(' ')
                .Select(s => Convert.ToInt32(s))
                .ToList();
        }

    }
}
