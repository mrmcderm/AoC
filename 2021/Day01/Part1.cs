namespace Aoc._2021.Day01
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var depths = RawInput.Split("\r\n").Select(_ => int.Parse(_)).ToList();

            for (var i = 0; i < depths.Count; i++)
            {
                if (i == 0)
                    continue;

                if(depths[i] > depths[i-1])
                    answer++;
            }

            Console.WriteLine("Day 1, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
