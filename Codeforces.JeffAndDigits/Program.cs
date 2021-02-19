using System;

namespace Codeforces.JeffAndDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reading input, and counting zero and five cards
            int cardsCount = Convert.ToInt32(Console.ReadLine());
            int zeroCardsCount = 0;
            for (int i = 0; i < cardsCount; i++)
            {
                char c = (char) Console.Read();
                Console.Read();
                if (c == '0') zeroCardsCount += 1;
            }
            int fiveCardsCount = cardsCount - zeroCardsCount;

            // Exact multiple of 9 consecutive 5's are divisible by 9
            // Had to dig that info on the internet
            int nineConsecFivesCount = (int) Math.Floor((double)fiveCardsCount / 9);

            // Just simple conditions for what's divisible by 90
            if (nineConsecFivesCount == 0)
            {
                // 0 is divisible
                if (zeroCardsCount > 0) Console.WriteLine("0");
                else Console.WriteLine("-1");
            }
            // Need a minimum of one zeroes
            else if (zeroCardsCount == 0) Console.WriteLine("-1");
            // Zeroes at the end of consecutive multiple of 5's
            else
            {
                for (int i = 0; i < nineConsecFivesCount; i++)
                {
                    Console.Write("555555555");
                }
                for (int i = 0; i < zeroCardsCount; i++)
                {
                    Console.Write("0");
                }
                Console.WriteLine();
            }
        }
    }
}
