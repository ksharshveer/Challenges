using System;
using System.Text;

namespace Codeforces.HungrySequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            PrintHungrySequenceOfLength(input);
        }

        private static void PrintHungrySequenceOfLength(int input)
        {
            // Hungry Sequence using 1,000,001 as start can be all numbers
            // in range [1,000,001, 2,000,000]
            // Reasoning: Consider start number to be 11. Now all numbers in
            // range [11, 21] make hungry sequence. Because -
            // No individual number is a multiple of our chosen start number 11.
            long start = 1000001;

            // StringBuilder to prevent timeout which can happen if writing too
            // many small chunks of strings to console.
            var sb = new StringBuilder();
            for (int i = 0; i < input; i++, start++)
            {
                sb.Append(start);
                if (i != input - 1) sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
