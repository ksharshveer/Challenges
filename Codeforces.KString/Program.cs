using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codeforces.KString
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            var str = Console.ReadLine();

            if (RearrangeForKString(k, str, out string rearranged))
                Console.WriteLine(rearranged);
            else Console.WriteLine(-1);
        }

        private static bool RearrangeForKString(int k, string str, out string kStr)
        {
            kStr = string.Empty;

            // Analyzing our string for character counts
            Dictionary<char, ushort> charCounts = new Dictionary<char, ushort>();
            foreach (var c in str)
            {
                if (charCounts.ContainsKey(c)) charCounts[c] += 1;
                else charCounts[c] = 1;
            }

            // First fail case, when a character can't be repeated k times
            var min = charCounts.Values.Min();
            if (min < k) return false;

            var sb = new StringBuilder();
            foreach (var kv in charCounts)
            {
                // Second fail case, when some consecutive string of character
                // can't be repeated k times
                if (kv.Value % k != 0) return false;
                else
                {
                    for (int i = 0; i < kv.Value / k; i++)
                    {
                        sb.Append(kv.Key);
                    }
                }
            }

            // A potential k-string where k is 1
            var oneString = sb.ToString();
            for (int i = 1; i < k; i++)
            {
                sb.Append(oneString);
            }

            // Fail case when we can make a k-string, but not from str
            if (sb.ToString().Length != str.Length) return false;
            else kStr = sb.ToString();

            // Just a double check that we do indeed have a string.
            return !string.IsNullOrEmpty(kStr);
        }
    }
}
