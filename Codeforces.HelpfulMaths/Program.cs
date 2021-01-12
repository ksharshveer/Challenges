using System;
using System.Text;

namespace Codeforces.HelpfulMaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            var (oneCount, twoCount, threeCount) = (0, 0, 0);
            Count123(line, ref oneCount, ref twoCount, ref threeCount);

            PrintReformedExpression(oneCount, twoCount, threeCount);
        }

        private static void PrintReformedExpression(int oneCount, int twoCount, int threeCount)
        {
            StringBuilder expression = new StringBuilder();
            
            while (oneCount > 0)
            {
                expression.Append('1');
                expression.Append('+');
                oneCount -= 1;
            }

            while (twoCount > 0)
            {
                expression.Append('2');
                expression.Append('+');
                twoCount -= 1;
            }

            while (threeCount > 0)
            {
                expression.Append('3');
                expression.Append('+');
                threeCount -= 1;
            }

            // Removing excess '+'
            expression.Remove(expression.Length - 1, 1);

            Console.WriteLine(expression.ToString());

        }

        private static void Count123(string line, ref int oneCount, ref int twoCount, ref int threeCount)
        {
            for (int i = 0; i < line.Length; i += 2)
            {
                switch (line[i])
                {
                    case '1':
                        oneCount += 1;
                        break;
                    case '2':
                        twoCount += 1;
                        break;
                    case '3':
                        threeCount += 1;
                        break;
                }
            }
        }
    }
}
