using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            ABoardGame aBoardGame = new ABoardGame();
            var res = aBoardGame.WhoWins(new string[]
            {
                "..A.",
                "AB..",
                "....",
                "..B.",
            });

            Console.WriteLine(res);
        }
    }
}
