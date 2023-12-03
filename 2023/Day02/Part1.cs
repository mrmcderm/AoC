using System.Drawing;

namespace Aoc._2023.Day02
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var games = RawInput.Split("\r\n");
            var validGames = new List<int>();

            foreach (var game in games)
            {
                var isValid = true;
                var id = int.Parse(game.Split(":")[0].Split(" ")[1]);

                var subsets = game.Split(": ")[1].Split("; ");

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
                            case "blue":
                                if (count > 14)
                                {
                                    isValid = false;
                                    continue;
                                }                                
                                break;

                            case "red":
                                if (count > 12)
                                {
                                    isValid = false;
                                    continue;
                                }
                                break;

                            case "green":
                                if (count > 13)
                                {
                                    isValid = false;
                                    continue;
                                }
                                break;

                            default:
                                break;

                        }
                    }
                }

                if (isValid)
                {
                    validGames.Add(id);
                }
            }

            var answer = validGames.Sum();

            Console.WriteLine("Day 2, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
