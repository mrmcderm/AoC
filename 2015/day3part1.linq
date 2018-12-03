<Query Kind="Program" />

void Main()
{
	var rawInput = File.ReadAllText(@"c:\projects\aoc\2015\day3part1Input.txt");
	
	var currentHouse = new House{X = 0, Y = 0};
	var housesVisited = new List<House>();
	housesVisited.Add(new House{X = 0, Y = 0});
	foreach(var instruction in rawInput)
	{
		switch (instruction)
		{
			case '^':
				currentHouse.X++;
				break;
			case 'v':
				currentHouse.X--;
				break;
			case '>':
				currentHouse.Y++;
				break;
			case '<':
				currentHouse.Y--;
				break;
		}
		
		var existingHouse = housesVisited.FirstOrDefault(_ => _.X == currentHouse.X && _.Y == currentHouse.Y);
		if(existingHouse == null)
		{
			housesVisited.Add(new House { X = currentHouse.X, Y = currentHouse.Y});
		}
	}

	Console.WriteLine($"Answer: {housesVisited.Count}");
}

public class House
{
	public int X {get; set;}
	public int Y {get; set;}
}