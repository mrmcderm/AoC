namespace Aoc._2021.Day05
{
    public class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var lines = RawInput.Split(Environment.NewLine).ToList();
            var MaxSizes = GetMaxSize(lines);
            var DisplayGrid = new int[MaxSizes.Item1, MaxSizes.Item2];

            var resultsDictionary = new Dictionary<(int, int), int>();
            foreach (var line in lines)
            {
                var points = line.Split(" -> ");
                var startPoint = points[0].Split(",");
                var endPoint = points[1].Split(",");
                var x1 = int.Parse(startPoint[0]);
                var y1 = int.Parse(startPoint[1]);
                var x2 = int.Parse(endPoint[0]);
                var y2 = int.Parse(endPoint[1]);

                //Vertical or Horizontal
                if (x1 == x2 || y1 == y2)
                {
                    var xRange = Math.Abs(x1 - x2);
                    var yRange = Math.Abs(y1 - y2);

                    var xCoords = new int[xRange + 1];
                    var yCoords = new int[yRange + 1];

                    for (int i = 0; i <= xRange; i++)
                    {
                        if (x1 < x2)
                            xCoords[i] = x1 + i;
                        else
                            xCoords[i] = x1 - i;
                    }

                    for (int i = 0; i <= yRange; i++)
                    {
                        if (y1 < y2)
                            yCoords[i] = y1 + i;
                        else
                            yCoords[i] = y1 - i;
                    }

                    foreach (var xCoord in xCoords)
                    {
                        foreach (var yCoord in yCoords)
                        {
                            if (resultsDictionary.ContainsKey((xCoord, yCoord)))
                            {
                                resultsDictionary[(xCoord, yCoord)]++;
                            }
                            else
                            {
                                resultsDictionary.Add((xCoord, yCoord), 1);
                            }

                            DisplayGrid[xCoord, yCoord]++;
                        }
                    }
                }

                //Diagonal
                if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
                {
                    //TODO Generate coordinates


                    //going SE - increase x by 1 and increase y by 1
                    if (x1 < x2 && y1 < y2)
                    {
                        var currentPoint = (x1, y1);
                        if (resultsDictionary.ContainsKey((currentPoint.x1, currentPoint.y1)))
                        {
                            resultsDictionary[(currentPoint.x1, currentPoint.y1)]++;
                        }
                        else
                        {
                            resultsDictionary.Add((currentPoint.x1, currentPoint.y1), 1);
                        }
                        while (currentPoint != (x2, y2))
                        {
                            currentPoint = (currentPoint.x1 + 1, currentPoint.y1 + 1);

                            if (resultsDictionary.ContainsKey((currentPoint.x1, currentPoint.y1)))
                            {
                                resultsDictionary[(currentPoint.x1, currentPoint.y1)]++;
                            }
                            else
                            {
                                resultsDictionary.Add((currentPoint.x1, currentPoint.y1), 1);
                            }
                            DisplayGrid[currentPoint.x1, currentPoint.y1]++;
                        }
                    }

                    //going SW - decrease x by 1 and increase y by 1
                    if (x1 > x2 && y1 < y2)
                    {
                        var currentPoint = (x1, y1);
                        if (resultsDictionary.ContainsKey((currentPoint.x1, currentPoint.y1)))
                        {
                            resultsDictionary[(currentPoint.x1, currentPoint.y1)]++;
                        }
                        else
                        {
                            resultsDictionary.Add((currentPoint.x1, currentPoint.y1), 1);
                        }
                        while (currentPoint != (x2, y2))
                        {
                            currentPoint = (currentPoint.x1 - 1, currentPoint.y1 + 1);

                            if (resultsDictionary.ContainsKey((currentPoint.x1, currentPoint.y1)))
                            {
                                resultsDictionary[(currentPoint.x1, currentPoint.y1)]++;
                            }
                            else
                            {
                                resultsDictionary.Add((currentPoint.x1, currentPoint.y1), 1);
                            }
                            DisplayGrid[currentPoint.x1, currentPoint.y1]++;
                        }
                    }

                    //going NE - increase x by 1 and decrease y by 1
                    if (x1 < x2 && y1 > y2)
                    {
                        var currentPoint = (x1, y1);
                        if (resultsDictionary.ContainsKey((currentPoint.x1, currentPoint.y1)))
                        {
                            resultsDictionary[(currentPoint.x1, currentPoint.y1)]++;
                        }
                        else
                        {
                            resultsDictionary.Add((currentPoint.x1, currentPoint.y1), 1);
                        }
                        while (currentPoint != (x2, y2))
                        {
                            currentPoint = (currentPoint.x1 + 1, currentPoint.y1 - 1);

                            if (resultsDictionary.ContainsKey((currentPoint.x1, currentPoint.y1)))
                            {
                                resultsDictionary[(currentPoint.x1, currentPoint.y1)]++;
                            }
                            else
                            {
                                resultsDictionary.Add((currentPoint.x1, currentPoint.y1), 1);
                            }
                            DisplayGrid[currentPoint.x1, currentPoint.y1]++;
                        }
                    }

                    //going NW - decrease x by 1 and decrease y by 1
                    if (x1 > x2 && y1 > y2)
                    {
                        var currentPoint = (x1, y1);
                        if (resultsDictionary.ContainsKey((currentPoint.x1, currentPoint.y1)))
                        {
                            resultsDictionary[(currentPoint.x1, currentPoint.y1)]++;
                        }
                        else
                        {
                            resultsDictionary.Add((currentPoint.x1, currentPoint.y1), 1);
                        }
                        while (currentPoint != (x2, y2))
                        {
                            currentPoint = (currentPoint.x1 - 1, currentPoint.y1 - 1);

                            if (resultsDictionary.ContainsKey((currentPoint.x1, currentPoint.y1)))
                            {
                                resultsDictionary[(currentPoint.x1, currentPoint.y1)]++;
                            }
                            else
                            {
                                resultsDictionary.Add((currentPoint.x1, currentPoint.y1), 1);
                            }
                            DisplayGrid[currentPoint.x1, currentPoint.y1]++;                            
                        }
                    }
                }
            }

            /*
            for (int i = 0; i < MaxSizes.Item1; i++)
            {
                for (int j = 0; j < MaxSizes.Item2; j++)
                {
                    Console.Write(DisplayGrid[j, i] < 1 ? "." : DisplayGrid[j, i]);
                }
                Console.WriteLine();
            }
            */

            foreach (var result in resultsDictionary)
            {
                if (result.Value > 1)
                {
                    answer++;
                }
            }

            Console.WriteLine("Day 5, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        public (int, int) GetMaxSize(List<string> lines)
        {
            var maxX = 0;
            var maxY = 0;

            foreach (var line in lines)
            {
                var points = line.Split(" -> ");
                var startPoint = points[0].Split(",");
                var endPoint = points[1].Split(",");

                var x1 = int.Parse(startPoint[0]);
                var y1 = int.Parse(startPoint[1]);
                var x2 = int.Parse(endPoint[0]);
                var y2 = int.Parse(endPoint[1]);
                maxX = Math.Max(maxX, x1);
                maxX = Math.Max(maxX, x2);
                maxY = Math.Max(maxY, y1);
                maxY = Math.Max(maxY, y2);
            }

            return (maxX + 1, maxY + 1);
        }
    }
}
