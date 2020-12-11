using System;
using System.Linq;

namespace Aoc._2020.Day10
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var adapters = RawInput.Split(Environment.NewLine).Select(_ => int.Parse(_)).OrderBy(_ => _).ToList();
            var oneJoltDiffs = 0;
            var threeJoltDiffs = 1;

            var currentAdapter = 0;

            while (currentAdapter < adapters.Max())
            {
                var smallestSupportedAdapter = adapters.Where(_ => _ > currentAdapter && _ <= currentAdapter + 3).Min();

                if(smallestSupportedAdapter - currentAdapter == 1)
                {
                    oneJoltDiffs++;
                }
                else
                {
                    threeJoltDiffs++;
                }

                currentAdapter = smallestSupportedAdapter;
            }

            answer = oneJoltDiffs * threeJoltDiffs;
                        
            Console.WriteLine("Day 10, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}