using System;
using System.Linq;

namespace Codeforces.AmusingJoke
{
    class Program
    {
        static void Main(string[] args)
        {
            var guest = Console.ReadLine();
            var host = Console.ReadLine();

            var pileChars = Console.ReadLine().ToCharArray();
            var guestPlustHostChars = (guest + host).ToCharArray();

            Array.Sort(pileChars);
            Array.Sort(guestPlustHostChars);

            if (pileChars.SequenceEqual(guestPlustHostChars)) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
