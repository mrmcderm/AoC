using System;
using System.Linq;

namespace Aoc._2020.Day08
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var accumulator = 0;
            var instructions = RawInput.Split(Environment.NewLine).Select(_ => new Instruction(_)).ToList();
            var instructionCount = 1;

            for(var i = 0; i < instructions.Count; i++)
            {
                var currentInstruction = instructions[i];
                if (currentInstruction.ExecutionCount > 0)
                {
                    answer = accumulator;
                    break;
                }

                switch (currentInstruction.Operation)
                {
                    case "nop":
                        break;
                    case "acc":
                        accumulator += currentInstruction.Value;
                        break;
                    case "jmp":
                        i += currentInstruction.Value - 1;
                        break;
                }

                currentInstruction.ExecutionCount = instructionCount;
                instructionCount++;
            }

            foreach(var instruction in instructions)
            {
                Console.WriteLine(instruction);
            }

            Console.WriteLine("Day 8, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private class Instruction
        {
            public string Operation { get; set; }

            public int Value { get; set; }

            public int ExecutionCount { get; set; }

            public Instruction(string rawInput)
            {
                ExecutionCount = 0;
                var components = rawInput.Split(" ");
                Operation = components[0];
                Value = int.Parse(components[1]);
            }

            public override string ToString()
            {
                return $"{Operation} {(Value >= 0 ? "+" : string.Empty)}{Value}{(Math.Abs(Value).ToString().Length > 1 ? " | " : "  | ")}{(ExecutionCount > 0 ? ExecutionCount : string.Empty)}";
            }
        }
    }
}