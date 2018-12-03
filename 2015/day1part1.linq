<Query Kind="Program" />

void Main()
{
	var rawInput = File.ReadAllText(@"c:\projects\aoc\2015\day1part1Input.txt");
	
	var floor = 0;
	foreach(var instruction in rawInput)
	{
		if(instruction == '(')
			floor++;
		else
			floor--;
	}

	Console.WriteLine($"Answer: {floor}");
}