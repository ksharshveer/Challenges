using System;
using System.Linq;

namespace Codeforces.NumberOfPositionsInLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            var (people, minUpfront, maxBehind) = (inputs[0], inputs[1], inputs[2]);
            Console.WriteLine(Math.Min(people-minUpfront, maxBehind+1));
        }
    }
}
