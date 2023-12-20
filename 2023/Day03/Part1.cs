namespace Aoc._2023.Day03
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var schematics = RawInput.Split("\r\n").ToList();
            var totalRows = schematics.Count;
            var totalColumns = schematics[0].Length;
            var partNumbers = new List<int>();

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
                    var isAdjacentToASymbol = IsAdjacentToASymbol(schematics, row, column);
                    column++;
                    currentCharacter = schematics[row][column].ToString();
                    isAdjacentToASymbol = isAdjacentToASymbol | IsAdjacentToASymbol(schematics, row, column);
                    while (int.TryParse(currentCharacter, out _))
                    {
                        isAdjacentToASymbol = isAdjacentToASymbol | IsAdjacentToASymbol(schematics, row, column);
                        numberString += currentCharacter;
                        column++;

                        if(column >= totalColumns)
                        {
                            break;
                        }

                        currentCharacter = schematics[row][column].ToString();                        
                    }

                    if (isAdjacentToASymbol)
                    {
                        Console.WriteLine($"Found Part Number: {numberString}");
                        partNumbers.Add(int.Parse(numberString));
                    }
                }
            }

            answer = partNumbers.Sum();

            Console.WriteLine("Day 3, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        public static bool IsAdjacentToASymbol(List<string> schematics, int row, int column)
        {
            var result = false;

            //Check left
            if (column > 0 && schematics[row][column - 1].ToString() != "." && !int.TryParse(schematics[row][column - 1].ToString(), out _))
            {
                result = true;
            }

            //Check upper left
            if (column > 0 && row > 0 && schematics[row - 1][column - 1].ToString() != "." && !int.TryParse(schematics[row - 1][column - 1].ToString(), out _))
            {
                result = true;
            }

            //Check top
            if (row > 0 && schematics[row - 1][column].ToString() != "." && !int.TryParse(schematics[row - 1][column].ToString(), out _))
            {
                result = true;
            }

            //Check upper right
            if (row > 0 && column < schematics[0].Length - 1 && schematics[row - 1][column + 1].ToString() != "." && !int.TryParse(schematics[row - 1][column + 1].ToString(), out _))
            {
                result = true;
            }

            //Check right
            if (column < schematics[0].Length - 1 && schematics[row][column + 1].ToString() != "." && !int.TryParse(schematics[row][column + 1].ToString(), out _))
            {
                result = true;
            }

            //Check lower right
            if (column < schematics[0].Length - 1 && row < schematics.Count - 1 && schematics[row + 1][column + 1].ToString() != "." && !int.TryParse(schematics[row + 1][column + 1].ToString(), out _))
            {
                result = true;
            }

            //Check bottom
            if (row < schematics.Count - 1 && schematics[row + 1][column].ToString() != "." && !int.TryParse(schematics[row + 1][column].ToString(), out _))
            {
                result = true;
            }

            //Check bottom left
            if (row < schematics.Count - 1 && column > 0 && schematics[row + 1][column - 1].ToString() != "." && !int.TryParse(schematics[row + 1][column - 1].ToString(), out _))
            {
                result = true;
            }

            return result;
        }
    }
}
