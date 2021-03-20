using System;
using System.Linq;

namespace Codeforces.KitaharaHarukisGift
{
    class Program
    {
        static void Main(string[] args)
        {
            int diff = 0;

            int count = Convert.ToInt32(Console.ReadLine());
            var numbers = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            foreach (var num in numbers.OrderByDescending(n=>n))
            {
                if (diff > 0) diff -= num;
                else diff += num;
            }

            if (diff == 0) Console.WriteLine("YES");
            else Console.WriteLine("NO");

        }
    }
}
