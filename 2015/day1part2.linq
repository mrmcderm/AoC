<Query Kind="Program" />

void Main()
{
	var rawInput = File.ReadAllText(@"c:\projects\aoc\2015\day1part1Input.txt");
	
	var floor = 0;
	for(var i = 0; i < rawInput.Length; i++)
	{
		if(rawInput[i] == '(')
			floor++;
		else
			floor--;
		
		if(floor == -1)
		{
			Console.WriteLine($"Answer: {i+1}");
			break;
		}
	}
}