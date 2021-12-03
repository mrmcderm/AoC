<Query Kind="Program" />

void Main()
{
	var inputValues = new List<int[]>();

	var possibleTriangles = 0;
	var offset = 0;

	foreach (var input in File.ReadLines(@"C:\Users\mmcdermott\source\repos\AoC\2016\Day3Puzzle1.txt").ToList())
	{
		var initialStrings = (input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
		inputValues.Add(new int[] { int.Parse(initialStrings[0]), int.Parse(initialStrings[1]), int.Parse(initialStrings[2]) });
	}

	foreach(var inputValue in inputValues)
	{
		if((inputValue[0] + inputValue[1] > inputValue[2]) 
			&& (inputValue[2] + inputValue[0] > inputValue[1])
			&& (inputValue[1] + inputValue[2] > inputValue[0]))
		{
			possibleTriangles++;
			continue;
		}
	}

	Console.WriteLine(possibleTriangles);
}