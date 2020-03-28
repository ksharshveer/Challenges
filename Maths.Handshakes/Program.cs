using System;

namespace Maths.Handshakes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Gauss's formula to sum 1 to n numbers is n * (n + 1) / 2
            int[] peopleArr = new int[] { 0, 1, 2, 3, 4, 5, 100 };
            foreach (var people in peopleArr)
            {
                Console.WriteLine($"{people} people can have {GetHandshakes(people)} unique handshakes");
            }

            int[] numsArr = new int[] { 3, 5, 10 };
            foreach (var num in numsArr)
            {
                Console.WriteLine($"Sum from {2} to {num} : {AddConsecutiveNums(2, num)}");
            }
        }

        private static int AddConsecutiveNums(int start, int end)
        {
            // +1 to make the end inclusive
            int items = end - start + 1;
            return (items * (end + start)) / 2;
        }

        private static int GetHandshakes(int n)
        {
            return (n * (n - 1)) / 2;
        }

    }
}
