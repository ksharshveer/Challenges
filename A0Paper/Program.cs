using System;

namespace A0Paper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanBuild(new[] { 0, 1, 2 }));
            Console.WriteLine(CanBuild(new[] { 0, 0, 4 }));
            Console.WriteLine(CanBuild(new[] { 0, 1, 1, 1, 1, 1, 1, 3 }));

            Console.WriteLine(CanBuild(new[] { 0, 1, 1 }));
            Console.WriteLine(CanBuild(new[] { 0, 0, 3 }));
        }

        public static string CanBuild(int[] input)
        {
            bool isPossible = input[0] > 0;
            if (!isPossible)
            {
                isPossible = true;
                int curPapers = input[^1];
                for (int i = input.Length - 1; i > 1; i--)
                {
                    int onePrevPapers = (curPapers / 2) + input[i - 1];
                    bool sufficientForTwoPrevious = onePrevPapers + input[i - 2] > 1;
                    if (!sufficientForTwoPrevious)
                    {
                        isPossible = false;
                        break;
                    }
                    curPapers = onePrevPapers;
                }
            }

            return isPossible ? "Possible" : "Impossible";
        }
    }
}
