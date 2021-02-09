using System;

namespace Codeforces.MagicNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (IsMagicNumber(input))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static bool IsMagicNumber(string input)
        {
            bool found = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '1')
                {
                    found = false;
                    break;
                }

                if (i < input.Length-1)
                {
                    char next = input[i + 1];
                    if (next == '4')
                    {
                        if (i + 1 < input.Length - 1)
                        {
                            next = input[i + 2];
                            if (next == '4') i += 1;
                        }
                        i += 1;
                    }
                }
            }

            return found;
        }
    }
}
