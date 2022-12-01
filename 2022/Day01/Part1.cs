namespace Aoc._2022.Day01
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            // Code Golf Solution
            var answer = RawInput.Split("\r\n\r\n")
                .Select(_ => _.Split("\r\n")
                .Select(_ => int.Parse(_)))
                .Select(_ => _.Sum())
                .OrderByDescending(_ => _)
                .First();

            /* ORIGINAL SOLUTION
            var splitInput = RawInput.Split("\r\n").Select(_ => _).ToList();
            var elves = new List<int>();

            var currentCalorieCount = 0;
            foreach (var input in splitInput)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    elves.Add(currentCalorieCount);
                    currentCalorieCount = 0;
                }
                else
                {
                    currentCalorieCount += int.Parse(input);
                }
            }

            answer = elves.Max();
            */

            Console.WriteLine("Day 1, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
