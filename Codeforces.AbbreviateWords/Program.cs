using System;

namespace Codeforces.AbbreviateWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(Console.ReadLine());
            string line;
            for (int i = 0; i < count; i++)
            {
                line = Console.ReadLine();
                PrintWordAbbreviation(ref line);
            }
        }

        static void PrintWordAbbreviation(ref string word)
        {
            if (word.Length > 10) 
                Console.WriteLine(word[0].ToString() + (word.Length - 2) + word[word.Length - 1].ToString());
            else
                Console.WriteLine(word);
        }
    }
}
