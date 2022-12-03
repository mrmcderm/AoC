namespace Aoc._2022.Day03
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var backpacks = RawInput.Split("\r\n").ToList();

            foreach (var backpack in backpacks) 
            {
                var compartmentSize = backpack.Length / 2;
                var compartmentA = backpack.Substring(0, compartmentSize);
                var compartmentB = backpack.Substring(compartmentSize);

                var commonItem = compartmentA.Intersect(compartmentB).First();

                //Convert to ASCII value then convert to puzzle priority
                var priority = ((int)commonItem) - 96;

                //Puzzle has upper case chars greater priority, so need to convert again
                if(priority < 1)
                {
                    priority += 58;
                }

                answer += priority;
            }

            Console.WriteLine("Day 3, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
