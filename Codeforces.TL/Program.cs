using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.TL
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out IList<int> corrects, out IList<int> incorrects);
            Console.WriteLine(FindTimeLimit(corrects, incorrects));
        }

        private static int FindTimeLimit(IList<int> corrects, IList<int> incorrects)
        {
            // Taking max here will ensure, corrects always pass testing
            int max = corrects.Max();

            bool incorrectsFailTesting = incorrects.All(t => t > max);
            bool correctsContainAtLeastOneFastSolution = corrects.Any(t => (2 * t) <= max);

            // Find the next minimum time limit to ensure satisfactory condition
            if (!correctsContainAtLeastOneFastSolution)
            {
                var sortedCorrects = from sol in corrects
                                     orderby sol ascending
                                     select sol;

                foreach (var t in sortedCorrects)
                {
                    int newMax = 2 * t;

                    // Will fail `correctsPassTesting`, so continue
                    if (newMax <= max) continue;

                    max = newMax;
                    incorrectsFailTesting = incorrects.All(t => t > max);

                    // Found next minimum time limit, so break
                    // or minimum time limit will now pass failing tests, so break
                    break;
                }
            }

            return (max > 0 && incorrectsFailTesting) ? max : -1;

        }

        private static void ReadInput(out IList<int> corrects, out IList<int> incorrects)
        {
            var inputCounts = Console.ReadLine().Split().ToList().Select(x => Convert.ToInt32(x)).ToArray();
            var (n, m) = (inputCounts[0], inputCounts[1]);

            corrects = Console.ReadLine().Split().ToList().Select(x => Convert.ToInt32(x)).ToList();
            incorrects = Console.ReadLine().Split().ToList().Select(x => Convert.ToInt32(x)).ToList();
        }
    }
}
