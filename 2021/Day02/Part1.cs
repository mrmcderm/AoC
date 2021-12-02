namespace Aoc._2021.Day02
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var input = RawInput.Split(Environment.NewLine).ToList().Select(_ => _.Split(' ')).ToList();
            var position = 0;
            var depth = 0;

            foreach(var item in input)
            {
                switch(item[0])
                {
                    case "forward":
                        position += int.Parse(item[1]);
                        break;
                    case "down":
                        depth += int.Parse(item[1]);
                        break;
                    case "up":
                        depth -= int.Parse(item[1]);
                        break;
                    default:
                        break;
                }
            }

            var answer = position * depth;

            Console.WriteLine("Day 2, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
