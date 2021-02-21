using System;
using System.Linq;

namespace Codeforces.LittleElephantAndFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Console.Write(num);
            if (num != 1)
            {
                Enumerable.Range(1, num-1)
                    .ToList()
                    .ForEach(n => Console.Write($" {n}"));
            }
        }
    }
}
