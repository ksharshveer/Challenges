using System;
using System.Linq;
using System.Text;

namespace Codeforces.DZYLovesChessboards
{
    class Program
    {
        // Board character interpretations
        const char AvailableSpot = '.';
        const char BadSpot = '-';
        const char White = 'W';
        const char Black = 'B';

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(num => Convert.ToInt32(num)).ToArray();
            var (n, m) = (input[0], input[1]);  // Board dimentions

            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                foreach (char c in Console.ReadLine().Trim())
                {
                    if (c == BadSpot)
                    {
                        sb.Append(BadSpot);
                        j++;
                        continue;
                    }

                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0) sb.Append(Black);
                        else sb.Append(White) ;
                    }
                    else
                    {
                        if (j % 2 != 0) sb.Append(Black);
                        else sb.Append(White) ;
                    }
                    j++;
                }
                sb.Append('\n');
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
