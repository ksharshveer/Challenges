using System;
using System.Linq;

namespace Codeforces.Parallelpiped
{
    class Program
    {
        static void Main(string[] args)
        {
            var areas = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            FindEdgeLengths(areas, out int EdgeA, out int EdgeB, out int EdgeC);
            int combinedEdgesLength = (4 * EdgeA) + (4 * EdgeB) + (4 * EdgeC);

            Console.WriteLine(combinedEdgesLength);
        }

        //From doing some paper maths, I figured if a, b, and c are edges to a vertex, and
        // x, y, z are areas of faces to that vertex, then following relations can be derived:
        // a * b = x, b * c = y, c * a = z, a^2 = x * z / y
        private static void FindEdgeLengths(int[] areas, out int edgeA, out int edgeB, out int edgeC)
        {
            edgeA = (int)Math.Sqrt((areas[0] * areas[2]) / areas[1]);
            edgeC = areas[2] / edgeA;
            edgeB = areas[1] / edgeC;
        }
    }
}
