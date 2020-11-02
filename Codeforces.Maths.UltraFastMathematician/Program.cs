using System;
using System.Collections;
using System.Linq;

namespace Codeforces.Maths.UltraFastMathematician
{
    class Program
    {
        static void Main(string[] args)
        {
            // XOR using BitArray(s)
            // var bitsNum1 = new BitArray(Console.ReadLine().Select(c => c == '1').ToArray());
            // bitsNum1.Xor(new BitArray(Console.ReadLine().Select(c => c == '1').ToArray()));

            var bitsNum1 = Console.ReadLine().Select(c => c == '1').ToArray();
            var bitsNum2 = Console.ReadLine().Select(c => c == '1').ToArray();

            for (int i = 0; i < bitsNum1.Length; i++)
            {
                bitsNum1[i] = bitsNum1[i] ^ bitsNum2[i];
            }

            // Convert result to character array
            var ans = new char[bitsNum1.Length];
            for (int i = 0; i < bitsNum1.Length; i++)
            {
                ans[i] = bitsNum1[i] == true ? '1' : '0';
            }

            Console.WriteLine(new string(ans));
        }
    }
}

