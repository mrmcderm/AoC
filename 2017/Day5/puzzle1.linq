<Query Kind="Program" />

void Main()
{
	var inputRows = File.ReadLines(@"c:\projects\aoc\2017\day5\puzzle1Input.txt").Select(_ => int.Parse(_)).ToList();
	
	//var inputRows = new List<int>{0,3,0,1,-3};
	
	var numberOfMoves = 0;
	var position = 0;

	do
	{
		var jump = inputRows[position];
		inputRows[position] = inputRows[position] + 1;
		position = position + jump;
		numberOfMoves++;
	}
	while(position < inputRows.Count);

	Console.WriteLine($"Answer: {numberOfMoves}");
}