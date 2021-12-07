namespace Aoc._2021.Day07
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var initialCrabPositions = RawInput.Split(",").Select(_ => int.Parse(_)).ToArray();
            var maxPosition = initialCrabPositions.Max();
            var fuelCosts = new int[maxPosition];

            for(var i = 0; i < maxPosition; i++)
            {
                foreach(var position in initialCrabPositions)
                {
                    fuelCosts[i] += Math.Abs(position - i);
                }
            }

            answer = fuelCosts.Min();
            
            Console.WriteLine("Day 7, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
