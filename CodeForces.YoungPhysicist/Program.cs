using System;
using System.Linq;

namespace CodeForces.YoungPhysicist
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new []
            {
                new [] {3, -1, 7 },
                new [] {-5, 2, -4 },
                new [] {2, -1, -3 }
            };
            Console.WriteLine(ForcesInEquilibrium(input));

            input = new []
            {
                new [] {3, -1, 7 },
                new [] {-5, 33, -4 },
                new [] {2, -1, -3 }
            };
            Console.WriteLine(ForcesInEquilibrium(input));
        }

        public static string ForcesInEquilibrium(int[][] input)
        {
            var vectorRes = new[] { 0, 0, 0 };
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    vectorRes[j] += input[i][j];
                }
            }
            return vectorRes.All(x => x == 0) ? "YES" : "NO";
        }
    }
}
