using System;
using System.Linq;

namespace Codeforces.SolveIfConfident
{
    class Program
    {
        static void Main(string[] args)
        {
            const string KnowsSolution = "1";

            int willWriteSolutions = 0;
            int canSolveCount;

            int problemsCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < problemsCount; i++)
            {
                canSolveCount = 0;
                Console.ReadLine()
                    .Split()
                    .ToList()
                    .ForEach(s => canSolveCount = s.Equals(KnowsSolution) ? canSolveCount + 1 : canSolveCount);

                if (canSolveCount >= 2) willWriteSolutions += 1;
            }

            Console.WriteLine(willWriteSolutions);
        }
    }
}
