<Query Kind="Program" />

void Main()
{
	var rawInput = File.ReadAllText(@"c:\projects\aoc\2015\day2part1Input.txt");

	var rawGiftDimensions = rawInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
	
	var totalSquareFootage = 0;
	//2*l*w + 2*w*h + 2*h*l
	foreach(var rawGiftDimension in rawGiftDimensions)
	{
		var dimensions = rawGiftDimension.Split('x').Select(_ => int.Parse(_)).OrderBy(_ => _).ToList();
		var paperNeeded = 2* dimensions[0] * dimensions[1] + 2 * dimensions[1] * dimensions[2] + 2 * dimensions[0] * dimensions[2];
		var slack = dimensions[0] * dimensions[1];
		totalSquareFootage = totalSquareFootage + (paperNeeded + slack);
	}
	
	Console.WriteLine($"Answer: {totalSquareFootage}");
}