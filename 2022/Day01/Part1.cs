namespace Aoc._2022.Day01
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var splitInput = RawInput.Split("\r\n").Select(_ => int.Parse(_)).ToList();

            Console.WriteLine("Day 1, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
