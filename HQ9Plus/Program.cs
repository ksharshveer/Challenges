using System;

namespace HQ9Plus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WillOutput());
        }

        private static string WillOutput()
        {
            var chars = Console.ReadLine().ToCharArray();
            foreach (var c in chars)
            {
                if (c == 'H' || c == 'Q' || c == '9')
                {
                    return "YES";
                }
            }
            return "NO";
        }
    }
}
