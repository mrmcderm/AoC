<Query Kind="Program" />

void Main()
{
	var inputValues = File.ReadLines(@"c:\projects\aoc\2017\day1\puzzle2Input.txt").FirstOrDefault();

	var matches = new List<int>();

	for (var i = 0; i < inputValues.Length; i++)
	{
		var currentDigitIndex = i;
		var nextDigitIndex = currentDigitIndex == inputValues.Length - 1 ? 0 : i + 1;
		
		var halfwayPoint = inputValues.Length / 2;
		
		if(currentDigitIndex < halfwayPoint)
		{
			nextDigitIndex = currentDigitIndex + halfwayPoint;
		}
		else
		{
			nextDigitIndex = currentDigitIndex - halfwayPoint;
		}
		

		if (inputValues[currentDigitIndex] == inputValues[nextDigitIndex])
		{
			matches.Add(int.Parse(inputValues[currentDigitIndex].ToString()));
		}
	}

	Console.WriteLine($"Answer: {matches.Sum()}");
}