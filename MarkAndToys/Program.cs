using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace MarkAndToys
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input for the problem relative to debug run
            FileInfo inFile = new FileInfo("../../../InputFile.txt");

            // Parsing input in accordance with the problem statement
            using (StreamReader sr = inFile.OpenText())
            {
                var line1 = sr.ReadLine().Split(" ").Select(num => Convert.ToInt32(num)).ToArray();
                (int numOfToys, int amountToSpend) = (line1[0], line1[1]);

                var prices = sr.ReadLine().Split(" ").Select(num => Convert.ToInt32(num)).ToArray();

                // Writing result to console
                var res = MaximumToys(prices, amountToSpend);
                Console.WriteLine(res);
            }
        }

        private static int MaximumToys(int[] prices, int amountToSpend)
        {
            var pricesSeen = new ArrayList();
            int budgetUsed = 0;
            int maxToys = 0;

            foreach (var price in prices)
            {
                // Only consider toys which don't exceed our maximum budget
                if (price <= amountToSpend)
                {
                    // Added expence from this toy
                    budgetUsed += price;
                    maxToys++;
                    SortedInsert(price, ref pricesSeen);

                    // Solve situation where we considered to buy a toy which exceeds our
                    // maximum budget when combined with already bought(imaginary) toys
                    if (budgetUsed > amountToSpend)
                    {
                        int lastIndex = pricesSeen.Count - 1;
                        int highPriceToy = (int) pricesSeen[lastIndex];

                        // We exceeded out allowable budget, so we will not buy the most
                        // expensive toy we have seen so far
                        pricesSeen.RemoveAt(lastIndex);
                        maxToys--;

                        // Consider if our remaining budget can now be used to buy some
                        // other cheaper toy(s)
                        budgetUsed -= highPriceToy;
                    }
                }
            }
            return maxToys;
        }

        // Insert an Integer in the provided empty or sorted ArrayList
        private static void SortedInsert(int x, ref ArrayList al)
        {
            for (int i = 0; i < al.Count; i++)
            {
                if (x < (int)al[i])
                {
                    al.Insert(i, x);
                    return;
                }
            }
            al.Add(x);
        }
    }
}
