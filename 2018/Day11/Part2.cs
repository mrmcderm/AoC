using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AoC._2018.Day11
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }
        //public Coord MaxPowerLevel = new Coord { PowerLevel = 0, X = 0, Y = 0, Z = 0 };
        public List<Coord> PowerLevels = new List<Coord>();
        public const int SerialNumber = 18;
        public const int GridSize = 300;

        public void Solve()
        {
            Console.WriteLine("Day 11, Part 1");

            var tasks = new List<Task>();
            for (var z = 1; z < GridSize; z++)
            {
                tasks.Add(Task.Factory.StartNew(() => GetTotalPowerLevel(z)));
            }
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("tasks done");

            var MaxPowerLevel = PowerLevels.First(_ => _.PowerLevel == PowerLevels.Max(__ => __.PowerLevel));
            Console.WriteLine($"Anwser: {MaxPowerLevel.Y},{MaxPowerLevel.X},{MaxPowerLevel.Z}");
        }

        private void GetTotalPowerLevel(int z)
        {
            for (var y = 1; y <= GridSize; y++)
            {
                if (y + (z - 1) > GridSize)
                    continue;

                for (var x = 1; x <= GridSize; x++)
                {
                    if (x + (z - 1) > GridSize)
                        continue;

                    var totalPower = 0;
                    for (var i = 0; i < z; i++)
                    {
                        for (var j = 0; j < z; j++)
                        {
                            totalPower = totalPower + GetPowerLevel(y + i, x + j, SerialNumber);
                        }
                    }

                    PowerLevels.Add(new Coord { X = x, Y = y, Z = z, PowerLevel = totalPower });
                }
            }
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
    }

    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int PowerLevel { get; set; }
    }
}