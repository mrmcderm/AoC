<Query Kind="Program" />

void Main()
{
	var inputRows = File.ReadLines(@"c:\projects\aoc\2017\day4\puzzle1Input.txt");
	var validPassphrases = 0;
	var valid = true;

	foreach (var inputRow in inputRows)
	{
		var dictionary = new Dictionary<string, string>();
		valid = true;
		
		foreach (var word in inputRow.Split(' '))
		{
			var orderedWord = string.Concat(word.OrderBy(_ => _));
			try
			{
				dictionary.Add(orderedWord, orderedWord);
			}
			catch (Exception ex)
			{
				valid = false;
			}
		}

		if (valid)
			validPassphrases++;
	}

	Console.WriteLine($"Answer: {validPassphrases}");
}