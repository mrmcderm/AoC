using System;
using System.Linq;

namespace Aoc._2020.Day12
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var currentHeading = 90;
            var x = 0;
            var y = 0;

            var instructions = RawInput.Split(Environment.NewLine).ToList();

            foreach(var instruction in instructions)
            {
                var action = instruction[0];
                var units = int.Parse(instruction[1..]);

                switch(action)
                {
                    case 'N':
                        y += units;
                        break;
                    case 'S':
                        y -= units;
                        break;
                    case 'E':
                        x += units;
                        break;
                    case 'W':
                        x -= units;
                        break;
                    case 'L':
                        currentHeading -= units;
                        if (currentHeading < 0)
                            currentHeading += 360;
                        break;
                    case 'R':
                        currentHeading += units;
                        if (currentHeading >= 360)
                            currentHeading -= 360;
                        break;
                    case 'F':
                        switch(currentHeading)
                        {
                            case 0:
                                y += units;
                                break;
                            case 180:
                                y -= units;
                                break;
                            case 90:
                                x += units;
                                break;
                            case 270:
                                x -= units;
                                break;
                        }
                        break;
                }

                Console.WriteLine($"{instruction} ({(currentHeading == 0 ? "N" : currentHeading == 90 ? "E" : currentHeading == 180 ? "S" : "W")}) {x} {y}");
            }

            answer = Math.Abs(x) + Math.Abs(y);

            Console.WriteLine("Day 12, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}