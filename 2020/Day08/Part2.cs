using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day08
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var instructions = RawInput.Split(Environment.NewLine).Select(_ => new Instruction(_)).ToList();

            for(var i = 0; i < instructions.Count; i++)
            {
                if(instructions[i].Operation == "nop")
                {
                    instructions[i].Operation = "jmp";
                    var result = CheckInstructionSet(instructions);
                    if (result > -1)
                    {
                        answer = result;
                        break;
                    }
                }

                if (instructions[i].Operation == "jmp")
                {
                    instructions[i].Operation = "nop";
                    var result = CheckInstructionSet(instructions);
                    if (result > -1)
                    {
                        answer = result;
                        break;
                    }
                }

                instructions = RawInput.Split(Environment.NewLine).Select(_ => new Instruction(_)).ToList();
            }

            Console.WriteLine("Day 8, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private int CheckInstructionSet(List<Instruction> instructions)
        {
            var accumulator = 0;
            var instructionCount = 1;

            for (var i = 0; i < instructions.Count; i++)
            {
                var currentInstruction = instructions[i];
                if (currentInstruction.ExecutionCount > 0)
                {
                    return -1;
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

            return accumulator;
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