using System;
using System.Collections.Generic;
using System.Linq;

namespace LightsOut
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = ReadMatrix(3, 3);
            Solve(ref input);
        }

        private static void Solve(ref int[][] input)
        {
            int[][] sol = null;
            CreateMatrix(out sol, input.Length, input[0].Length, defValue: 1);
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    var isOdd = input[i][j] % 2 == 1;
                    if (isOdd)
                    {
                        sol[i][j] = sol[i][j] == 1 ? 0 : 1;
                        var adjs = GetAdjacentIndices(ref input, i, j);
                        foreach (var item in adjs)
                        {
                            sol[item.Item1][item.Item2] = sol[item.Item1][item.Item2] == 1 ? 0 : 1;
                        }
                    }
                }
            }
            PrintMatrix(sol, colItemSep: "");
            return;
        }

        private static List<Tuple<int, int>> GetAdjacentIndices(ref int[][] input, int row, int col)
        {
            var adjs = new List<Tuple<int, int>>();
            int rowMax = input.Length - 1;
            int colMax = input[0].Length - 1;

            foreach (var indPair in new[] { (0, -1), (0, 1), (-1, 0), (1, 0) })
            {
                var (ind1, ind2) = indPair;
                (ind1, ind2) = (ind1 + row, ind2 + col);
                if (!((ind1 < 0) || (ind1 > rowMax) || (ind2 < 0) || (ind2 > colMax)))
                    adjs.Add(Tuple.Create(ind1, ind2));
            }

            return adjs;
        }

        static int[][] ReadMatrix(int rows, int cols)
        {
            int[][] input = new int[rows][];
            int[] row = new int[cols];
            for (int i = 0; i < rows; i++)
            {
                row = Console.ReadLine()
                    .Split()
                    .Select(s => Convert.ToInt32(s))
                    .ToArray();
                input[i] = row;
            }

            return input;
        }

        static void CreateMatrix<T>(out T[][] mat, int rows, int cols, T defValue=default)
        {
            mat = new T[rows][];
            for (int row = 0; row < rows; row++)
            {
                mat[row] = new T[cols];
                for (int col = 0; col < cols; col++)
                {
                    mat[row][col] = defValue;
                }
            }
        }

        static void PrintMatrix<T>(T[][] mat, string colItemSep=" ")
        {
            mat.ToList().ForEach(row =>
            {
                row.ToList().ForEach(col => Console.Write($"{col}{colItemSep}"));
                Console.WriteLine();
            });
        }

    }
}
