using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.BicycleChain
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadProblem(out int pedalAxleStars, out int rearWheelAxleStars, out IEnumerable<int> pedalStarsTeeths, out IEnumerable<int> rearWheelStarsTeeths);
            int gears = CountMaxRatioIntegerGears(pedalStarsTeeths, rearWheelStarsTeeths, out int ratio);
            Console.WriteLine(gears);
        }

        private static int CountMaxRatioIntegerGears(IEnumerable<int> pedalStarsTeeths, IEnumerable<int> rearWheelStarsTeeths, out int ratio)
        {
            List<int> ratios = new List<int>();
            foreach (var rTeeths in rearWheelStarsTeeths)
            {
                foreach (var pTeeths in pedalStarsTeeths)
                {
                    if (pTeeths > rTeeths) break;
                    bool intDivisionPossible = rTeeths % pTeeths == 0;
                    if (intDivisionPossible)
                    {
                        ratios.Add(rTeeths / pTeeths);
                    }
                }
            }
            ratio = ratios.Max();
            int maxRatio = ratio;
            return ratios.Where(r => r == maxRatio).Count();
        }

        private static void ReadProblem(out int pedalAxleStars, out int rearWheelAxleStars, out IEnumerable<int> pedalStarsTeeths, out IEnumerable<int> rearWheelStarsTeeths)
        {
            pedalAxleStars = Convert.ToInt32(Console.ReadLine());

            pedalStarsTeeths = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s));

            rearWheelAxleStars = Convert.ToInt32(Console.ReadLine());

            rearWheelStarsTeeths = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s));
        }
    }
}
