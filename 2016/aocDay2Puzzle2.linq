<Query Kind="Program" />

void Main()
{
	var inputValues = File.ReadLines(@"c:\projects\AoC\Day2Puzzle1.txt");
	var keyPad = new List<List<string>>()
		{
			new List<string>() { string.Empty, string.Empty, "1", string.Empty, string.Empty },
			new List<string>() { string.Empty, "2", "3", "4", string.Empty },
			new List<string>() { "5", "6", "7", "8", "9" },
			new List<string>() { string.Empty, "A", "B", "C", string.Empty },
			new List<string>() { string.Empty, string.Empty, "D", string.Empty, string.Empty }
		};
	var position = new KeyPadPosition() { XCoord = 0, YCoord = 2 };
	var nextPosition = new KeyPadPosition { XCoord = 0, YCoord = 2 };
	var newY = 0;
	var newX = 0;

	foreach (var input in inputValues)
	{
		foreach (var instruction in input)
		{
			switch (instruction)
			{
				case 'U':
					newY = position.YCoord > 0 ? position.YCoord - 1 : 0;
					nextPosition = new KeyPadPosition() { XCoord = position.XCoord, YCoord = newY };
					if (keyPad[nextPosition.YCoord][nextPosition.XCoord] != string.Empty)
					{
						position.XCoord = nextPosition.XCoord;
						position.YCoord = nextPosition.YCoord;
					}
					break;
				case 'D':
					newY = position.YCoord < 4 ? position.YCoord + 1 : 4;
					nextPosition = new KeyPadPosition() { XCoord = position.XCoord, YCoord = newY};
					if (keyPad[nextPosition.YCoord][nextPosition.XCoord] != string.Empty)
					{
						position.XCoord = nextPosition.XCoord;
						position.YCoord = nextPosition.YCoord;
					}
					break;
				case 'L':
					newX = position.XCoord > 0 ? position.XCoord - 1 : 0;
					nextPosition = new KeyPadPosition() { XCoord = newX, YCoord = position.YCoord };
					if (keyPad[nextPosition.YCoord][nextPosition.XCoord] != string.Empty)
					{
						position.XCoord = nextPosition.XCoord;
						position.YCoord = nextPosition.YCoord;
					}
					break;
				case 'R':
					newX = position.XCoord < 4 ? position.XCoord + 1 : 4;
					nextPosition = new KeyPadPosition() { XCoord = newX, YCoord = position.YCoord };
					if (keyPad[nextPosition.YCoord][nextPosition.XCoord] != string.Empty)
					{
						position.XCoord = nextPosition.XCoord;
						position.YCoord = nextPosition.YCoord;
					}
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



	