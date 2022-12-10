namespace Aoc._2022.Day10
{
    public class Part1 : IPuzzle
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

            answer = cycleValues[20] * 20 + cycleValues[60] * 60 + cycleValues[100] * 100 + cycleValues[140] * 140 + cycleValues[180] * 180 + cycleValues[220] * 220;

            Console.WriteLine("Day 10, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
