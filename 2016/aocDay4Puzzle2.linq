<Query Kind="Program" />



void Main()
{
	var sectorIDSum = 0;
	foreach (var input in File.ReadLines(@"C:\Users\mmcdermott\source\repos\AoC\2016\Day4Puzzle1.txt").ToList())
	{
		List<LetterCount> letterCounts = new List<LetterCount>();
		var components = input.Split('-');
		var sectorID = 0;
		var checkSum = string.Empty;
		foreach (var component in components)
		{
			if (!component.Contains("["))
			{
				foreach (var letter in component)
				{
					UpsertLetters(letterCounts, letter.ToString());
				}
			}
			else
			{
				var subComponents = component.Split('[');				
				sectorID = int.Parse(subComponents[0]);
				checkSum = subComponents[1].Substring(0, subComponents[1].Length - 1);				
			}
		}

		var sortedLetters = letterCounts.OrderByDescending(_ => _.Count).ThenBy(_ => _.Letter).ToList();
		if (checkSum.Contains(sortedLetters[0].Letter)
			&& checkSum.Contains(sortedLetters[1].Letter)
			&& checkSum.Contains(sortedLetters[2].Letter)
			&& checkSum.Contains(sortedLetters[3].Letter)
			&& checkSum.Contains(sortedLetters[4].Letter))
		{
			var roomName = input.Substring(0, input.IndexOf('['));
			var roomNameComponents = roomName.Split('-');
			var shiftValue = int.Parse(roomNameComponents[roomNameComponents.Length - 1]);

			Console.Write("{0}: ", shiftValue);
			for (var i = 0; i < roomNameComponents.Length - 1; i++)
			{
				var decryptedWord = ShiftWord(roomNameComponents[i], shiftValue);
				
				if (decryptedWord == "northpole" || decryptedWord == "object" )
                {

					Console.Write("{0} ", decryptedWord);
				}
				
			}
			Console.WriteLine();
		}
	}
}

public void UpsertLetters(List<LetterCount> letterCounts, string letter)
{
	var letterCount = letterCounts.SingleOrDefault(_ => _.Letter == letter);
	if (letterCount != null)
	{
		letterCount.Count++;
		return;
	}
	
	letterCounts.Add(new LetterCount(letter, 1));
}

public string ShiftWord(string word, int shiftValue)
{
	var result = word;
	var resultArray = new List<byte>();
	var wordBytes = Encoding.ASCII.GetBytes(word);
	var foo = shiftValue % 26;

	foreach (var wordByte in wordBytes)
	{
		var newByte = wordByte + shiftValue % 26;
		if (newByte > 122)
		{
			newByte = newByte - 26;
		}
		resultArray.Add((byte)(newByte));
	}
	
	var newWord = Encoding.ASCII.GetString(resultArray.ToArray());
	return newWord;	
}

public class LetterCount
{
	public string Letter { get; set; }
	public int Count { get; set;}
	
	public LetterCount(string letter, int count)
	{
			Letter = letter;
			Count = count;
	}
}

