using System;
using System.Linq;

namespace Codeforces.PetrAndBook
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPages = Convert.ToInt32(Console.ReadLine());

            // Schedule from Monday through Sunday
            var bookReadingSchedule = Console.ReadLine()
            .Split(' ')
            .Select(s => Convert.ToInt32(s))
            .ToArray();

            Console.WriteLine(GetLastBookReadDay(totalPages, bookReadingSchedule));

        }

        private static int GetLastBookReadDay(int totalPages, int[] bookReadingSchedule)
        {
            int pagesRead = 0;
            int dayIndex = 0;
            while (pagesRead < totalPages)
            {
                pagesRead += bookReadingSchedule[dayIndex];
                if (pagesRead < totalPages) dayIndex = ++dayIndex % bookReadingSchedule.Length;
            }
            return ++dayIndex;
        }
    }
}
