using System;
using System.Linq;

namespace Codeforces.UnluckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int digitsCount, out string ticketDigits);
            if (IsUnluckyTicket(ticketDigits)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }

        private static bool IsUnluckyTicket(string ticketDigits)
        {
            // Case when ticket length is the minimum!
            if (ticketDigits.Length == 2) return ticketDigits[0] != ticketDigits[1];

            var halfIndex = ticketDigits.Length / 2;
            var firstHalf = ticketDigits[0..halfIndex].ToCharArray();
            var secondHalf = ticketDigits[halfIndex..^0].ToCharArray();

            Array.Sort(firstHalf);
            Array.Sort(secondHalf);

            // Ticket doesn't confirm to the condition of being unlucky,
            // even on the very first comparison
            if (firstHalf[0] == secondHalf[0]) return false;

            bool result = true;
            var firstSmall = firstHalf[0] < secondHalf[0];

            // Strictly less than comparisons
            if (firstSmall)
            {
                for (int i = 1; i < halfIndex; i++)
                {
                    if (firstHalf[i] >= secondHalf[i])
                    {
                        result = false;
                        break;
                    }
                }
            }
            // Strictly greater than comparisons
            else
            {
                for (int i = 1; i < halfIndex; i++)
                {
                    if (firstHalf[i] <= secondHalf[i])
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        private static void ReadInput(out int digitsCount, out string ticketDigits)
        {
            digitsCount = Convert.ToInt32(Console.ReadLine());
            ticketDigits = Console.ReadLine();
        }
    }
}
