using System;
using System.Linq;

namespace Codeforces.Translation
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var translatedWord = Console.ReadLine();

            if (IsReversed(word, translatedWord))
            {
                Console.WriteLine("YES");
            }
            else Console.WriteLine("NO");
        }

        private static bool IsReversed(string word, string translatedWord)
        {
            return word.SequenceEqual(translatedWord.Reverse());
        }
    }
}
