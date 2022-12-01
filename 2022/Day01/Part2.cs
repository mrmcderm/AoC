namespace Aoc._2022.Day01
{
    internal class Part2 : IPuzzle
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
                .Take(3)
                .Sum();

            /* ORIGINAL SOLUTION
            var answer = 0;
            var splitInput = RawInput.Split("\r\n").Select(_ => _).ToList();
            var elves = new List<int>();

            //TODO: This logic is poor - it requires an empty line at the end of the puzzle input.
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

            answer = elves.OrderByDescending(_ => _).Take(3).Sum();
            */

            Console.WriteLine("Day 1, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
