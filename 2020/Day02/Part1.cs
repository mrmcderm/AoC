using System;
using System.Linq;

namespace Aoc._2020.Day02
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            foreach (var input in RawInput.Split("\n"))
            {
                var components = input.Split(" ");
                var counts = components[0].Split("-");

                var rule = new PasswordRule()
                {
                    Lowest = int.Parse(counts[0]),
                    Highest = int.Parse(counts[1]),
                    RequiredCharacter = components[1][0],
                    Password = components[2]
                };

                if(IsValid(rule))
                {
                    answer++;
                }
            }

            Console.WriteLine("Day 2, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private bool IsValid(PasswordRule rule)
        {
            var groups = rule.Password.GroupBy(_ => _);
            foreach(var group in groups)
            {
                var count = group.Count();
                if(group.Key == rule.RequiredCharacter && rule.Lowest <= count && count <= rule.Highest)
                {
                    return true;
                }
            }

            return false;
        }

        private class PasswordRule
        {
            public int Lowest { get; set; }

            public int Highest { get; set; }

            public char RequiredCharacter { get; set; }

            public string Password { get; set; }
        }
    }
}