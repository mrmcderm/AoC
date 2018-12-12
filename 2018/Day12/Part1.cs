using System;
using System.Collections.Generic;

namespace AoC._2018.Day12
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 12, Part 1");

            //Parse the input
            var input = RawInput.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            var initialState = input[0].Replace("initial state: ", string.Empty);
            var rules = new List<string>();
            for (var i = 2; i < input.Length; i++)
            {
                rules.Add(input[i]);
            }





            Console.WriteLine(initialState);
            foreach (var rule in rules)
            {
                Console.WriteLine(rule);
            }
        }
    }
}