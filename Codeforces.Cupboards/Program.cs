using System;
using System.Linq;

namespace Codeforces.Cupboards
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupboards = Console.ReadLine();
            Console.WriteLine(Solve(Convert.ToInt32(cupboards)));
        }

        private static int Solve(int cupboards)
        {
            int leftDoorsOpen = default;
            int rightDoorsOpen = default;

            int[] doorsPositions = new int[2];
            string positions = string.Empty;
            for (int i = 0; i < cupboards; i++)
            {
                // left & right door positions. 1 if open, else 0
                positions = Console.ReadLine().Trim();
                doorsPositions = positions.Split().Select(p => Convert.ToInt32(p)).ToArray();

                if (doorsPositions[0] == 1) leftDoorsOpen++;
                if (doorsPositions[1] == 1) rightDoorsOpen++;
            }

            int secondsNeeded = 0;

            if (leftDoorsOpen <= cupboards / 2) secondsNeeded += leftDoorsOpen;
            else secondsNeeded += cupboards - leftDoorsOpen;

            if (rightDoorsOpen <= cupboards / 2) secondsNeeded += rightDoorsOpen;
            else secondsNeeded += cupboards - rightDoorsOpen;

            return secondsNeeded;
       }
    }
}
