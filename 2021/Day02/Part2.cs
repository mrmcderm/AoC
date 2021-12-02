namespace Aoc._2021.Day02
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var input = RawInput.Split(Environment.NewLine).ToList().Select(_ => _.Split(' ')).ToList();
            var position = 0;
            var depth = 0;
            var aim = 0;

            foreach (var item in input)
            {
                switch (item[0])
                {
                    case "forward":
                        var unit = int.Parse(item[1]);
                        position += unit;
                        depth += aim * unit;
                        break;
                    case "down":
                        aim += int.Parse(item[1]);
                        break;
                    case "up":
                        aim -= int.Parse(item[1]);
                        break;
                    default:
                        break;
                }
            }

            var answer = position * depth;

            Console.WriteLine("Day 2, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
