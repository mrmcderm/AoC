namespace Aoc._2021.Day09
{
    public class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }
        public List<List<int>> heightMap = new();
        public Dictionary<(int x, int y), List<(int x, int y)>> lowPoints = new();
        public List<Point> points = new();

        public void Solve()
        {
            var answer = 0;
            var heightmapLines = RawInput.Split(Environment.NewLine).ToArray();
            var maxY = heightmapLines.Length;
            var maxX = heightmapLines[0].Length;

            for (var x = 0; x < maxX; x++)
            {
                for (var y = 0; y < maxY; y++)
                {
                    var point = new Point() { X = x, Y = y, Height = int.Parse(heightmapLines[y][x].ToString()) };

                    var leftNeighbor = point.X > 0 ? new Point() { Y = point.Y, X = point.X - 1, Height = int.Parse(heightmapLines[point.Y][point.X - 1].ToString()) } : null;
                    var rightNeighbor = point.X < maxX - 1 ? new Point() { Y = point.Y, X = point.X + 1, Height = int.Parse(heightmapLines[point.Y][point.X + 1].ToString()) } : null;
                    var upNeighbor = y > 0 ? new Point() { Y = point.Y - 1, X = point.X, Height = int.Parse(heightmapLines[point.Y - 1][point.X].ToString()) } : null;
                    var downNeighbor = y < maxY - 1 ? new Point() { Y = point.Y + 1, X = point.X, Height = int.Parse(heightmapLines[point.Y + 1][point.X].ToString()) } : null;

                    if(leftNeighbor != null)
                        point.Neighbors.Add(leftNeighbor);

                    if(rightNeighbor != null)
                        point.Neighbors.Add(rightNeighbor);

                    if(upNeighbor != null)
                        point.Neighbors.Add(upNeighbor);

                    if (downNeighbor != null)
                        point.Neighbors.Add(downNeighbor);

                    var lowestNeighbor = point.Neighbors.OrderBy(_ => _.Height).First();

                    if(point.Height < lowestNeighbor.Height)
                        lowPoints.Add((point.X, point.Y), new List<(int x, int y)>() { (point.X, point.Y) });


                    points.Add(point);
                }
            }

            //Loop through again and set the hierarchy
            foreach (var point in points)
            {
                for (var i = 0; i < point.Neighbors.Count; i++)
                {
                    var fullNeighbor = points.First(_ => _.X == point.Neighbors[i].X && _.Y == point.Neighbors[i].Y && _.Height == point.Neighbors[i].Height);
                    point.Neighbors[i] = fullNeighbor;
                }
            }

            foreach (var point in points)
            {
                //find low point for current point
                var (x, y) = GetLowPoint(point);

                //If the current point is a low point or it's of height 9, don't do any further procesing
                if ((x == point.X && x > point.X) || point.Height == 9)
                    continue;

                //grab a handle to that low point from the master list
                var lowPoint = lowPoints.First(_ => _.Key.x == x && _.Key.y == y);

                if (!lowPoint.Value.Any(_ => _.x == point.X && _.y == point.Y))
                    lowPoint.Value.Add((point.X, point.Y));
            }


            var orderedLowPoints = lowPoints.Select(_ => (_.Key, _.Value.Count)).OrderByDescending(_ => _.Count).ToList();
            answer = orderedLowPoints[0].Count * orderedLowPoints[1].Count * orderedLowPoints[2].Count;

            Console.WriteLine("Day 9, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private (int x, int y) GetLowPoint(Point point)
        {
            //if point is a low point, return it
            if (lowPoints.ContainsKey((point.X, point.Y)))
            {
                return (point.X, point.Y);
            }

            var smallestNeighbor = point.Neighbors.OrderBy(_ => _.Height).First();
            return GetLowPoint(smallestNeighbor);
        }

        public class Point
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Height { get; set; }

            public List<Point> Neighbors { get; set; }

            public Point()
            {
                Neighbors = new List<Point>();
            }

            public override string ToString()
            {
                return $"({X}, {Y}); H: {Height}, {Neighbors.Count} Neighbors";
            }
        }
    }
}
