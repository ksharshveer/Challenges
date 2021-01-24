using System;
using System.Collections.Generic;
using System.Text;

namespace Codeforces.EffectiveApproach
{
    class Program
    {
        static void Main(string[] args)
        {
            // Holds info in tuple of (normal comparisons count, reverse comparisons count),
            // for integer query elements.
            var preComputedMap = new Dictionary<int, (int, int)>();

            int elementsCount = Convert.ToInt32(Console.ReadLine());
            // Compute & cache all forward and reverse comparisons
            ReadAndProcessArray(elementsCount, preComputedMap);

            int queriesCount = Convert.ToInt32(Console.ReadLine());
            ReadAndProcessQueries(out ulong normalComparisons, out ulong reverseComparisons, elementsCount, queriesCount, preComputedMap);

            Console.WriteLine($"{normalComparisons} {reverseComparisons}");
        }

        private static void ReadAndProcessQueries(out ulong normalComparisons, out ulong reverseComparisons, int elementsCount, int queriesCount, Dictionary<int, (int, int)> preComputedMap)
        {
            normalComparisons = reverseComparisons = 0;
            StringBuilder word = new StringBuilder();
            int queryElement;
            for (int i = 0; i < queriesCount; i++)
            {
                queryElement = ReadAsIntegerUntilSpace(word);
                if (preComputedMap.ContainsKey(queryElement))
                {
                    normalComparisons += (ulong) preComputedMap[queryElement].Item1;
                    reverseComparisons += (ulong) preComputedMap[queryElement].Item2;
                }
                else
                {
                    normalComparisons += (ulong) elementsCount;
                    reverseComparisons += (ulong) elementsCount;
                }
            }
            Console.ReadLine(); // Consume remaining line.
        }

        private static void ReadAndProcessArray(int elementsCount, Dictionary<int, (int, int)> preComputedMap)
        {
            int element;
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < elementsCount; i++)
            {
                element = ReadAsIntegerUntilSpace(word);
                if (!preComputedMap.ContainsKey(element))
                {
                    preComputedMap[element] = (i + 1, elementsCount - i);
                }
            }
            Console.ReadLine(); // Consume remaining line.
        }

        private static int ReadAsIntegerUntilSpace(StringBuilder word)
        {
            word.Clear();
            char c = (char)Console.Read();
            while (char.IsWhiteSpace(c)) c = (char)Console.Read();
            while (!char.IsWhiteSpace(c))
            {
                word.Append(c);
                c = (char)Console.Read();
            }
            return Convert.ToInt32(word.ToString());
        }

    }
}
