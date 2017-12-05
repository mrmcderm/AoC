<Query Kind="Program" />

void Main()
{
	var totalTLSSupport = 0;
	foreach (var input in File.ReadLines(@"c:\projects\AoC\Day7Puzzle1.txt").ToList())
	{
		var supportsTLS = false;
		var hypernetSequences = ExtractHypernetSequencs(input);
		var sansHypernetSequences = StripHypernetSequences(input);		
		if (!SupportsTLS(hypernetSequences) && SupportsTLS(sansHypernetSequences))
		{
			totalTLSSupport++;
			supportsTLS = true;
			Console.WriteLine("{0}", input);
			Console.WriteLine("{0}:{1}", sansHypernetSequences, hypernetSequences);
			Console.WriteLine();
		}
	}
	Console.WriteLine(totalTLSSupport);
}
// Define other methods and classes here

public string StripHypernetSequences(string input)
{
	var result = new StringBuilder();
	var decomposed = input.Split('[');
	foreach (var section in decomposed)
	{
		var index = section.IndexOf("]") + 1;
		if (section.Contains("]"))
		{
			result.Append(section.Substring(index, section.Length - index));
		}
		else
		{
			result.Append(section);
		}
	}

	return result.ToString();
}

public string ExtractHypernetSequencs(string input)
{
	var result = new StringBuilder();
	var decomposed = input.Split(']');

	for (var i = 0; i < decomposed.Length - 1; i++)
	{
		if (decomposed[i].Contains('['))
        {
			result.Append(decomposed[i].Substring(decomposed[i].IndexOf('[') + 1, decomposed[i].Length - (decomposed[i].IndexOf('[') + 1))); 
		}
	}

	return result.ToString();
}

public bool SupportsTLS(string input)
{
	for (var i = 0; i < input.Length - 3; i++)
	{
		if(input[i] == input[i + 3] 
			&& input[i + 1] != input[i]
			&& input[i + 1] == input[i + 2])
		return true;
	}
	
	return false;	
}
