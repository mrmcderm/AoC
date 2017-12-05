<Query Kind="Program" />

void Main()
{
	var answerGrid = new List<int[]>
			{
				new int[26],
				new int[26],
				new int[26],
				new int[26],
				new int[26]
			};
			
	const int asciiOffset = 97;

	var inputValues = File.ReadLines(@"c:\projects\input.txt").ToList();

	foreach (var input in inputValues)
	{
		var inputBytes = Encoding.ASCII.GetBytes(input);

		for (var i = 0; i < answerGrid.Count; i++)
		{
			answerGrid[i][inputBytes[i] - asciiOffset]++;
		}
	}

	foreach (var answerArray in answerGrid)
	{
		Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(answerArray.ToList().IndexOf(answerArray.Max()) + asciiOffset) }));
	}
}