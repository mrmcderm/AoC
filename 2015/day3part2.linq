<Query Kind="Program" />

void Main()
{
	var rawInput = File.ReadAllText(@"C:\Users\mmcdermott\source\repos\AoC\2015\day3part1Input.txt");
	
	var santaCurrentHouse = new House{X = 0, Y = 0};
	var roboSantaCurrentHouse = new House{X = 0, Y = 0};
	var santaHousesVisited = new List<House>();
	var roboSantaHousesVisited = new List<House>();
	santaHousesVisited.Add(new House{X = 0, Y = 0});
	roboSantaHousesVisited.Add(new House{X = 0, Y = 0});
	
	var santasTurn = true;
	foreach(var instruction in rawInput)
	{
		if (santasTurn)
		{
			Console.WriteLine($"Santa's turn: {instruction}");
			switch (instruction)
			{
				case '^':
					santaCurrentHouse.X++;
					break;
				case 'v':
					santaCurrentHouse.X--;
					break;
				case '>':
					santaCurrentHouse.Y++;
					break;
				case '<':
					santaCurrentHouse.Y--;
					break;
			}

			var existingHouse = santaHousesVisited.FirstOrDefault(_ => _.X == santaCurrentHouse.X && _.Y == santaCurrentHouse.Y);
			if (existingHouse == null)
			{
				santaHousesVisited.Add(new House { X = santaCurrentHouse.X, Y = santaCurrentHouse.Y });
			}
		}
		else
		{
			Console.WriteLine($"Robot's turn: {instruction}");
			switch (instruction)
			{
				case '^':
					roboSantaCurrentHouse.X++;
					break;
				case 'v':
					roboSantaCurrentHouse.X--;
					break;
				case '>':
					roboSantaCurrentHouse.Y++;
					break;
				case '<':
					roboSantaCurrentHouse.Y--;
					break;
			}

			var existingHouse = roboSantaHousesVisited.FirstOrDefault(_ => _.X == roboSantaCurrentHouse.X && _.Y == roboSantaCurrentHouse.Y);
			if (existingHouse == null)
			{
				roboSantaHousesVisited.Add(new House { X = roboSantaCurrentHouse.X, Y = roboSantaCurrentHouse.Y });
			}

		}

		santasTurn = !santasTurn;
	}

	Console.WriteLine($"Answer: {santaHousesVisited.Count + roboSantaHousesVisited.Count - 1}");
}

public class House
{
	public int X {get; set;}
	public int Y {get; set;}
}