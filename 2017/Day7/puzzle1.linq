<Query Kind="Program" />

void Main()
{
	var inputValues = File.ReadLines(@"c:\projects\aoc\2017\day7\test.txt");

	var programs = new List<Program>();

	foreach (var inputValue in inputValues)
	{
		programs.Add(new Program(inputValue));
	}

	foreach (var program in programs)
	{
		
		//DO WORK HERE.
		
		
		
		Console.WriteLine($"{program.Name}: {program.Weight} - {(program.SupportedPrograms != null ? string.Join("|", program.SupportedPrograms) : string.Empty)}");
	}

	var bottomProgram = string.Empty;

	Console.WriteLine($"Answer: {bottomProgram}");
}

public class Program
{
	public string Name { get; set; }

	public int Weight { get; set; }

	public List<string> SupportedPrograms { get; set; }

	public Program(string inputValue)
	{
		var splitInput = inputValue.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

		var splitProgram = splitInput[0].Split('(');

		Name = splitProgram[0].Trim();

		Weight = int.Parse(splitProgram[1].Remove(splitProgram[1].IndexOf(')')));

		if (splitInput.Length > 1)
		{
			SupportedPrograms = splitInput[1].Split(',').Select(_ => _.Trim()).ToList();
		}
	}
}