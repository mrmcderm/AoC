namespace Aoc._2021.Day09
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var heightmapLines = RawInput.Split(Environment.NewLine);
            var heightMap = new List<List<int>>();
            var riskLevels = new List<int>();
            
            foreach(var line in heightmapLines)
            {
                heightMap.Add(line.Select(_ => int.Parse(_.ToString())).ToList());
            }

            for(int i = 0; i < heightMap.Count; i++)
            {
                for(int j = 0; j < heightMap[i].Count; j++)
                {
                    var leftPoint = j > 0 ? heightMap[i][j - 1] : int.MaxValue;
                    var rightPoint = j < heightMap[i].Count-1 ? heightMap[i][j + 1] : int.MaxValue;
                    var upPoint = i > 0 ? heightMap[i - 1][j] : int.MaxValue;
                    var downPoint = i < heightMap.Count - 1 ? heightMap[i + 1][j] : int.MaxValue;
                    var currentPoint = heightMap[i][j];

                    if(currentPoint < leftPoint && currentPoint < rightPoint && currentPoint < upPoint && currentPoint < downPoint)
                    {
                        riskLevels.Add(heightMap[i][j]+1);
                    }
                }
            }

            answer = riskLevels.Sum();
            Console.WriteLine("Day 9, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
