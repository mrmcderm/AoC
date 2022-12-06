namespace Aoc._2022.Day06
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var dataStream = RawInput;
            var packetSize = 4;

            for(var i = 0; i < dataStream.Length - packetSize; i++)
            {
                var nextSequence = dataStream.Skip(i).Take(packetSize).ToList();
                if(nextSequence.Distinct().Count() >= packetSize)
                {
                    answer = i += packetSize;
                    break;
                }
            }
            
            Console.WriteLine("Day 6, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
