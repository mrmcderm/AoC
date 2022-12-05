﻿using System.Linq;
using System.Text;

namespace Aoc._2022.Day05
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = string.Empty;
            var procedures = RawInput.Split("\r\n").ToList();

            //Initialize Cargo Hold
            /* EXAMPLE INPUT
            var cargoHold = new List<List<string>>()
            {
                new List<string>() { "Z", "N" },
                new List<string>() { "M", "C", "D" },
                new List<string>() { "P" }
            };
            */

            var cargoHold = new List<List<string>>()
            {
                new List<string>() { "F", "D", "B", "Z", "T", "J", "R", "N" },
                new List<string>() { "R", "S", "N", "J", "H" },
                new List<string>() { "C", "R", "N", "J", "G", "Z", "F", "Q" },
                new List<string>() { "F", "V", "N", "G", "R", "T", "Q" },
                new List<string>() { "L", "T", "Q", "F" },
                new List<string>() { "Q", "C", "W", "Z", "B", "R", "G", "N" },
                new List<string>() { "F", "C", "L", "S", "N", "H", "M" },
                new List<string>() { "D", "N", "Q", "M", "T", "J" },
                new List<string>() { "P", "G", "S" }
            };

            Console.WriteLine("Original Layout:");
            DisplayCargoHold(cargoHold);

            // Parse and execute procedures
            for (int j = 1; j <= procedures.Count; j++)
            {
                // Parse
                var subProcedures = procedures[j - 1].Split(" from ");
                var quantity = int.Parse(subProcedures[0].Split("move ")[1]);
                var sourceStack = int.Parse(subProcedures[1].Split(" to ")[0]) - 1;
                var targetStack = int.Parse(subProcedures[1].Split(" to ")[1]) - 1;

                // Execute
                cargoHold[targetStack].AddRange(cargoHold[sourceStack].Pop(quantity));
                
                Console.WriteLine($"After Procedure {j}");
                DisplayCargoHold(cargoHold);
            }

            var topCrates = new StringBuilder();
            foreach (var stack in cargoHold)
            {
                topCrates.Append(stack.Pop());
            }

            answer = topCrates.ToString();

            Console.WriteLine("Day 5, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private static void DisplayCargoHold(List<List<string>> cargoHold)
        {
            foreach (var stack in cargoHold)
            {
                stack.DisplayStack();
            }
        }
    }
}
