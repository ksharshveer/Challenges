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

namespace HackTheInterview2US.MaximumStreaks
{
    class Program
    {
        static readonly string HEADS = "Heads";
        static readonly string TAILS = "Tails";

        static void Main(string[] args)
        {
            // Input for the problem relative to debug run
            FileInfo inFile = new FileInfo("../../../InputFile.txt");

            // Parsing input in accordance with the problem statement
            using (StreamReader sr = inFile.OpenText())
            {
                int tossCount = Convert.ToInt32(sr.ReadLine().Trim());

                List<string> toss = new List<string>();

                for (int i = 0; i < tossCount; i++)
                {
                    string tossItem = sr.ReadLine();
                    toss.Add(tossItem);
                }

                // Writing result to console
                var res = GetMaxStreaks(toss);
                Console.WriteLine(res[0] + " " + res[1]);
            }
        }

        public static List<int> GetMaxStreaks(List<string> toss)
        {
            // Variables to track max consecutive heads and tails
            int maxH = 0;
            int maxT = 0;

            // Variables to track current consecutive heads and tails
            int curH = 0;
            int curT = 0;

            // Setup based on the first toss
            bool sawHeadEarlier;
            if (toss[0].Equals(HEADS))
            {
                sawHeadEarlier = true;
                curH = maxH = 1;
            }
            else
            {
                sawHeadEarlier = false;
                curT = maxT = 1;
            }

            // Case for only one toss
            if (toss.Count == 1) return new List<int> { maxH, maxT };

            // Counting consective heads and tails for more than 1 tosses
            for (int i = 1; i < toss.Count; i++)
            {
                // Saw a head earlier
                if (sawHeadEarlier)
                {
                    // But, now seen a tail
                    if (toss[i].Equals(TAILS))
                    {
                        sawHeadEarlier = false;
                        curT++;
                        if (curH > maxH) maxH = curH;
                        curH = 0;
                    }
                    // Seeing consecutive heads
                    else curH++;
                }
                // Saw a tail earlier
                else
                {
                    // But, now seen a head
                    if (toss[i].Equals(HEADS))
                    {
                        sawHeadEarlier = true;
                        curH++;
                        if (curT > maxT) maxT = curT;
                        curT = 0;
                    }
                    // Seeing consecutive tails
                    else curT++;
                }
            }
            // Updating any pending results
            if (curH > maxH) maxH = curH;
            if (curT > maxT) maxT = curT;

            return new List<int> { maxH, maxT };
        }
    }
}
