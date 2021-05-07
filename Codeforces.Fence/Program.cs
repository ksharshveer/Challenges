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
            int minIndex = 1;
            if (fenceHeights.Length == 1) return minIndex;

            int prevSum = fenceHeights.AsSpan(0..pianoWidth).ToArray().Sum();
            int minSum = prevSum;
            for (int i = 1; i <= fenceHeights.Length - pianoWidth; i++)
            {
                var curSum = prevSum + fenceHeights[i + pianoWidth - 1] - fenceHeights[i - 1];
                if (curSum < minSum)
                {
                    minIndex = i + 1;
                    minSum = curSum;
                }
                prevSum = curSum;
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
