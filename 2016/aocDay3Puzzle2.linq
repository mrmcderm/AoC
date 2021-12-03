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

	for (var i = 0; i < inputValues.Count; i++)
	{
		if (offset + 2 < inputValues.Count)
		{
			for (var j = 0; j < 3; j++)
			{
				if (inputValues[0 + offset][j] + inputValues[1 + offset][j] > inputValues[2 + offset][j]
					&& inputValues[1 + offset][j] + inputValues[2 + offset][j] > inputValues[0 + offset][j]
					&& inputValues[2 + offset][j] + inputValues[0 + offset][j] > inputValues[1 + offset][j])
				{
					possibleTriangles++;
	            }
			}

			offset = offset + 3;
		}
	}

	Console.WriteLine(possibleTriangles);

}