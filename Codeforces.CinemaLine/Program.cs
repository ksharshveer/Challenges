using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.CinemaLine
{
    class Program
    {

        const int TwentyFive = 25;
        const int Fifty = 50;
        const int Hundred = 100;

        static void Main(string[] args)
        {
            _ = Console.ReadLine();
            var line = Console.ReadLine()
            .Split()
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            if (CanSellAllTickets(line)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }

        private static bool CanSellAllTickets(int[] line)
        {
            Dictionary<int, int> moneyCollected = new Dictionary<int, int>()
            {
                { TwentyFive, 0 },
                { Fifty, 0 },
                { Hundred, 0 }
            };

            for (int i = 0; i < line.Length; i++)
            {
                moneyCollected[line[i]] += line[i];
                //Console.WriteLine($"|{moneyCollected[TwentyFive]}|{moneyCollected[Fifty]}|{moneyCollected[Hundred]}|");

                if (line[i] != TwentyFive)
                {
                    var changeNeeded = line[i] - TwentyFive;

                    int limit = 0;
                    while (changeNeeded > 0 && limit++ < 3)
                    {
                        if (moneyCollected[Fifty] > 0 && (changeNeeded - Fifty) >= 0)
                        {
                            moneyCollected[Fifty] -= Fifty;
                            changeNeeded -= Fifty;
                        }

                        if (moneyCollected[TwentyFive] > 0 && (changeNeeded - TwentyFive) >= 0)
                        {
                            moneyCollected[TwentyFive] -= TwentyFive;
                            changeNeeded -= TwentyFive;
                        }
                    }

                    if (changeNeeded != 0) return false;
                }

            }

            return true;
        }
    }
}
