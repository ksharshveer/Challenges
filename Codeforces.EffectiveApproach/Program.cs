using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.EffectiveApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = Convert.ToInt32(Console.ReadLine());
            var elements = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            var preComputedMap = new Dictionary<int, (int, int)>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (!preComputedMap.ContainsKey(elements[i]))
                {
                    preComputedMap[elements[i]] = (i + 1, elements.Length - i);
                }
            }

            ulong normalComparisonsCount = 0;
            ulong reverseComparisonsCount = 0;

            int queriesCount = Convert.ToInt32(Console.ReadLine());
            var queries = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToList();

            int temp;
            queries.ForEach(q =>
            {
                temp = Convert.ToInt32(q);
                if (preComputedMap.ContainsKey(temp))
                {
                    normalComparisonsCount += (ulong) preComputedMap[temp].Item1;
                    reverseComparisonsCount += (ulong) preComputedMap[temp].Item2;
                }
                else
                {
                    normalComparisonsCount += (ulong) elementsCount;
                    reverseComparisonsCount += (ulong) elementsCount;
                }
            });

            Console.WriteLine($"{normalComparisonsCount} {reverseComparisonsCount}");
        }
    }
}
