namespace Aoc._2023.Day02
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var games = RawInput.Split("\r\n");

            foreach (var game in games)
            {
                var id = int.Parse(game.Split(":")[0].Split(" ")[1]);
                var subsets = game.Split(": ")[1].Split("; ");
                var maxRed = 0;
                var maxBlue = 0;
                var maxGreen = 0;

                foreach (var subset in subsets)
                {
                    var colorCounts = subset.Split(", ");
                    foreach (var colorCount in colorCounts)
                    {
                        var values = colorCount.Split(" ");
                        var color = values[1];
                        var count = int.Parse(values[0]);
                        switch (color)
                        {
                            case "red":
                                if (count > maxRed)
                                    maxRed = count;
                                break;
                            case "blue":
                                if (count > maxBlue)
                                    maxBlue = count;
                                break;
                            case "green":
                                if (count > maxGreen)
                                    maxGreen = count;
                                break;
                        }
                    }
                }

                answer += maxRed * maxBlue * maxGreen;
            }

            Console.WriteLine("Day 2, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
