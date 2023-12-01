namespace Aoc._2023.Day01
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var calibrationLines = RawInput.Split("\r\n");
            var calibrationValues = new List<int>();
            var validDigits = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var digitConversions = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            foreach (var calibrationLine in calibrationLines)
            {
                var digitPositions = new Dictionary<int, string>();
                foreach (var validDigit in validDigits)
                {
                    var indices = calibrationLine.AllIndexesOf(validDigit);
                    if(indices.Any())
                    { 
                        foreach(var index in indices)
                        digitPositions.Add(index, validDigit);
                    }
                }

                if(!int.TryParse(digitPositions[digitPositions.Keys.Min()], out int firstDigit))
                {
                    firstDigit = digitConversions.IndexOf(digitPositions[digitPositions.Keys.Min()]);
                }

                if (!int.TryParse(digitPositions[digitPositions.Keys.Max()], out int lastDigit))
                {
                    lastDigit = digitConversions.IndexOf(digitPositions[digitPositions.Keys.Max()]);
                }

                calibrationValues.Add(int.Parse(firstDigit.ToString() + lastDigit.ToString()));
            }

            var answer = calibrationValues.Sum();

            Console.WriteLine("Day 1, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }

    public static class Extensions
    {        
        public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
        {
            int minIndex = str.IndexOf(searchstring, StringComparison.InvariantCultureIgnoreCase);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length, StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
