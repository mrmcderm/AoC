using System;

namespace Aoc._2019.Day01
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            decimal answer = 0;
            var massValues = RawInput.Split(Environment.NewLine);

            foreach (var massValue in massValues)
            {
                answer += Math.Round((decimal)(Convert.ToInt32(massValue) / 3), MidpointRounding.ToZero) - 2;
            }

            Console.WriteLine("Day 1, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
