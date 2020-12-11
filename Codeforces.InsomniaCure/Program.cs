using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.InsomniaCure
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDragons = default;
            int[] klmn = new int[4];

            for (int i = 0; i < 4; i++)
                klmn[i] = Convert.ToInt32(Console.ReadLine());
            numDragons = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Solve(ref klmn, ref numDragons));

        }

        private static int Solve(ref int[] klmn, ref int dragons)
        {
            // Removing duplicates in klmn. Not a necessary step!
            HashSet<int> uniqueKlmn = new HashSet<int>(klmn);
            if (uniqueKlmn.Count < 4)
                klmn = uniqueKlmn.ToArray();

            // Could've just extracted minimun number instead of sorting,
            // but it will likely help break out of upcoming inner loop
            // quicker in practice
            Array.Sort(klmn);
            if (klmn[0] == 1) return dragons;

            int escapedDragons = default;
            bool escaped;
            for (int dragon = 1; dragon < dragons+1; dragon++)
            {
                escaped = true;
                for (int j = 0; j < klmn.Length; j++)
                {
                    if (dragon % klmn[j] == 0)
                    {
                        escaped = false;
                        break;
                    }
                }
                if (escaped) escapedDragons++;
            }

            return dragons - escapedDragons;
        }
    }
}
