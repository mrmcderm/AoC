<Query Kind="Program" />

void Main()
{
	var inputValues = File.ReadLines(@"C:\Users\mmcdermott\source\repos\AoC\2016\Day2Puzzle1.txt");
	var keyPad = new List<List<int>>() { new List<int>() { 1, 2, 3 }, new List<int>() { 4, 5, 6 }, new List<int>() { 7, 8, 9 } };
	var position = new KeyPadPosition() { XCoord = 1, YCoord = 1 };

	foreach (var input in inputValues)
	{
		foreach (var instruction in input)
		{
			switch (instruction)
			{
				case 'U':
				if(position.YCoord > 0)
					position.YCoord--;
				break;
				case 'D':
				if(position.YCoord < 2)
					position.YCoord++;
				break;
				case 'L':
				if(position.XCoord > 0)
					position.XCoord--;
				break;
				case 'R':
				if(position.XCoord < 2)
					position.XCoord++;
				break;				
			}
		}
		
		Console.WriteLine(keyPad[position.YCoord][position.XCoord]);
	}
}

public class KeyPadPosition
{
	public int XCoord { get; set; }
	public int YCoord { get; set; }	
}



	