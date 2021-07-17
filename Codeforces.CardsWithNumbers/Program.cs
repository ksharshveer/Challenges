using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Codeforces.CardsWithNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int n, out List<int> twoNNums);

            StringBuilder result = new StringBuilder();
            PairCards(n, twoNNums, result);
            File.WriteAllText("output.txt", result.ToString().TrimEnd());
        }

        private static void PairCards(int n, List<int> twoNNums, StringBuilder sb)
        {
            Dictionary<int, int> seens = new Dictionary<int, int>();
            for (int i = 0; i < twoNNums.Count; i++)
            {
                if (!seens.ContainsKey(twoNNums[i]))
                {
                    seens.Add(twoNNums[i], i);
                }
                else
                {
                    sb.Append($"{seens[twoNNums[i]] + 1} {i + 1}");
                    sb.Append("\n");
                    seens.Remove(twoNNums[i]);
                }
            }

            if (seens.Count > 0)
            {
                sb.Clear();
                sb.Append("-1");
            }

            seens.Clear();
        }

        private static void ReadInput(out int n, out List<int> twoNNums)
        {
            var input = File.ReadAllLines("input.txt");

            n = Convert.ToInt32(input[0]);
            twoNNums = input[1]
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToList();
        }
    }
}
