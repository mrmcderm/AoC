using System;
using System.Linq;

namespace Aoc._2020.Day12
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }
        public int shipX = 0;
        public int shipY = 0;
        public int waypointX = 10;
        public int waypointY = 1;

        public void Solve()
        {
            var answer = 0;
            var instructions = RawInput.Split(Environment.NewLine).ToList();

            foreach (var instruction in instructions)
            {
                var action = instruction[0];
                var units = int.Parse(instruction[1..]);

                switch (action)
                {
                    case 'N':
                        waypointY += units;
                        break;
                    case 'S':
                        waypointY -= units;
                        break;
                    case 'E':
                        waypointX += units;
                        break;
                    case 'W':
                        waypointX -= units;
                        break;
                    case 'L':
                        switch (units)
                        {
                            case 90:
                                RotateLeft();
                                break;
                            case 180:
                                RotateLeft();
                                RotateLeft();
                                break;
                            case 270:
                                RotateLeft();
                                RotateLeft();
                                RotateLeft();
                                break;
                        }
                        break;
                    case 'R':
                        switch(units)
                        {
                            case 90:
                                RotateRight();
                                break;
                            case 180:
                                RotateRight();
                                RotateRight();
                                break;
                            case 270:
                                RotateRight();
                                RotateRight();
                                RotateRight();
                                break;
                        }
                        break;
                    case 'F':
                        shipX += waypointX * units;
                        shipY += waypointY * units;
                        break;
                }

                Console.WriteLine($"{instruction} Ship: {shipX} {shipY} Waypoint: {waypointX} {waypointY}");
            }

            answer = Math.Abs(shipX) + Math.Abs(shipY);

            Console.WriteLine("Day 12, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private void RotateRight()
        {
            int newX;
            int newY;

            newX = waypointY;
            newY = waypointX;
            waypointX = newX;
            waypointY = -newY;
        }

        private void RotateLeft()
        {
            int newX;
            int newY;

            newX = waypointY;
            newY = waypointX;
            waypointX = -newX;
            waypointY = newY;
        }
    }
}