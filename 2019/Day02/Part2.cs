using System;
using System.Linq;

namespace Aoc._2019.Day02
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var targetOutput = 19690720;

            for (var i = 0; i < 100; i++)
            {
                for (var j = 0; j < 100; j++)
                {
                    var program = RawInput.Split(",").Select(_ => int.Parse(_)).ToArray();
                    program[1] = i;
                    program[2] = j;
                    var pointer = 0;
                    while (pointer < program.Length)
                    {
                        var instruction = program.Skip(pointer).Take(4).ToArray();

                        switch (instruction[0])
                        {
                            case 99:
                                if (program[0] == targetOutput)
                                {
                                    answer = 100 * i + j;
                                    Console.WriteLine("Program Terminated");
                                    Console.WriteLine("Day 2, Part 1");
                                    Console.WriteLine($"Answer: {answer}");
                                    return;
                                }
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
                }
            }
        }
    }
}
