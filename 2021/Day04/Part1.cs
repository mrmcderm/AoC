using System.Text;

namespace Aoc._2021.Day04
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var parsedInput = RawInput.Split(Environment.NewLine).ToList();
            var drawnNumbers = parsedInput[0].Split(",").Select(_ => int.Parse(_)).ToList();
            var parsedInputLength = parsedInput.Count;
            var bingoBoards = new List<BingoBoard>();

            var start = 2;
            var end = 6;
            while (start <= parsedInputLength - 5)
            {
                var inputValues = parsedInput.Skip(start).Take(5).ToList();
                start += 6;
                bingoBoards.Add(new BingoBoard(inputValues));
            }

            foreach (var drawnNumber in drawnNumbers)
            {
                Console.WriteLine($"Drawn Number: {drawnNumber}");
                Console.WriteLine("---------------");
                foreach (var bingoBoard in bingoBoards)
                {
                    var winner = bingoBoard.MarkBoard(drawnNumber);

                    if (winner)
                    {
                        var boardSum = bingoBoard.GetBoardSum();
                        answer = boardSum * drawnNumber;
                        break;
                    }

                    Console.WriteLine(bingoBoard);
                }
                if (answer > 0)
                {
                    break;
                }
                Console.WriteLine("---------------");
            }

            Console.WriteLine("Day 4, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        public class BingoBoard
        {
            public int[][] GridValues { get; set; }

            public BingoBoard(IList<string> inputValues)
            {
                GridValues = new int[5][];

                for (int i = 0; i < inputValues.Count; i++)
                {
                    var row = inputValues[i]
                        .Split(" ")
                        .Where(_ => _ != String.Empty)
                        .Select(_ => int.Parse(_))
                        .ToArray();

                    GridValues[i] = new int[5];

                    Array.Copy(row, GridValues[i], 5);
                }
            }

            public bool MarkBoard(int number)
            {
                foreach (var row in GridValues)
                {
                    var numberIndex = Array.IndexOf(row, number);
                    if (numberIndex > -1)
                    {
                        row[numberIndex] = -1;

                        if (IsBingo())
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            public bool IsBingo()
            {
                var result = false;

                foreach (var row in GridValues)
                {
                    if (row.Sum() == -5)
                    {
                        result = true;
                        break;
                    }
                }

                if (!result)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var sum = 0;

                        foreach (var row in GridValues)
                        {
                            sum += row[i];
                        }

                        if (sum == -5)
                        {
                            result = true;
                            break;
                        }
                    }
                }

                return result;
            }

            public int GetBoardSum()
            {
                var result = 0;
                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        if (GridValues[i][j] != -1)
                        {
                            result += GridValues[i][j];
                        }
                    }
                }

                return result;
            }

            public override string ToString()
            {
                var result = new StringBuilder();
                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        if(GridValues[i][j] == -1)
                        {
                            result.Append(" * ");
                        }
                        else if (GridValues[i][j] > 9 || GridValues[i][j] < 0)
                        {
                            result.Append($"{GridValues[i][j]} ");
                        }
                        else
                        {
                            result.Append($" {GridValues[i][j]} ");
                        }
                    }

                    result.Append("\r\n");
                }

                return result.ToString();
            }
        }
    }
}
