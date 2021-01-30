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
            int weeklyReading = bookReadingSchedule.Sum();
            int weeksNeeded = (int) Math.Ceiling((double)totalPages / weeklyReading) ;
            int pagesRead = weeklyReading * (weeksNeeded - 1);

            int day = 1;
            foreach (var todaysReading in bookReadingSchedule)
            {
                if (pagesRead < totalPages)
                {
                    pagesRead += todaysReading;
                    if (pagesRead < totalPages) day += 1;
                }
                else break;
            }

            return day;
        }
    }
}
