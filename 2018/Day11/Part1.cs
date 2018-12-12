using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2018.Day11
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 11, Part 1");

            const int serialNumber = 1309;
            const int gridSize = 300;
            var powerLevels = new List<Coord>();
            for (var y = 1; y <= gridSize; y++)
            {
                if (y + 2 > gridSize)
                    continue;

                for (var x = 1; x <= gridSize; x++)
                {
                    if (x + 2 > gridSize)
                        continue;

                    var totalPower = 0;
                    for (var i = 0; i < 3; i++)
                    {
                        for (var j = 0; j < 3; j++)
                        {
                            totalPower = totalPower + GetPowerLevel(y + i, x + j, serialNumber);
                        }
                    }

                    powerLevels.Add(new Coord{X = x, Y = y, PowerLevel = totalPower});
                }
            }

            var answer = powerLevels.First(_ => _.PowerLevel == powerLevels.Max(__ => __.PowerLevel));
            Console.WriteLine($"Anwser: {answer.X},{answer.Y}");
        }

        private static int GetPowerLevel(int x, int y, int serialNumber)
        {
            var rackId = x + 10;
            var powerLevel = rackId * y;
            powerLevel = powerLevel + serialNumber;
            powerLevel = powerLevel * rackId;
            powerLevel = Math.Abs(powerLevel / 100 % 10);
            return powerLevel - 5;
        }

        private class Coord
        {
            public int X { get; set; }
            public int Y { get; set; }

            public int PowerLevel { get; set; }
        }
    }
}