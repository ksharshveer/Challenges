using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.JeffAndPeriods
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = Console.ReadLine();

            var numbers = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            FindPeriods(numbers, out List<(int, int)> pairs);

            // Outputting in required format
            Console.WriteLine(pairs.Count);
            pairs.OrderBy(t => t.Item1)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Item1} {p.Item2}"));
        }

        private static void FindPeriods(int[] numbers, out List<(int, int)> pairs)
        {
            pairs = new List<(int, int)>();  // Tuple of suitable value, and its difference in progression

            // Special case, all numbers are same
            if (numbers.Length > 1 && numbers.All(n => n == numbers[0]))
            {
                pairs.Add((numbers[0], 1));
                return;
            }

            HashSet<int> unsuitables = new HashSet<int>();

            // To hold suitable value along with its difference, current index
            Dictionary<int, (int, int)> values = new Dictionary<int, (int, int)>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!values.ContainsKey(numbers[i])) values[numbers[i]] = (0, i);
                else
                {
                    // Ignore numbers already found as not suitable for progression series
                    if (unsuitables.Contains(numbers[i])) continue;

                    var (diff, index) = values[numbers[i]];

                    // Seeing a number for the second time
                    if (diff == 0) values[numbers[i]] = (i - index, i);
                    // Found the number to be unsuitable
                    else if (diff != i - index)
                    {
                        unsuitables.Add(numbers[i]);
                        values.Remove(numbers[i]);
                    }
                    // Update index to check difference again in upcoming matches
                    else values[numbers[i]] = (diff, i);
                }
            }

            foreach (var k in values.Keys)
            {
                if (!unsuitables.Contains(k))
                {
                    pairs.Add((k, values[k].Item1));
                }
            }
        }
    }
}
