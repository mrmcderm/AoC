using System;
using System.Linq;
using System.Net.Sockets;

namespace AoC._2018.Day10
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 10, Part 1");

            var points = RawInput.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(_ => _.Replace("position=", string.Empty).Replace(" velocity=", ","))
                .Select(inputValue => new Point
                {
                    X = int.Parse(inputValue.Replace("<", string.Empty).Replace(">", string.Empty).Split(",")[0].Trim()),
                    Y = int.Parse(inputValue.Replace("<", string.Empty).Replace(">", string.Empty).Split(",")[1].Trim()),
                    XVelocity = int.Parse(inputValue.Replace("<", string.Empty).Replace(">", string.Empty).Split(",")[2].Trim()),
                    YVelocity = int.Parse(inputValue.Replace("<", string.Empty).Replace(">", string.Empty).Split(",")[3].Trim())
                }).ToList();

            var minWidth = points.Min(_ => _.X) - 1;
            var maxWidth = points.Max(_ => _.X) + 1;
            var minHeight = points.Min(_ => _.Y) - 1;
            var maxHeight = points.Max(_ => _.Y) + 1;
            // var displayGrid = new string[width, height];


            for (var second = 0; second < 30; second++)
            {
                Console.WriteLine($"Second: {second}");
                foreach (var point in points)
                {
                    point.X = point.X + point.XVelocity * second;
                    point.Y = point.Y + point.YVelocity * second;
                }

                for (var y = minHeight; y < maxHeight; y++)
                {
                    for (var x = minWidth; x < maxWidth; x++)
                    {
                        Console.Write(points.Any(_ => _.X == x && _.Y == y) ? "#" : ".");
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }

        private class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int XVelocity { get; set; }
            public int YVelocity { get; set; }
        }
    }
}