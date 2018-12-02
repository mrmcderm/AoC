<Query Kind="Program" />

void Main()
{
	var inputValues = File.ReadLines(@"c:\projects\aoc\2017\day7\puzzle1Input.txt");

	var programs = new List<Program>();

	foreach (var inputValue in inputValues)
	{
		programs.Add(new Program(inputValue));
	}

	foreach (var program in programs)
	{	
		foreach(var supportedProgramName in program.SupportedProgramNames)
		{
			var supportedProgram = programs.FirstOrDefault(_ => _.Name == supportedProgramName);
			if (supportedProgram != null)
			{
				program.SupportedPrograms.Add(supportedProgram);
			}
		}
		
		Console.WriteLine($"({program.GetLevel()}) {program.Name}: {program.Weight} - {(program.SupportedProgramNames != null ? string.Join("|", program.SupportedProgramNames) : string.Empty)}");
	}
	
	var maxLevel = programs.Max(_ => _.GetLevel());
	var bottomProgram = programs.Where(_ => _.GetLevel() == maxLevel).First();

	Console.WriteLine($"Answer: {bottomProgram.Name}");
}

public class Program
{
	public string Name { get; set; }
	
	public int Weight { get; set; }

	public List<Program> SupportedPrograms { get; set; }
	
	public List<string> SupportedProgramNames {get; set; }

	public Program(string inputValue)
	{
		var splitInput = inputValue.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

		var splitProgram = splitInput[0].Split('(');

		Name = splitProgram[0].Trim();

		Weight = int.Parse(splitProgram[1].Remove(splitProgram[1].IndexOf(')')));

		SupportedPrograms = new List<Program>();
		
		SupportedProgramNames = new List<string>();
		if (splitInput.Length > 1)
		{
			SupportedProgramNames = splitInput[1].Split(',').Select(_ => _.Trim()).ToList();
		}
	}
	
	public int GetLevel()
	{
		var levels = new List<int>();
		if(SupportedPrograms.Count == 0)
		{
			return 0;
		}
		
		foreach(var program in SupportedPrograms)
		{
			levels.Add(program.GetLevel());
		}
		
		return levels.Max() + 1;
	}
}