using System.Collections;

namespace Aoc._2021.Day03
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var diagnosticNumbers = RawInput.Split(Environment.NewLine).Select(_ => _.ToArray()).ToList();

            var bitLength = diagnosticNumbers[0].Length;
            var bitCounts = new int[bitLength];

            foreach (var diagnosticNumber in diagnosticNumbers)
            {
                for (int i = 0; i < bitLength; i++)
                {
                    if (diagnosticNumber[i] == '1')
                    {
                        bitCounts[i]++;
                    }
                }
            }

            for (int i = 0; i < bitLength; i++)
            {
                if (diagnosticNumbers.Count > 1)
                {
                    var bit = bitCounts[i] > diagnosticNumbers.Count / 2;

                    var newDiagnosticNumbers = new List<char[]>();

                    foreach (var diagnosticNumber in diagnosticNumbers)
                    {
                        if ((bit && diagnosticNumber[i] == '1') || !bit && diagnosticNumber[i] == '0')
                        {
                            newDiagnosticNumbers.Add(diagnosticNumber);
                        }
                    }

                    diagnosticNumbers = newDiagnosticNumbers;
                }
            }



            Console.WriteLine("Day 3, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        public void Reverse(BitArray array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }
    }
}
