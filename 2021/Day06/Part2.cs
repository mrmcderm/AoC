using System.Numerics;

namespace Aoc._2021.Day06
{
    public class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            long answer = 0;
            var lanternFish = RawInput.Split(Environment.NewLine)[0].Split(",").Select(_ => int.Parse(_)).ToList();
            var days = 256;
            var fishCounts = new Dictionary<int, long>();

            //Initialize dictionary to no fish
            for (int i = 0; i < 9; i++)
            {
                fishCounts.Add(i, 0);
            }

            //Initialize dictionary to initial state
            foreach (var fish in lanternFish)
            {
                fishCounts[fish]++;
            }

            Console.WriteLine($"Initial State: {string.Join(",", fishCounts.Select(_ => _.Value).ToArray())}");
            for (int i = 1; i <= days; i++)
            {
                //Every zero fish will create a new fish
                var newFish = fishCounts[0];

                //loop through and shift all the timers
                for (int j = 1; j < 9; j++)
                {
                    fishCounts[j - 1] = fishCounts[j];
                }

                //New fish have a timer of 8
                fishCounts[8] = newFish;

                //fish that created new fish get reset to 6
                fishCounts[6] = fishCounts[6] + newFish;

                if (i == 1)
                {
                    Console.WriteLine($"After  1 day:  {string.Join(",", fishCounts.Select(_ => _.Value).ToArray())}");
                }
                else
                {
                    if (i < 10)
                    {
                        Console.WriteLine($"After  {i} days: {string.Join(",", fishCounts.Select(_ => _.Value).ToArray())}");
                    }
                    else
                    {
                        Console.WriteLine($"After {i} days: {string.Join(",", fishCounts.Select(_ => _.Value).ToArray())}");
                    }
                }
            }

            answer = fishCounts.Sum(_ => _.Value);

            Console.WriteLine("Day 6, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
