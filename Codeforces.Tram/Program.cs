using System;
using System.Linq;

namespace Codeforces.Tram
{
    class Program
    {
        static void Main(string[] args)
        {
            int stops = Convert.ToInt32(Console.ReadLine());
            var input = ReadMatrix_Integers(stops);

            Console.WriteLine(MinimunCapacity(input));
        }

        static int MinimunCapacity(int[][] stopsInfo)
        {
            int minimumCapacity = 0;

            int capacity = 0;
            foreach (var stopInfo in stopsInfo)
            {
                // At each stop, passengers who want to exit, exit first,
                // only then any passengers who want to enter, enter into the tram.
                capacity -= stopInfo[0];
                capacity += stopInfo[1];

                // Maximum people inside the tram at any given station.
                if (capacity > minimumCapacity) minimumCapacity = capacity;
            }

            return minimumCapacity;
        }

        static int[][] ReadMatrix_Integers(int rows)
        {
            int[][] input = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                input[i] = Console.ReadLine().Split()
                    .Select(s => Convert.ToInt32(s)).ToArray();
            }
            return input;
        }
    }
}
