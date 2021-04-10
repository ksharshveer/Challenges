using System;
using System.Linq;

namespace Codeforces.LittleElephantAndBits
{
    class Program
    {
        static void Main(string[] args)
        {
            var binInput = Console.ReadLine();
            Console.WriteLine(MaxDeletingOneBit(binInput));
        }

        private static string MaxDeletingOneBit(string binInput)
        {
            // String sliced to remove only first character
            var simpleCasesResult = binInput[1..^0];

            var binCharArray = binInput.ToCharArray();

            // Starts with zero, removing it makes no difference
            if (binInput[0] == '0') return simpleCasesResult;

            // All bits are one, removing any will yield the same result
            else if (binCharArray.All(c => c == '1'))
                return simpleCasesResult;

            // Remove first zero, so any upcoming non zero bits can have the biggest
            // effect on value, because a bit shift to left gets a power increment
            else return new string(binCharArray.TakeWhile(c => c == '1').ToArray())
                + new string(binCharArray.SkipWhile(c => c != '0').ToArray())[1..^0];
        }
    }
}
