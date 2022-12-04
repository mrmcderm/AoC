﻿namespace Aoc._2022.Day04
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var elfPairs = RawInput.Split("\r\n").ToList();

            foreach (var elfPair in elfPairs)
            {
                var assignments = elfPair.Split(",");

                var elf1Min = int.Parse(assignments[0].Split("-")[0]);
                var elf1Max = int.Parse(assignments[0].Split("-")[1]);

                var elf2Min = int.Parse(assignments[1].Split("-")[0]);
                var elf2Max = int.Parse(assignments[1].Split("-")[1]);

                if (((elf1Max >= elf2Max) && (elf1Min <= elf2Max)) || ((elf2Max >= elf1Max) && (elf2Min <= elf1Max)))
                {
                    answer++;
                }
            }

            Console.WriteLine("Day 4, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
