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

namespace HackTheInterview2US.DetermineTheWinner
{
    class Program
    {
        // Possible match results
        private static readonly string PLAYER1_WINS = "Player 1 wins";
        private static readonly string PLAYER2_WINS = "Player 2 wins";
        private static readonly string DRAW = "Draw";

        static void Main(string[] args)
        {
            // Input for the problem relative to debug run
            FileInfo inFile = new FileInfo("../../../InputFile.txt");

            // Parsing input in accordance with the problem statement
            using (StreamReader sr = inFile.OpenText())
            {
                char winning_suit = sr.ReadLine()[0];
                int n = Convert.ToInt32(sr.ReadLine().Trim());

                for (int nItr = 0; nItr < n; nItr++)
                {
                    string[] firstMultipleInput = sr.ReadLine().TrimEnd().Split(' ');
                    char suit1 = firstMultipleInput[0][0];
                    int number1 = Convert.ToInt32(firstMultipleInput[1]);
                    char suit2 = firstMultipleInput[2][0];
                    int number2 = Convert.ToInt32(firstMultipleInput[3]);

                    string res = GetRoundResult(winning_suit, suit1, number1, suit2, number2);

                    // Writing result to console
                    Console.WriteLine(res);
                }
            }
        }

        public static string GetRoundResult(char winning_suit, char suit1, int number1, char suit2, int number2)
        {
            // Player with winning suit wins. High priority, so order matters.
            if (winning_suit.Equals(suit1) && !winning_suit.Equals(suit2)) return PLAYER1_WINS;
            if (winning_suit.Equals(suit2) && !winning_suit.Equals(suit1)) return PLAYER2_WINS;

            // Deciding result based on numbers if both players had winning suits
            if (number1 > number2) return PLAYER1_WINS;
            if (number2 > number1) return PLAYER2_WINS;
            return DRAW;
        }
    }
}
