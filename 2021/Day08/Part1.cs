using System.IO.Pipes;

namespace Aoc._2021.Day08
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var lines = RawInput.Split(Environment.NewLine);
            var outputValues = new Dictionary<string, int>();
            
            foreach (var line in lines)
            {
                var parsedLine = line.Split(" | ");
                var lineOutputValues = parsedLine[1].Split(" ");

                foreach(var value in lineOutputValues)
                {
                    if(value.Length == 2 || value.Length == 3 || value.Length == 4 || value.Length == 7)
                    {
                        if(outputValues.ContainsKey(value))
                        {
                            outputValues[value]++; 
                        }
                        else
                        {
                            outputValues.Add(value, 1);
                        }
                    }
                }
            }

            answer = outputValues.Select(_ => _.Value).Sum();
            
            Console.WriteLine("Day 8, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
