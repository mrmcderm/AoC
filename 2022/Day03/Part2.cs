namespace Aoc._2022.Day03
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var backpacks = RawInput.Split("\r\n").ToList();

            var groupId = 0;

            while(groupId < backpacks.Count - 1) 
            {
                var groupBackpacks = backpacks.Skip(groupId).Take(3).ToList();

                var intermediateItems = groupBackpacks[0].Intersect(groupBackpacks[1]);
                var commonItem = intermediateItems.Intersect(groupBackpacks[2]).First();

                //Convert to ASCII value then convert to puzzle priority
                var priority = ((int)commonItem) - 96;

                //Puzzle has upper case chars greater priority, so need to convert again
                if (priority < 1)
                {
                    priority += 58;
                }

                answer += priority;
                groupId += 3;
            }


            Console.WriteLine("Day 3, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
