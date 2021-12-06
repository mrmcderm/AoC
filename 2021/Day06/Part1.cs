using System.Text;

namespace Aoc._2021.Day06
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var lanternFish = RawInput.Split(Environment.NewLine)[0].Split(",").Select(_ => int.Parse(_)).ToList();
            var days = 80;

            //Console.WriteLine($"Initial State: {string.Join(",", lanternFish)}");
            for(int i = 1; i <= days; i++)
            {
                var newLanternFish = new List<int>();
                for(int j = 0; j < lanternFish.Count; j++)
                {
                    lanternFish[j]--;

                    if(lanternFish[j] == -1)
                    {
                        lanternFish[j] = 6;
                        newLanternFish.Add(8);
                    }
                }

                lanternFish.AddRange(newLanternFish);

                /*
                var sb = new StringBuilder();
                sb.Append("After ");
                var dayCount = i < 10 ? $" {i} " : $"{i} ";
                sb.Append(dayCount);
                var unit = i == 1 ? "day:  " : "days: ";
                sb.Append(unit);
                sb.Append(string.Join(",", lanternFish));
                Console.WriteLine(sb.ToString());
                */
            }

            answer = lanternFish.Count();
            Console.WriteLine("Day 6, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
