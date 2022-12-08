namespace Aoc._2022.Day08
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var forestRows = RawInput.Split("\r\n");
            var forestGrid = new List<List<int>>();

            for (int y = 0; y < forestRows.Length; y++)
            {
                var row = new List<int>();
                forestGrid.Add(row);

                for (int x = 0; x < forestRows[y].Length; x++)
                {
                    row.Add(int.Parse(forestRows[y][x].ToString()));
                }
            }

            //Assume square grid
            var max = forestGrid[0].Count;
            var scenicScores = new List<int>();

            for (int y = 0; y < max; y++)
            {
                for (int x = 0; x < max; x++)
                {
                    //If we're on the edge, the viewing distance will always be zero and we can move on
                    if (y == 0 || y == (max - 1) || x == 0 || x == (max - 1))
                    {
                        continue;
                    }

                    var currentTree = forestGrid[y][x];

                    //get right viewing distance
                    var rightViewingDistance = 0;
                    for (int xx = x + 1; xx < max; xx++)
                    {
                        if (forestGrid[y][xx] >= currentTree)
                        {

                            rightViewingDistance++;
                            break;
                        }
                        rightViewingDistance++;
                    }

                    //get left viewing distance
                    var leftViewingDistance = 0;
                    for (int xx = x - 1; xx >= 0; xx--)
                    {
                        if (forestGrid[y][xx] >= currentTree)
                        {
                            leftViewingDistance++;
                            break;
                        }

                        leftViewingDistance++;
                    }

                    //get above viewing distance
                    var aboveViewingDistance = 0;
                    for(int yy = y-1; yy >= 0; yy--)
                    {
                        if (forestGrid[yy][x] >= currentTree)
                        {
                            aboveViewingDistance++;
                            break;
                        }
                        aboveViewingDistance++;
                    }

                    //get below viewing distance
                    var belowViewingDistance = 0;
                    for(int yy = y+1; yy < max; yy++)
                    {
                        if (forestGrid[yy][x] >= currentTree)
                        {
                            belowViewingDistance++;
                            break;
                        }
                        belowViewingDistance++;
                    }

                    var scenicScore = rightViewingDistance * leftViewingDistance * aboveViewingDistance * belowViewingDistance;
                    scenicScores.Add(scenicScore);
                }
            }

            answer = scenicScores.Max();

            Console.WriteLine("Day 8, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
