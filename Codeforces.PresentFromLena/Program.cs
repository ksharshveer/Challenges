using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codeforces.PresentFromLena
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(GetHandkerchiefPattern(input));
        }

        private static string GetHandkerchiefPattern(int input, string separator=" ")
        {
            if (input < 1 || input > 9) throw new ArgumentOutOfRangeException(nameof(input));

            var sb = new StringBuilder();
            var sl = new List<string>();
            var range = Enumerable.Range(0, input+1).ToArray();
            foreach (var item in range)
            {
                sb.Clear();
                var paddingAround = string.Join(null, Enumerable.Repeat(separator, (2 * (input - item))));
                var line = string.Join(separator, range[0..item]);
                var revLine = string.Join(null, line.Reverse());

                sb.Append(paddingAround);
                if (string.IsNullOrEmpty(line)) sb.Append(item);
                else sb.Append($"{line} {item} ");
                sb.Append(revLine);
                // Not required by problem statement
                //sb.Append(paddingAround);
                sb.Append('\n');
                sl.Add(sb.ToString());
            }

            return string.Join(null, sl) + string.Join(null, sl.ToArray()[..^1].Reverse());
        }
    }
}
