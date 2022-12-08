namespace Aoc._2022.Day08
{
    public class Part1 : IPuzzle
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

            for (int y = 0; y < max; y++)
            {
                for (int x = 0; x < max; x++)
                {
                    //If we're on the edge, the tree is always visible
                    if (y == 0 || y == (max - 1) || x == 0 || x == (max - 1))
                    {
                        answer++;
                        continue;
                    }

                    var currentTree = forestGrid[y][x];

                    //Get trees to the right:
                    var treesToTheRight = forestGrid[y].GetRange(x + 1, max - 1 - x);

                    //Get trees to the left:
                    var treesToTheLeft = forestGrid[y].GetRange(0, x);

                    //Get the trees above and below
                    var treesAbove = new List<int>();
                    var treesBelow = new List<int>();
                    for(int yy = 0; yy < max; yy++)
                    {
                        if(yy < y)
                            treesAbove.Add(forestGrid[yy][x]);
                        if(yy > y)
                            treesBelow.Add(forestGrid[yy][x]);
                    }

                    //If the current tree is taller than any right, left, above, or below...it's visible
                    if (treesToTheRight.Max() < currentTree 
                        || treesToTheLeft.Max() < currentTree 
                        || treesAbove.Max() < currentTree 
                        || treesBelow.Max() < currentTree)
                    {
                        answer++;
                    }
                }
            }

            /* Visualization
            foreach(var row in forestGrid)
            {
                foreach(var tree in row)
                {
                    Console.Write(tree);
                }
                Console.WriteLine();
            }
            */

            Console.WriteLine("Day 8, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
