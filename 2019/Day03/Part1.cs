using System;
using System.Collections.Generic;

namespace Aoc._2019.Day03
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var wireDefinitions = RawInput.Split(Environment.NewLine);
            var wire1Instructions = wireDefinitions[0].Split(",");
            var wire2Instructions = wireDefinitions[1].Split(",");
            var gridPoints = new Dictionary<(int, int), int>();

            var endOfWire1 = (0, 0);
            foreach(var wireInstruction in wire1Instructions)
            {
                var direction = wireInstruction[0];
                var length = int.Parse(wireInstruction[1..]);

                switch(direction)
                {
                    case 'R':
                        for(var i = 0; i < length; i++)
                        {
                            var gridPoint = (endOfWire1.Item1 + i, endOfWire1.Item2);
                            if(gridPoints.ContainsKey(gridPoint))
                            {
                                gridPoints[gridPoint]++;
                            }
                            else
                            {
                                gridPoints.Add(gridPoint, 1);
                            }
                        }
                        break;
                    default:
                        break;

                }
            }

            Console.WriteLine("Day 3, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private void BuildWire(string[] wireInstructions)

        private int CalcualteManhattanDistance((int, int) coord1, (int, int) coord2)
        {
            return Math.Abs(coord1.Item1 - coord2.Item1) + Math.Abs(coord1.Item2 - coord2.Item2);
        }
    }
}
