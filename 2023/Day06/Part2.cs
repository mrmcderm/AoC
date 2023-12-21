namespace Aoc._2023.Day06
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var raceDetails = new List<(long duration, long maxDistance)> { (46857582, 208141212571410) };
            var winningDistances = new List<int>();

            foreach (var (duration, maxDistance) in raceDetails)
            {
                var winningDistance = 0;
                for (var timeHeld = duration; timeHeld >= 0; timeHeld--)
                {
                    var distanceTravelled = timeHeld * (duration - timeHeld);
                    if (distanceTravelled > maxDistance)
                    {
                        winningDistance++;
                    }
                }
                winningDistances.Add(winningDistance);
            }

            answer = winningDistances.Aggregate(1, (a, b) => a * b);

            Console.WriteLine("Day 6, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
