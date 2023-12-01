namespace Aoc._2023.Day01
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var calibrationLines = RawInput.Split("\r\n");
            var calibrationValues = new List<int>();

            foreach(var calibrationLine in calibrationLines)
            {
                var firstDigit = string.Empty;
                var lastDigit = string.Empty;

                foreach(var digit in calibrationLine)
                {
                    if(int.TryParse(digit.ToString(), out int digitValue))
                    {
                        firstDigit = digit.ToString();
                        break;
                    }
                }

                foreach(var digit in calibrationLine.Reverse())
                {
                    if(int.TryParse(digit.ToString(), out int digitValue))
                    {
                        lastDigit = digit.ToString();
                        break;
                    }
                }

                calibrationValues.Add(int.Parse(firstDigit + lastDigit));
            }   

            var answer = calibrationValues.Sum();

            Console.WriteLine("Day 1, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
