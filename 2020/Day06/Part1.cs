using System;
using System.Linq;

namespace Aoc._2020.Day06
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = RawInput
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(_ => _.Replace(Environment.NewLine, string.Empty).Distinct().ToList())
                .Sum(_ => _.Count);

            Console.WriteLine("Day 6, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}