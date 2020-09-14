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

namespace HighSecurityStrings
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
                string password = sr.ReadLine();
                int weight_a = Convert.ToInt32(sr.ReadLine());

                // Writing result to console
                var res = GetStrength(password, weight_a);
                Console.WriteLine(res);
            }
        }

        private static int GetStrength(string password, int weight_a)
        {
            int strength = 0;
            foreach (var letter in password)
            {
                strength += WeightLetter(letter, weight_a);         
            }
            return strength;
        }

        private static int WeightLetter(char letter, int weight_a)
        {
            int base_a = Convert.ToInt32('a');
            return (Convert.ToInt32(letter) - base_a + weight_a) % 26;
        }
    }
}
