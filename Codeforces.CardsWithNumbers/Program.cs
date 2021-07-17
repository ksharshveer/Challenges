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

            StringBuilder sb = new StringBuilder();
            if (CanPairCards(n, twoNNums, out List<(int Index1, int Index2 )> indexPairs))
            {
                foreach (var indexPair in indexPairs)
                {
                    sb.Append($"{indexPair.Index1} {indexPair.Index2}");
                    sb.Append("\n");
                }
            }
            else sb.Append("-1");

            File.WriteAllText("output.txt", sb.ToString().TrimEnd());
        }

        private static bool CanPairCards(int n, List<int> twoNNums, out List<(int Index1, int Index2)> indexPairs)
        {
            // `indexPairs` Note! Indexes start from 1
            indexPairs = new List<(int Index1, int Index2)>(n);

            Dictionary<int, int> seens = new Dictionary<int, int>();
            for (int i = 0; i < twoNNums.Count; i++)
            {
                if (!seens.ContainsKey(twoNNums[i]))
                {
                    seens.Add(twoNNums[i], i);
                }
                else
                {
                    indexPairs.Add((seens[twoNNums[i]] + 1, i + 1));
                    seens.Remove(twoNNums[i]);
                }
            }

            if (seens.Count > 0 || indexPairs.Count != n) return false;
            return true;
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
