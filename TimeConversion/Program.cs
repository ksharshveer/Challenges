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

namespace TimeConversion
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
                string time = sr.ReadLine();

                // Writing result to console
                var res = ConvertTime24Hour(time);
                Console.WriteLine(res);
            }
        }

        // Convert `hh:mm:ss[AM|PM]` time string to `hh:mm:ss` 24 hour time string
        private static object ConvertTime24Hour(string time)
        {
            var hour = Convert.ToInt32(time.Substring(0, 2));
            var isPM = time.Trim().EndsWith("PM");
            if (isPM)
            {
                var newHour = hour == 12 ? hour : hour + 12;
                var newTime = Convert.ToString(newHour) + time.Substring(2, 6);
                return newTime;
            }
            else
            {
                var newHour = hour == 12 ? "00" : Convert.ToString(hour);
                if (newHour.Length == 1) newHour = "0" + newHour;
                var newTime = Convert.ToString(newHour) + time.Substring(2, 6);
                return newTime;
            }
        }
    }
}
