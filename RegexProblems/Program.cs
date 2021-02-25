using System;

namespace RegexProblems
{
    class Program
    {
        static IRunnable problemClassInstance;

        static void Main(string[] args)
        {
            //problemClassInstance = new Codeforces_Dubstep();
            //problemClassInstance = new Codeforces_MagicNumbers();
            //problemClassInstance = new Codeforces_Football();
            //problemClassInstance = new Codeforces_StringTask();
            problemClassInstance = new Codeforces_ChatRoom();

            Run(problemClassInstance);
        }

        private static void Run(IRunnable problemToRun)
        {
            problemToRun?.Run();
        }
    }
}
