using System;
using System.Linq;

namespace Codeforces.DimaAndFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            int friends = Convert.ToInt32(Console.ReadLine());
            var fingers = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .Aggregate((x, y) => x + y);

            int dimaWinningFingersCount = 0;
            for (int i = 0; i < 5; i++)
            {
                if (((fingers + i) % (friends + 1)) != 0) dimaWinningFingersCount++;
            }

            Console.WriteLine(dimaWinningFingersCount);
        }
    }
}
