using System;
using System.Linq;

namespace Aoc._2019.Day02
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var program = RawInput.Split(",").Select(_ => int.Parse(_)).ToArray();
            program[1] = 12;
            program[2] = 2;
            var pointer = 0;
            while(pointer < program.Length)
            {
                var instruction = program.Skip(pointer).Take(4).ToArray();

                switch (instruction[0])
                {
                    case 99:
                        answer = program[0];
                        Console.WriteLine("Program Terminated");
                        break;
                    case 1:
                        program[instruction[3]] = program[instruction[1]] + program[instruction[2]];
                        break;
                    case 2:
                        program[instruction[3]] = program[instruction[1]] * program[instruction[2]];
                        break;
                    default:
                        Console.WriteLine("Exception Occured: Unexpected OpCode");
                        break;
                }
                pointer += 4;
            }

            Console.WriteLine("Day 2, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
