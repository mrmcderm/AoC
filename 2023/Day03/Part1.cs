namespace Aoc._2023.Day03
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var schematicLines = RawInput.Split("\r\n").ToList();
            var totalRows = schematicLines.Count;
            var totalColumns = schematicLines[0].Length;

            for(var row = 0; row < totalRows; row++)
            {
                for(var column = 0; column < totalColumns; column++)
                {
                    var currentCharacter = schematicLines[row][column].ToString();
                    //We found an empty space
                    if (currentCharacter == ".")
                    {
                        continue;
                    }

                    //We found a number
                    if (int.TryParse(currentCharacter, out _))
                    {
                        continue;
                    }

                    //We found a symbol
                    var neighbors = GetNeighbors(schematicLines, row, column);

                }
            }            

            Console.WriteLine("Day 3, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
        public static List<string> GetNeighbors(List<string> grid, int row, int column)
        {
            var neighbors = new List<string>();
            var totalRows = grid.Count;
            var totalColumns = grid[0].Length;

            //Check if there is an adjacent symbol
            if (column > 0 && grid[row][column - 1] != '.') //Immediate Left
            {
                neighbors.Add(grid[row][column - 1].ToString());
            }
            else if (column > 0 && row > 0 && grid[row - 1][column - 1] != '.') //Upper Left
            {
                neighbors.Add(grid[row - 1][column - 1].ToString());
            }
            else if (row > 0 && grid[row - 1][column] != '.') //Upper
            {
                neighbors.Add(grid[row - 1][column].ToString());
            }
            else if (row > 0 && column < totalColumns - 1 && grid[row - 1][column + 1] != '.') //Upper Right
            {
                neighbors.Add(grid[row - 1][column + 1].ToString());
            }
            else if (column < totalColumns - 1 && grid[row][column + 1] != '.') //Immediate Right
            {
                neighbors.Add(grid[row][column + 1].ToString());
            }
            else if (row < totalRows - 1 && column < totalColumns - 1 && grid[row + 1][column + 1] != '.') //Lower Right
            {
                neighbors.Add(grid[row + 1][column + 1].ToString());
            }
            else if (row < totalRows - 1 && grid[row + 1][column] != '.') //Lower
            {
                neighbors.Add(grid[row + 1][column].ToString());
            }
            else if (row < totalRows - 1 && column > 0 && grid[row + 1][column - 1] != '.') //Lower Left
            {
                neighbors.Add(grid[row + 1][column - 1].ToString());
            }

            return neighbors;
        }
    }
}
