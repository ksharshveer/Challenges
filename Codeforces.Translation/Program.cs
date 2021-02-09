using System;

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
            if (word.Length != translatedWord.Length) return false;

            for ((int i, int j) = (0, word.Length - 1); i < word.Length; i++, j--)
            {
                if (word[i] != translatedWord[j]) return false;
            }

            return true;
        }
    }
}
