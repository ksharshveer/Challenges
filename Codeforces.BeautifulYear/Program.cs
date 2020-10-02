using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Codeforces.BeautifulYear
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = Console.ReadLine();
            Console.WriteLine(BeautifulYear(year));
        }

        static string BeautifulYear(string currentYear)
        {
            var y = Convert.ToInt32(currentYear);
            short[] nums = new short[currentYear.Length];
            while (++y < 10000)
            {
                var yStr = y.ToString();
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = Convert.ToInt16(yStr.Substring(i, 1));
                }
                if (nums.ToImmutableHashSet().Count < currentYear.Length) continue;
                return yStr;
            }
            return currentYear;
        }

    }
}
