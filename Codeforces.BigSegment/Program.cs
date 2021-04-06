using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.BigSegment
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput(out int count, out List<(int Left, int Right)> segments);

            int position = HasBigSegment(segments);
            Console.WriteLine(position);
        }

        /// <summary>
        /// Gets the position of a segment that covers all other segments.
        /// (1st position would mean 1st segment in the list)
        /// </summary>
        /// <param name="segments">List of segment tuples</param>
        /// <returns>Position of BigSegment if found. -1 otherwise.</returns>
        public static int HasBigSegment(List<(int Left, int Right)> segments)
        {
            var minLeft = segments.Aggregate((s1, s2) => s1.Left < s2.Left ? s1 : s2).Left;
            var maxRight = segments.Aggregate((s1, s2) => s1.Right > s2.Right ? s1 : s2).Right;
            var maxDiff = maxRight - minLeft;

            if (!segments.Any(s => s.Right - s.Left == maxDiff)) return -1;

            var curBigSeg = (Left: minLeft, Right: maxRight);
            return segments.IndexOf(curBigSeg) + 1;
        }

        private static void ReadInput(out int count, out List<(int Left, int Right)> segments)
        {
            count = Convert.ToInt32(Console.ReadLine());
            segments = new List<(int Left, int Right)>();

            for (int i = 0; i < count; i++)
            {
                var numbers = Console.ReadLine()
                .Split(' ')
                .Select(s => Convert.ToInt32(s))
                .ToArray();

                segments.Add((numbers[0], numbers[1]));
            }
        }
    }
}
