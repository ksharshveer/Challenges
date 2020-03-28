using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Maths.FindThePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input for the problem relative to debug run
            FileInfo inFile = new FileInfo("../../../InputFile.txt");

            // Parsing input in accordance with the problem statement
            using (StreamReader sr = inFile.OpenText())
            {
                int n = Convert.ToInt32(sr.ReadLine());
                for (int nItr = 0; nItr < n; nItr++)
                {
                    string[] pxPyQxQy = sr.ReadLine().Split(' ');
                    int px = Convert.ToInt32(pxPyQxQy[0]);
                    int py = Convert.ToInt32(pxPyQxQy[1]);
                    int qx = Convert.ToInt32(pxPyQxQy[2]);
                    int qy = Convert.ToInt32(pxPyQxQy[3]);
                    int[] result = Find180Reflection(px, py, qx, qy);

                    // Writing result to console
                    var res = string.Join(" ", result);
                    Console.WriteLine(res);
                }
            }
        }

        private static int[] Find180Reflection(int px, int py, int qx, int qy)
        {
            int diffX = qx - px;
            int diffY = qy - py;
            return new int[] { qx + diffX, qy + diffY };
        }
    }
}
