using System;

namespace Codeforces.BitPlusPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;

            int statements = Convert.ToInt32(Console.ReadLine());
            char operatorValue;
            for (int i = 0; i < statements; i++)
            {
                operatorValue = Console.ReadLine()[1];
                if (operatorValue == '+') x += 1;
                else if (operatorValue == '-') x -= 1;
            }

            Console.WriteLine(x);
        }
    }
}
