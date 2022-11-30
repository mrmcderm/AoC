namespace Aoc._2022.Day01
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var depths = RawInput.Split("\r\n").Select(_ => int.Parse(_)).ToList();


            Console.WriteLine("Day 1, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
