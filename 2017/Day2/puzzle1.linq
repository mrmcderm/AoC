<Query Kind="Program" />

void Main()
{
	var inputRows = File.ReadLines(@"c:\projects\aoc\2017\day2\puzzle1Input.txt");
	
	var answer = 0;
	foreach(var inputRow in inputRows)
	{
		var values = inputRow.Split('\t').Select(n => Convert.ToInt32(n)).ToArray();
		answer = answer + (values.Max() - values.Min());
	}

	Console.WriteLine($"Answer: {answer}");
}