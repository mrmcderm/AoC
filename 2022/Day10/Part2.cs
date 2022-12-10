using System.Globalization;
using System.Text;

namespace Aoc._2022.Day10
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var instructions = RawInput.Split("\r\n");
            var xRegister = 1;
            var cycle = 1;
            var cycleValues = new List<int>
            {
                0,
                1
            };
            var screenRows = new List<StringBuilder>() { new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder() };

            foreach (var instruction in instructions)
            {
                var decomposedInstruction = instruction.Split(" ");

                switch (decomposedInstruction[0])
                {
                    case "noop":
                        cycle++;
                        cycleValues.Add(xRegister);
                        break;
                    case "addx":
                        cycle++;
                        cycleValues.Add(xRegister);
                        cycle++;
                        xRegister += int.Parse(decomposedInstruction[1]);
                        cycleValues.Add(xRegister);
                        break;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    var pixelCenter = cycleValues[(j + 1) + (i * 40)];

                    if (j == pixelCenter - 1 || j == pixelCenter || j == pixelCenter + 1)
                    {
                        screenRows[i].Append("#");
                    }
                    else
                    {
                        screenRows[i].Append(".");
                    }
                }
            }

            foreach (var screenRow in screenRows)
            {
                Console.WriteLine(screenRow.ToString());
            }


            Console.WriteLine("Day 10, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
