namespace Aoc._2021.Day07
{
    public class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var initialCrabPositions = RawInput.Split(",").Select(_ => int.Parse(_)).ToArray();
            var maxPosition = initialCrabPositions.Max();
            var fuelCosts = new int[maxPosition];

            for (var i = 0; i < maxPosition; i++)
            {
                foreach (var position in initialCrabPositions)
                {
                    fuelCosts[i] += GetFuelCost(Math.Abs(position - i));
                }
            }

            answer = fuelCosts.Min();

            Console.WriteLine("Day 7, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private int GetFuelCost(int delta)
        {
            if(delta == 0)
                return 0;

            return delta + GetFuelCost(delta - 1);
        }
    }
}
