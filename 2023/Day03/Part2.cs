namespace Aoc._2023.Day03
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var schematics = RawInput.Split("\r\n").ToList();
            var totalRows = schematics.Count;
            var totalColumns = schematics[0].Length;
            var partNumbers = new List<int>();
            var gearRatios = new Dictionary<string, List<int>>();

            for (var row = 0; row < totalRows; row++)
            {
                Console.WriteLine($"Processing Row {row}");
                for (var column = 0; column < totalColumns; column++)
                {
                    var currentCharacter = schematics[row][column].ToString();
                    //We found an empty space
                    if (currentCharacter == ".")
                    {
                        continue;
                    }

                    //We found a symbol
                    if (!int.TryParse(currentCharacter, out _) && currentCharacter != ".")
                    {
                        continue;
                    }

                    //We found a number, so find the rest
                    var numberString = currentCharacter;
                    var gearCoords = IsAdjacentToAGear(schematics, row, column);
                    column++;
                    currentCharacter = schematics[row][column].ToString();

                    if(string.IsNullOrEmpty(gearCoords))
                        gearCoords = IsAdjacentToAGear(schematics, row, column);

                    while (int.TryParse(currentCharacter, out _))
                    {
                        if (string.IsNullOrEmpty(gearCoords))
                            gearCoords = IsAdjacentToAGear(schematics, row, column);
                        numberString += currentCharacter;
                        column++;

                        if (column >= totalColumns)
                        {
                            break;
                        }

                        currentCharacter = schematics[row][column].ToString();
                    }

                    if (!string.IsNullOrEmpty(gearCoords))
                    {
                        if (!gearRatios.TryGetValue(gearCoords, out List<int>? value))
                        {
                            value = [];
                            gearRatios.Add(gearCoords, value);
                        }

                        value.Add(int.Parse(numberString));
                        partNumbers.Add(int.Parse(numberString));
                    }
                }
            }

            var foo = gearRatios.Where(_ => _.Value.Count == 2).OrderBy(_ => int.Parse(_.Key)).ToList();
            answer = gearRatios.Where(_ => _.Value.Count == 2).Select(_ => _.Value[0] * _.Value[1]).Sum();

            Console.WriteLine("Day 3, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        public static string IsAdjacentToAGear(List<string> schematics, int row, int column)
        {
            var result = string.Empty;

            //Check left
            if (column > 0 && schematics[row][column - 1].ToString() == "*")
            {
                result = row.ToString() + (column -1).ToString();
            }

            //Check upper left
            if (column > 0 && row > 0 && schematics[row - 1][column - 1].ToString() == "*")
            {
                result = (row - 1).ToString() + (column - 1).ToString();
            }

            //Check top
            if (row > 0 && schematics[row - 1][column].ToString() == "*")
            {
                result = (row -1).ToString() + column.ToString();
            }

            //Check upper right
            if (row > 0 && column < schematics[0].Length - 1 && schematics[row - 1][column + 1].ToString() == "*")
            {
                result = (row - 1).ToString() + (column + 1).ToString();
            }

            //Check right
            if (column < schematics[0].Length - 1 && schematics[row][column + 1].ToString() == "*")
            {
                result = row.ToString() + (column + 1).ToString();
            }

            //Check lower right
            if (column < schematics[0].Length - 1 && row < schematics.Count - 1 && schematics[row + 1][column + 1].ToString() == "*")
            {
                result = (row + 1).ToString() + (column + 1).ToString();
            }

            //Check bottom
            if (row < schematics.Count - 1 && schematics[row + 1][column].ToString() == "*")
            {
                result = (row - 1).ToString() + column.ToString();
            }

            //Check bottom left
            if (row < schematics.Count - 1 && column > 0 && schematics[row + 1][column - 1].ToString() == "*")
            {
                result = (row + 1).ToString() + (column - 1).ToString();
            }

            return result;
        }
    }
}
