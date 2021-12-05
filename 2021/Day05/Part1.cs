namespace Aoc._2021.Day05
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var lines = RawInput.Split(Environment.NewLine).ToList();

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
                            if(resultsDictionary.ContainsKey((xCoord, yCoord)))
                            {
                                resultsDictionary[(xCoord, yCoord)]++;
                            }
                            else
                            {
                                resultsDictionary.Add((xCoord, yCoord), 1);
                            }                            
                        }
                    }
                }
            }

            foreach(var result in resultsDictionary)
            {
                if(result.Value > 1)
                {
                    answer++;
                }
            }

            Console.WriteLine("Day 5, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
