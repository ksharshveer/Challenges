using System;
using System.Linq;

namespace Codeforces.XeniaAndRingroad
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            (int housesCount, int tasksCount) = (input[0], input[1]);
            var tasks = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            Console.WriteLine(MinTimeToCompleteTasks(housesCount, tasks));
        }

        private static ulong MinTimeToCompleteTasks(int housesCount, int[] tasks)
        {
            ulong minTime = 0;

            int curHouse = 1;
            int curTask;
            for (int i = 0; i < tasks.Length; i++)
            {
                curTask = tasks[i];
                if (curTask < curHouse) minTime += (ulong) (housesCount - (curHouse - curTask));
                else if (curTask > curHouse) minTime += (ulong) (curTask - curHouse);
                curHouse = curTask;
            }

            return minTime;
        }
    }
}
