using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.JzzhuAndChildren
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            (int childrenCount, int candiesDist) = (parameters[0], parameters[1]);

            var candiesWanted = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s));
            Queue<int> needMoreCandies = new Queue<int>(candiesWanted);

            var indicesRange = Enumerable.Range(1, childrenCount);
            Queue<int> childrenIndex = new Queue<int>(indicesRange);

            var lastChild = GetLastChildToGoHome(candiesDist, needMoreCandies, childrenIndex);
            Console.WriteLine(lastChild);
        }

        private static int GetLastChildToGoHome(int candiesGiven, Queue<int> needMoreCandies, Queue<int> childrenIndex)
        {
            int child = -1;
            while (needMoreCandies.Count != 0)
            {
                child = childrenIndex.Dequeue();
                int candiesNeeded = needMoreCandies.Dequeue();
                candiesNeeded -= candiesGiven;
                if (candiesNeeded > 0)
                {
                    childrenIndex.Enqueue(child);
                    needMoreCandies.Enqueue(candiesNeeded);
                }
            }
            return child;
        }

    }
}
