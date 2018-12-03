<Query Kind="Program" />

void Main()
{
	var rawInput = File.ReadAllText(@"c:\projects\aoc\2015\day2part1Input.txt");

	var rawGiftDimensions = rawInput.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
	
	var totalLinearFeet = 0;
	foreach(var rawGiftDimension in rawGiftDimensions)
	{
		var dimensions = rawGiftDimension.Split('x').Select(_ => int.Parse(_)).OrderBy(_ => _).ToList();
		totalLinearFeet = totalLinearFeet + dimensions[0] * 2 + dimensions[1] * 2 + dimensions[0] * dimensions[1] * dimensions[2];
	}
	
	Console.WriteLine($"Answer: {totalLinearFeet}");
}