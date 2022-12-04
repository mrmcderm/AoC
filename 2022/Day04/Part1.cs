namespace Aoc._2022.Day04
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var elfPairs = RawInput.Split("\r\n").ToList();

            foreach ( var elfPair in elfPairs ) 
            {
                var assignments = elfPair.Split(",");

                var elf1Min = int.Parse(assignments[0].Split("-")[0]);
                var elf1Max = int.Parse(assignments[0].Split("-")[1]);

                var elf2Min = int.Parse(assignments[1].Split("-")[0]);
                var elf2Max = int.Parse(assignments[1].Split("-")[1]);

                if ((elf1Min <= elf2Min && elf1Max >= elf2Max) || (elf2Min <= elf1Min && elf2Max >= elf1Max)) 
                {
                    answer++;
                }
            }

            Console.WriteLine("Day 4, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
