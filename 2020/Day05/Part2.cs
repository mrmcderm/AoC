using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day05
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var boardingPasses = RawInput.Split("\n").ToList();
            var seatIds = new List<int>();

            foreach (var boardingPass in boardingPasses)
            {
                int range;
                var lowRow = 0;
                var highRow = 127;
                var lowColumn = 0;
                var highColumn = 7;
                var rowRules = boardingPass.Substring(0, 7);
                var columnRules = boardingPass.Substring(7, 3);

                foreach (var rule in rowRules)
                {
                    range = highRow - lowRow;
                    switch (rule)
                    {
                        case 'F':
                            highRow = (highRow - range / 2) - 1;
                            break;
                        case 'B':
                            lowRow = (lowRow + range / 2) + 1;
                            break;
                        default:
                            break;
                    }
                }

                foreach (var rule in columnRules)
                {
                    range = highColumn - lowColumn;
                    switch (rule)
                    {
                        case 'L':
                            highColumn = (highColumn - range / 2) - 1;
                            break;
                        case 'R':
                            lowColumn = (lowColumn + range / 2) + 1;
                            break;
                        default:
                            break;
                    }
                }

                seatIds.Add((highRow * 8) + highColumn);
            }

            seatIds = seatIds.OrderBy(_ => _).ToList();
            for (var i = 0; i < seatIds.Count - 1; i++)
            {
                if(seatIds[i + 1] - seatIds[i] == 2)
                { 
                    answer = seatIds[i] + 1;
                }
            }

            Console.WriteLine("Day 5, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}