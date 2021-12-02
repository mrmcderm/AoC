<Query Kind="Program" />

List<Tuple<int, int>> locations = new List<Tuple<int, int>>();
Tuple<int, int> currentLocation = new Tuple<int, int>(0, 0);
bool foundSecondVisit = false;
Tuple<int, int> secondVisit = new Tuple<int, int>(0, 0);

void Main()
{
	var inputValues = File.ReadAllText(@"C:\Users\mmcdermott\source\repos\AoC\2016\Day1Puzzle1.txt").Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries).ToList();
	
	var xCoord = 0;
	var yCoord = 0;
	var bearing = "N";
	
	foreach (var input in inputValues)
	{
		var direction = input[0];
		var distance = int.Parse(input.Substring(1, input.Length - 1));
		if (direction == 'R')
		{
			switch (bearing)
			{
				case "N":
					for (var i = 0; i < distance; i++)
					{
						xCoord++;
						RecordSecondVisit(xCoord, yCoord);
					}
                	bearing = "E";
					break;
				case "E":
					for (var i = 0; i < distance; i++)
					{
						yCoord--;
						RecordSecondVisit(xCoord, yCoord);
					}
					bearing = "S";
					break;
				case "S":
					for (var i = 0; i < distance; i++)
					{
						xCoord--;
						RecordSecondVisit(xCoord, yCoord);
					}
					bearing = "W";
					break;
				case "W":
					for (var i = 0; i < distance; i++)
					{
						yCoord++;
						RecordSecondVisit(xCoord, yCoord);
					}
					bearing = "N";
					break;
			}
		}
		if (direction == 'L')
		{
			switch (bearing)
			{
				case "N":
					for (var i = 0; i < distance; i++)
					{
						xCoord--;
						RecordSecondVisit(xCoord, yCoord);
					}
					bearing = "W";
					break;
				case "E":
					for (var i = 0; i < distance; i++)
					{
						yCoord++;
						RecordSecondVisit(xCoord, yCoord);
					}
					bearing = "N";
					break;
				case "S":
					for (var i = 0; i < distance; i++)
					{
						xCoord++;
						RecordSecondVisit(xCoord, yCoord);
					}
					bearing = "E";
					break;
				case "W":
					for (var i = 0; i < distance; i++)
					{
						yCoord--;
						RecordSecondVisit(xCoord, yCoord);
					}
					bearing = "S";
					break;
			}
		}
	}
	
	Console.WriteLine("Bearing: {0}", bearing);
	Console.WriteLine("X Coord: {0}", xCoord);
	Console.WriteLine("Y Coord: {0}", yCoord);
	Console.WriteLine("Distance: {0}", Math.Abs(xCoord) + Math.Abs(yCoord));
	Console.WriteLine("Second Visit: X={0}, Y={1}, Distance={2}", secondVisit.Item1, secondVisit.Item2, Math.Abs(secondVisit.Item1) + Math.Abs(secondVisit.Item2));

}

public bool AlreadyVisted(List<Tuple<int, int>> locations, Tuple<int, int> currentLocation)
{
	foreach (var location in locations)
	{
		if (location.Item1 == currentLocation.Item1 && location.Item2 == currentLocation.Item2)
		{
			return true;
		}
	}
	
	return false;
}

public void RecordSecondVisit(int xCoord, int yCoord)
{
	var currentLocation = new Tuple<int, int>(xCoord, yCoord);
	if (!foundSecondVisit && AlreadyVisted(locations, currentLocation))
	{
		foundSecondVisit = true;
		secondVisit = new Tuple<int, int>(xCoord, yCoord);
	}
	locations.Add(currentLocation);
}
