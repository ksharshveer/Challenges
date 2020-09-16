using System;

namespace Codeforces.BeautifulMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] {
                "0 0 0 0 0",
                "0 0 0 0 1",
                "0 0 0 0 0",
                "0 0 0 0 0",
                "0 0 0 0 0",
            };

            Console.WriteLine(MovesToBeautifyMatrix(input));
        }

        /// <summary>
        /// Rows or columns swap needed to make the matrix beautiful.
        /// Beautiful matrix is a matrix with "1" in the middle.
        /// </summary>
        /// <param name="matrix">String array, where each string is a row of space
        /// separated columns, and there is exactly one '1' value in the matrix.</param>
        /// <returns></returns>
        public static int MovesToBeautifyMatrix(string[] matrix)
        {
            int row1Cols = matrix[0].Split().Length;
            if ((matrix.Length % 2 == 0) || (row1Cols % 2 == 0))
                throw new ArgumentException("Input matrix must have odd number of rows and columns!");

            int swaps = 0;
            int rowMid = (matrix.Length / 2) + 1;
            int colMid = (row1Cols / 2) + 1;

            // Finding position of "1" in matrix (row, col)
            int[] position = new int[] { 0, 0 };
            foreach (string row in matrix)
            {
                bool found = false;
                position[0]++;
                position[1] = 0;
                var cols = row.Split();
                foreach (string col in cols)
                {
                    position[1]++;
                    if (col.Equals("1"))
                    {
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            // Finding swaps required to beautify
            swaps += (Math.Abs(rowMid - position[0]));
            swaps += (Math.Abs(colMid - position[1]));

            return swaps;
        }
    }
}
