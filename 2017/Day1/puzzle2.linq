<Query Kind="Program" />

void Main()
{
	var inputValues = File.ReadLines(@"c:\projects\aoc\2017\day1\puzzle1Input.txt").FirstOrDefault();

	var matches = new List<int>();

	for (var i = 0; i < inputValues.Length; i++)
	{
		var j = i;
		var k = j == inputValues.Length - 1 ? 0 : i + 1;

		if (inputValues[j] == inputValues[k])
		{
			matches.Add(int.Parse(inputValues[j].ToString()));
		}
	}

	Console.WriteLine($"Answer: {matches.Sum()}");
}