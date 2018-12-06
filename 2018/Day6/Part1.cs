using System;
using System.Linq;
using System.Text;

namespace AoC._2018.Day6
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        /*
        The device on your wrist beeps several times, and once again you feel like you're falling.

        "Situation critical," the device announces. "Destination indeterminate. Chronal interference detected. 
        Please specify new target coordinates."

        The device then produces a list of coordinates (your puzzle input). Are they places it thinks are safe 
        or dangerous? It recommends you check manual page 729. The Elves did not give you a manual.

        If they're dangerous, maybe you can minimize the danger by finding the coordinate that gives the 
        largest distance from the other points.

        Using only the Manhattan distance, determine the area around each coordinate by counting the number 
        of integer X,Y locations that are closest to that coordinate (and aren't tied in distance to any other coordinate).

        Your goal is to find the size of the largest area that isn't infinite. For example, consider the 
        following list of coordinates:

        1, 1
        1, 6
        8, 3
        3, 4
        5, 5
        8, 9
        If we name these coordinates A through F, we can draw them on a grid, putting 0,0 at the top left:

        ..........
        .A........
        ..........
        ........C.
        ...D......
        .....E....
        .B........
        ..........
        ..........
        ........F.
        This view is partial - the actual grid extends infinitely in all directions. Using the Manhattan distance, each location's closest coordinate can be determined, shown here in lowercase:

        aaaaa.cccc
        aAaaa.cccc
        aaaddecccc
        aadddeccCc
        ..dDdeeccc
        bb.deEeecc
        bBb.eeee..
        bbb.eeefff
        bbb.eeffff
        bbb.ffffFf
        Locations shown as . are equally far from two or more coordinates, and so they don't count as being closest to any.

        In this example, the areas of coordinates A, B, C, and F are infinite - while not shown here, their areas extend forever outside the visible grid. However, the areas of coordinates D and E are finite: D is closest to 9 locations, and E is closest to 17 (both including the coordinate's location itself). Therefore, in this example, the size of the largest area is 17.

        What is the size of the largest area that isn't infinite?
        */

        public void Solve()
        {
            Console.WriteLine("Day 6, Part 1");

            //Parse the input
            var locations = RawInput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(_ => new Coordinate
                {
                    X = int.Parse(_.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim()),
                    Y = int.Parse(_.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim())
                })
                .ToList();

            //Name the coordinates for readability later.
            for (var i = 0; i < locations.Count; i++)
            {
                locations[i].Name = Encoding.ASCII.GetString(new[] { (byte)(i + 65) });
            }

            //Create and map the grid
            var xMax = locations.Max(_ => _.X) + 1;
            var yMax = locations.Max(_ => _.Y) + 1;
            var grid = new Coordinate[xMax, yMax];
            for (var y = 0; y < yMax; y++)
            {
                for (var x = 0; x < xMax; x++)
                {
                    //Is there a location at this coordinate?
                    var thisLocation = locations.FirstOrDefault(_ => _.Y == y && _.X == x);
                    if (thisLocation != null)
                    {
                        grid[x, y] = thisLocation;
                    }
                    //If not, find the closest location...
                    else
                    {
                        Coordinate closestLocation = new Coordinate{Name = "9", X = 0, Y = 0};
                        var currentShortestDistance = 0;
                        var thisCoordinate = new Coordinate { X = x, Y = y };
                        foreach (var location in locations)
                        {
                            //Get the manhattan distance from each location to this current coordinate
                            var distance = GetManhattanDistance(location, thisCoordinate);

                            //If the distance is shorter than the previous, set this new location to be closest
                            if (distance < currentShortestDistance)
                            {
                                currentShortestDistance = distance;
                                closestLocation = location;
                            }

                            //TODO: may need to worry about coordinates that are equidistant from a location here
                        }

                        //Set the coordinate's name to be the lower case of the closest location's name
                        thisCoordinate.Name = Encoding.ASCII.GetString(new[] { (byte)(Encoding.ASCII.GetBytes(closestLocation.Name)[0] - 26) });
                        grid[x, y] = thisCoordinate;
                    }
                }
            }



            //Display the grid
            for (var y = 0; y < yMax; y++)
            {
                for (var x = 0; x < xMax; x++)
                {
                    Console.Write(grid[x, y] != null ? grid[x, y].Name : ".");
                }
                Console.WriteLine();
            }
        }

        private static int GetManhattanDistance(Coordinate c1, Coordinate c2)
        {
            return Math.Abs(c2.X - c1.X) + Math.Abs(c2.Y - c1.Y);
        }

    }
    public class Coordinate
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
