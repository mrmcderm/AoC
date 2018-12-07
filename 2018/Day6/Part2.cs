using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC._2018.Day6
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 6, Part 2");

            //Parse the input
            var targets = RawInput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(_ => new Coordinate
                {
                    X = int.Parse(_.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim()),
                    Y = int.Parse(_.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim())
                })
                .ToList();

            //Name the targets for readability later.
            for (var i = 0; i < targets.Count; i++)
            {
                targets[i].Name = Encoding.ASCII.GetString(new[] { (byte)(i + 65) });
                targets[i].Area = 1;
            }

            //Create and hydrate the grid
            var xMax = targets.Max(_ => _.X) + 1;
            var yMax = targets.Max(_ => _.Y) + 1;
            var grid = new Coordinate[xMax, yMax];
            for (var y = 0; y < yMax; y++)
            {
                for (var x = 0; x < xMax; x++)
                {
                    //Is there a target at this coordinate?
                    var thisTarget = targets.FirstOrDefault(_ => _.Y == y && _.X == x);
                    if (thisTarget != null)
                    {
                        grid[x, y] = thisTarget;
                    }

                    //If not, find the closest target...
                    else
                    {
                        var thisCoordinate = new Coordinate { X = x, Y = y, Name = "." };

                        //Calcualte all the manhattan distances from this coordinate to each target
                        var targetDistances = targets.Select(_ => new { Distance = GetManhattanDistance(_, thisCoordinate), Target = _ }).ToList();

                        //Find the minimum distance
                        var minDistance = targetDistances.Min(_ => _.Distance);

                        //Find the target corresponding to the minimum distance.  We may get more than 1
                        var minDistanceTargets = targetDistances.Where(_ => _.Distance == minDistance).ToList();

                        //If we only get one, set the closest target for this coordinate
                        if (minDistanceTargets.Count == 1)
                        {
                            //Set the coordinate's name to be the lower case of the closest target's name for readability
                            thisCoordinate.Name = Encoding.ASCII.GetString(new[] { (byte)(Encoding.ASCII.GetBytes(minDistanceTargets[0].Target.Name)[0] + 32) });
                            thisCoordinate.ClosestTarget = minDistanceTargets[0].Target.Name;
                        }

                        //Set the grid
                        grid[x, y] = thisCoordinate;
                    }
                }
            }

            //Go through each coordinate.  Find ths sum of all manhattan distances to each target
            var safeCoordinates = new HashSet<Coordinate>();
            for (var y = 0; y < yMax; y++)
            {
                for (var x = 0; x < xMax; x++)
                {
                    var totalManhattanDistances = targets.Aggregate(0, (current, target) => current + GetManhattanDistance(grid[x, y], target));
                    if (totalManhattanDistances < 10000)
                    {
                        safeCoordinates.Add(grid[x, y]);
                    }
                }
            }

            Console.WriteLine($"Answer: {safeCoordinates.Count}");
        }

        private static int GetManhattanDistance(Coordinate c1, Coordinate c2)
        {
            return Math.Abs(c2.X - c1.X) + Math.Abs(c2.Y - c1.Y);
        }
    }
}
