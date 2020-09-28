using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace BorzeDecode
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = ".-.--";  // 012
            var res = Method(ref input);
            Console.WriteLine(res);

            input = "--.";  // 20
            res = Method(ref input);
            Console.WriteLine(res);

            input = "-..-.--";  // 1012
            res = Method(ref input);
            Console.WriteLine(res);
        }

        public static string Method(ref string input)
        {
            var code = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-')
                {
                    if (input[i + 1] == '-') code.Add('2');
                    else code.Add('1');
                    i += 1;
                    continue;
                }
                else code.Add('0');
            }

            return new string(code.ToArray());
        }
    }
}
