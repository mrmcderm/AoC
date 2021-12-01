namespace Aoc._2021.Day01
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var depths = RawInput.Split("\r\n").Select(_ => int.Parse(_)).ToList();
            var measurementWindows = new List<int>();

            for (var i = 0; i < depths.Count; i++)
            {
                var measurementWindow = depths.Skip(i).Take(3).ToList();

                if (measurementWindow.Count == 3)
                    measurementWindows.Add(measurementWindow.Sum());

            }

            for (var i = 0; i < measurementWindows.Count; i++)
            {
                if (i == 0)
                    continue;

                if (measurementWindows[i] > measurementWindows[i - 1])
                    answer++;
            }

            Console.WriteLine("Day 1, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
