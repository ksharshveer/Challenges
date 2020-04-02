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

namespace DayOfTheProgrammer
{
    class Program
    {
        static readonly int TRANSITION_YEAR = 1918;
        static readonly int PROGRAMMERS_DAY = 256;
        static readonly int EXCEPT_FEB_8_MONTH_DAYS = 215;

        static void Main(string[] args)
        {
            // Input for the problem relative to debug run
            FileInfo inFile = new FileInfo("../../../InputFile.txt");

            // Parsing input in accordance with the problem statement
            using (StreamReader sr = inFile.OpenText())
            {
                int year = Convert.ToInt32(sr.ReadLine());

                // Writing result to console
                var res = GetDayOfTheProgrammer(year);
                Console.WriteLine(res);
            }
        }

        private static object GetDayOfTheProgrammer(int year)
        {
            // Julien Calendar in use upto 1917, since 1700
            bool julCase = year < TRANSITION_YEAR;

            // Transition from Julien to Gregorian Calendar
            // Day after January 31 is February 14
            bool transitionCase = year == TRANSITION_YEAR;

            // Gregorian Calendar in use starting 1919, upto 2700
            bool gregCase = year > TRANSITION_YEAR;

            // Default case for number of days in february
            int febDays = 28;

            if (transitionCase)
            {
                febDays = 15;
            }
            else
            {   // Leap year
                if ((julCase && year % 4 == 0)
                    || (gregCase && ((year % 400 == 0)
                    || ((year % 4 == 0) && (year % 100 != 0)))))
                    {
                    febDays = 29;
                }
            }

            // Day finding criteria
            int day = PROGRAMMERS_DAY - (EXCEPT_FEB_8_MONTH_DAYS + febDays);
            return $"{day}.09.{year}";
        }
    }
}
