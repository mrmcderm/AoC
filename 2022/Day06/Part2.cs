namespace Aoc._2022.Day06
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var dataStream = RawInput;
            var packetSize = 14;

            for (var i = 0; i < dataStream.Length - packetSize; i++)
            {
                var nextSequence = dataStream.Skip(i).Take(packetSize).ToList();
                if (nextSequence.Distinct().Count() >= packetSize)
                {
                    answer = i += packetSize;
                    break;
                }
            }

            Console.WriteLine("Day 6, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
