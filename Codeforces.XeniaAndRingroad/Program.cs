using System;
using System.Collections.Generic;
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

        private static int MinTimeToCompleteTasks(int housesCount, int[] tasks)
        {
            int minTime = 0;
            Queue<int> housesQ = new Queue<int>(Enumerable.Range(1, housesCount));

            int curHouse = housesQ.Dequeue();
            int taskIndex = 0;
            while (true)
            {
                if (taskIndex >= tasks.Length) break;

                // Move to next task if we can we do the one or more tasks at this house
                if (tasks[taskIndex] == curHouse) taskIndex++;
                else // Move to next house
                {
                    minTime++;

                    // Houses are on a circular road
                    housesQ.Enqueue(curHouse);
                    curHouse = housesQ.Dequeue();
                }
            }

            return minTime;
        }
    }
}
