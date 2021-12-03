using System.Collections;

namespace Aoc._2021.Day03
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var diagnosticNumbers = RawInput.Split(Environment.NewLine).Select(_ => _.ToArray()).ToList();

            var bitLength = diagnosticNumbers[0].Length;
            var bitCounts = new int[bitLength];
            var gammaArray = new BitArray(bitLength);
            var epsilonArray = new BitArray(bitLength);

            foreach (var diagnosticNumber in diagnosticNumbers)
            {
                for(int i = 0; i < bitLength; i++)
                {
                    if(diagnosticNumber[i] == '1')
                    {
                        bitCounts[i]++;
                    }
                }
            }

            for (int i = 0; i < bitLength; i++)
            {
                var bit = bitCounts[i] > diagnosticNumbers.Count / 2;
                gammaArray.Set(i, bit);
                epsilonArray.Set(i, !bit);
            }

            Reverse(gammaArray);
            int[] array = new int[1];
            gammaArray.CopyTo(array, 0);
            var gamma = array[0];

            Reverse(epsilonArray);
            array = new int[1];
            epsilonArray.CopyTo(array, 0);
            var epsilon = array[0];

            answer = gamma * epsilon;

            Console.WriteLine("Day 3, Part 1");
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
