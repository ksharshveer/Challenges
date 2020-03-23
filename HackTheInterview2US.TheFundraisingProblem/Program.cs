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

                    ArrayList charmGroups = new ArrayList();
                    for (int i = 0; i < numOfGroups; i++)
                    {
                        // Each int represent charm of a student in the group
                        charmGroups.Add(ReadIntsArr(sr));
                    }

                    ArrayList generousGuests = new ArrayList();
                    for (int i = 0; i < numOfTable; i++)
                    {
                        // 1st int is number of guests at the table
                        // rest represent generousity of guests on table
                        generousGuests.Add(ReadIntsArr(sr));
                    }

                    var maxGuestsApproachByStuds = ReadInt(sr);

                    // Writing result to console
                    var res = Solve(charmGroups, generousGuests, maxGuestsApproachByStuds);
                    Console.WriteLine(res);
                }
            }
        }

        private static int Solve(ArrayList charmGroups, ArrayList generousGuests, int maxGuestsApproachByStuds)
        {
            return 0;
        }
    }
}
