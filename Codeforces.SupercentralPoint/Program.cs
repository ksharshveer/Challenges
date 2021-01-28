using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeforces.SupercentralPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();

            // Reading input to desired form
            int sets = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < sets; i++)
            {
                var pointArray = Console.ReadLine()
                .Split(' ')
                .Select(s => Convert.ToInt32(s))
                .ToArray();
                points.Add(new Point(pointArray[0], pointArray[1]));
            }

            // Finding all points which are above or below each other
            foreach (var point in points)
            {
                if (point.IsSupercentralPoint) continue;

                foreach (var px in points.Where(p => p.X == point.X))
                {
                    if (point.IsAbove(px))
                    {
                        point.HasPointBelow = true;
                        px.HasPointAbove = true;
                    }
                    else if (point.IsBelow(px))
                    {
                        point.HasPointAbove = true;
                        px.HasPointBelow = true;
                    }
                } 
            }

            // Finding all points which are left or right to each other
            foreach (var point in points)
            {
                if (point.IsSupercentralPoint) continue;

                foreach (var py in points.Where(p => p.Y == point.Y))
                {
                    if (point.IsLeft(py))
                    {
                        point.HasPointRight = true;
                        py.HasPointLeft = true;
                    }
                    else if (point.IsRight(py))
                    {
                        point.HasPointLeft = true;
                        py.HasPointRight = true;
                    }
                } 
            }

            // Counting Super central points
            int supercentralPointsCount = points
                .Where(p => p.IsSupercentralPoint)
                .Count();

            Console.WriteLine(supercentralPointsCount);

        }

        public class Point
        {
            public int X { get; }
            public int Y { get; }

            public bool HasPointAbove { get; set; } = false;
            public bool HasPointBelow { get; set; } = false;
            public bool HasPointLeft { get; set; } = false;
            public bool HasPointRight { get; set; } = false;

            public bool IsSupercentralPoint => HasPointLeft && HasPointRight && HasPointAbove && HasPointBelow;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool IsAbove(Point p)
            {
                return (p.X == X && p.Y < Y);
            }

            public bool IsBelow(Point p)
            {
                return (p.X == X && p.Y > Y);
            }

            public bool IsLeft(Point p)
            {
                return (p.X > X && p.Y == Y);
            }

            public bool IsRight(Point p)
            {
                return (p.X < X && p.Y == Y);
            }

        }
    }
}
