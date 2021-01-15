using System;
using System.Linq;

namespace Codeforces.Softdrinking
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            int drinksForToasts = (numbers[1] * numbers[2]) / numbers[6];
            int limesForToasts = numbers[3] * numbers[4];
            int saltForToasts = numbers[5] / numbers[7];

            int min = new[] { drinksForToasts, limesForToasts, saltForToasts }.Min();
            Console.WriteLine(min / numbers[0]);
        }
    }
}
