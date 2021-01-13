using System;
using System.Linq;

namespace Codeforces.UniqueHorseshoes
{
    class Program
    {
        static void Main(string[] args)
        {

            var colors = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            Array.Sort(colors);

            int previousUniqueColor = colors[0];
            int duplicatesCount = 0;

            for (int i = 1; i < colors.Length; i++)
            {
                if (colors[i] == previousUniqueColor) duplicatesCount += 1;
                else previousUniqueColor = colors[i];
            }

            Console.WriteLine(duplicatesCount);
        }
    }
}
