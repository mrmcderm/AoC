<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Primitives.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Security.dll</Reference>
  <Namespace>System.Runtime.Serialization.Formatters.Binary</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var inputValues = File.ReadLines(@"c:\projects\aoc\2017\day6\puzzle1Input.txt").FirstOrDefault().Split('\t').Select(_ => int.Parse(_)).ToList();

	//var inputValues = new List<int> { 0, 2, 7, 0 };

	var numberOfCycles = 0;

	var currentBank = inputValues;
	var hashCodes = new List<string>();
	string currentBankHashCode;

	//Redistribute
	while (true)
	{
		var largestBlock = currentBank.Max();
		var largestBlockIndex = currentBank.IndexOf(largestBlock);

		currentBank[largestBlockIndex] = 0;

		do
		{
			if (largestBlockIndex == currentBank.Count - 1)
			{
				largestBlockIndex = 0;
			}
			else
			{
				largestBlockIndex++;
			}

			currentBank[largestBlockIndex] = currentBank[largestBlockIndex] + 1;
			largestBlock--;


		} while (largestBlock > 0);

		currentBankHashCode = string.Join("", currentBank);
		
		//Console.WriteLine($"{string.Join("", currentBank)}: {currentBankHashCode}");

		numberOfCycles++;
		if (hashCodes.Contains(currentBankHashCode))
		{
			Console.WriteLine(hashCodes.IndexOf(currentBankHashCode));
			break;
		}
		else
		{
			hashCodes.Add(currentBankHashCode);
		}

	}

	Console.WriteLine($"Answer: {numberOfCycles}");
}