namespace Aoc._2023.Day06
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            //var raceDetails = new List<(int duration, int maxDistance)> { (7, 9), (15, 40), (30, 200) };
            var raceDetails = new List<(int duration, int maxDistance)> { (46, 208), (85, 1412), (75, 1257), (82, 1410) };
            var winningDistances = new List<int>();

            foreach (var raceDetail in raceDetails)
            {
                var winningDistance = 0;
                for (var timeHeld = raceDetail.duration; timeHeld >= 0; timeHeld--)
                {
                    var distanceTravelled = timeHeld * (raceDetail.duration - timeHeld);
                    if (distanceTravelled > raceDetail.maxDistance)
                    {
                        winningDistance++;
                    }
                }
                winningDistances.Add(winningDistance);
            }

            answer = winningDistances.Aggregate(1, (a, b) => a * b);

            Console.WriteLine("Day 6, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private static int GetDistance(int secondsHeld, int raceDuration)
        {
            var velocity = secondsHeld;

            var distance = velocity * (raceDuration - secondsHeld);

            return distance;
        }
    }
}
