<Query Kind="Program" />

void Main()
{
	var inputRows = File.ReadLines(@"c:\projects\aoc\2017\day2\puzzle1Input.txt");

	var answer = 0;
	foreach (var inputRow in inputRows)
	{
		var values = inputRow.Split('\t').Select(n => Convert.ToInt32(n)).ToArray();
		
		for(int i = 0; i < values.Length; i++)
		{
			for(int j = 0; j < values.Length; j++)
			{
				if(i != j && values[i] % values[j] == 0)
				{
					answer = answer + values[i] / values[j];
				}
			}
		}
	}

	Console.WriteLine($"Answer: {answer}");
}