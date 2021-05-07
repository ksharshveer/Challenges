using System;
using System.Linq;

namespace Codeforces.Fence
{
    class Program
    {
        static void Main(string[] args)
        {
            var (fenceCount, pianoWidth) = ReadInput(out int[] fenceHeights);
            Console.WriteLine(GetFenceIndexToPassPiano(fenceHeights, pianoWidth));
        }

        private static int GetFenceIndexToPassPiano(int[] fenceHeights, int pianoWidth)
        {
            int minIndex = 0;
            int minSum = int.MaxValue;

            for (int i = pianoWidth; i < fenceHeights.Length + 1; i++)
            {
                var curSum = fenceHeights.AsSpan((i - pianoWidth)..i).ToArray().Sum();
                if (curSum < minSum)
                {
                    minSum = curSum;
                    minIndex = i - pianoWidth + 1;
                }
            }

            return minIndex;
        }

        private static (int, int) ReadInput(out int[] fenceHeights)
        {
            var nums = Console.ReadLine().Split().ToList()
                .Select(n => Convert.ToInt32(n)).ToList();

            fenceHeights = Console.ReadLine().Split()
                    .Select(s => Convert.ToInt32(s)).ToArray();

            return (nums[0], nums[1]);
        }
    }
}
