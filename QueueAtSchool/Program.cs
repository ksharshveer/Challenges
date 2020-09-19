using System;
using System.Linq;

namespace QueueAtSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FinalQueue("BGGBG", 2));
        }

        public static string FinalQueue(string initial)
        {
            char[] final = initial.ToCharArray();
            for (int i = 0; i < initial.Length-1; i++)
            {
                if (initial[i].Equals('B') && initial[i+1].Equals('G'))
                {
                    (final[i], final[i + 1]) = (final[i + 1], final[i]);
                    i += 1;
                }
            }
            return new string(final);
        }

        public static string FinalQueue(string initial, int timesteps)
        {
            string res = initial;
            for (int i = 0; i < timesteps; i++)
            {
                res = FinalQueue(res);
            }
            return res;
        }
    }
}
