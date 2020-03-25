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

namespace HackTheInterview2US.TheFundraisingProblem
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
                int testCases = ReadInt(sr);
                for (int testCase = 0; testCase < testCases; testCase++)
                {
                    var mnt = ReadIntsArr(sr);
                    var (numOfGroups, studentsInGroup, numOfTable) = (mnt[0], mnt[1], mnt[2]);

                    List<int[]> charmGroups = new List<int[]>();
                    for (int i = 0; i < numOfGroups; i++)
                    {
                        // Each int represent charm of a student in the group
                        charmGroups.Add(ReadIntsArr(sr));
                    }

                    List<int[]> generousGuests = new List<int[]>();
                    for (int i = 0; i < numOfTable; i++)
                    {
                        // 1st int is number of guests at the table
                        // rest represent generousity of guests on table
                        generousGuests.Add(ReadIntsArr(sr));
                    }

                    var maxGuestsApproachByStud = ReadInt(sr);

                    // Writing result to console
                    var res = Solve(charmGroups, generousGuests, maxGuestsApproachByStud);
                    Console.WriteLine(res);
                }
            }
        }

        private static int Solve(List<int[]> charmGroups, List<int[]> generousGuests, int maxGuestsApproachByStud)
        {
            // Validate problem rules
            if (!DoesProblemConfirmToRules(charmGroups, generousGuests, maxGuestsApproachByStud)) return -1;

            // Sort individual groups, starting with higher charm first
            foreach (var group in charmGroups)
            {
                Array.Sort(group, ReverseIntComparer);
            }

            // Let's first order groups with max charm first, because
            // we will only consider number of groups equal to number of tables
            charmGroups.Sort(ReverseIntArrComparer);

            // Modifying student groups to simplify the problem
            List<int[]> newCharmGroups = new List<int[]>();

            foreach (var group in charmGroups)
            {
                int[] newGroup = new int[maxGuestsApproachByStud*charmGroups.Count];
                int curStudInd = 0;
                int newGroupStudInd = 0;
                while (newGroupStudInd < newGroup.Length)
                {
                    for (int i = 0; i < maxGuestsApproachByStud; i++)
                    {
                        newGroup[newGroupStudInd] = group[curStudInd];
                        newGroupStudInd++;
                    }
                    curStudInd++;
                }
                newCharmGroups.Add(newGroup);
            }

            // Sort guests, starting with the ones that are more generous
            List<int[]> onlyGenerousGuests = new List<int[]>();
            foreach (var guests in generousGuests)
            {
                // Index 0 shows number of guests on table, unnecessary to us
                var newGuests = guests.AsSpan(1).ToArray();
                Array.Sort(newGuests, ReverseIntComparer);
                onlyGenerousGuests.Add(newGuests);
            }

            // Similarly, order tables starting with more generous guests on it
            onlyGenerousGuests.Sort(ReverseIntArrComparer);

            // Find maximum donation which can be collected
            return FindMaxDonation(newCharmGroups, onlyGenerousGuests);
        }

        private static int FindMaxDonation(List<int[]> newCharmGroups, List<int[]> onlyGenerousGuests)
        {
            var maxDonation = 0;
            var curGroup = 0;
            var nextPos = 0;
            for (int i = 0; i < onlyGenerousGuests.Count; i++)
            {
                // ToDo: Handle case when current group students collect
                // donation from some not all guests on a table. 
                if (newCharmGroups[curGroup].Length - nextPos < onlyGenerousGuests[i].Length)
                {
                    nextPos = 0;
                    curGroup++;
                }
                maxDonation += GetGroupTableMax(newCharmGroups[curGroup].AsSpan(nextPos).ToArray(), onlyGenerousGuests[i]);
                nextPos += onlyGenerousGuests[i].Length;
            }
            return maxDonation;
        }

        private static int GetGroupTableMax(int[] students, int[] guests)
        {
            // Sum of Guest's generousity time Student's charm
            return guests.Zip(students, (g, c) => g * c).Sum();
        }

        private static bool DoesProblemConfirmToRules(List<int[]> charmGroups, List<int[]> generousGuests, int maxGuestsApproachByStud)
        {
            // Student can't reach any guest
            if (maxGuestsApproachByStud < 1) return false;

            // Not enough student groups to serve each table
            if (charmGroups.Count < generousGuests.Count) return false;

            // Too many guests on a table
            int maxAllowableGuests = charmGroups.Count * maxGuestsApproachByStud;
            foreach (var guests in generousGuests)
            {
                if (maxAllowableGuests < guests[0]) return false;
            }

            return true;
        }

        private static string ReadLine(StreamReader sr)
        {
            return sr.ReadLine().Trim();
        }
        
        private static int ReadInt(StreamReader sr)
        {
            return Convert.ToInt32(sr.ReadLine().Trim());
        }

        private static int[] ReadIntsArr(StreamReader sr)
        {
            return sr.ReadLine().Trim().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
        }

        private static int ReverseIntComparer(int x, int y)
        {
            if (x == y) return 0;
            if (x > y) return -1;
            else return 1;
        }

        private static int ReverseIntArrComparer(int[] x, int[] y)
        {
            var res = x.Zip(y, (num1, num2) =>
            {
                if (num1 == num2) return 0;
                if (num1 > num2) return -1;
                else return 1;
            });

            foreach (var r in res)
            {
                if (r != 0) return r;
            }

            return 0;
        }

        private static void PrintListOfIntArr(List<int[]> intsArr)
        {
            foreach (var ints in intsArr)
            {
                PrintIntArr(ints);
            }
        }

        private static void PrintIntArr(int[] ints)
        {
            foreach (var num in ints)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }

        private static int Factorial(int x)
        {
            if (x > 1) return x * Factorial(x - 1);
            if (x < 0) throw new ArgumentException("No factorial of negative numbers is possible!");
            return 1;
        }
    }
}
