using System;
using System.Linq;

namespace Aoc._2020.Day09
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            long answer = 0;
            var preambleLength = 25;
            var inputs = RawInput.Split(Environment.NewLine).Select(_ => long.Parse(_)).ToArray();

            for(int i = preambleLength; i < inputs.Length; i++)
            {
                var currentPointer = i - preambleLength;
                var currentArray = inputs[currentPointer..(currentPointer+preambleLength)];
                var currentNumberToCheck = inputs[i];

                if (!IsValid(currentArray, currentNumberToCheck))
                {
                    answer = currentNumberToCheck;
                    break;
                }
            }
            
            Console.WriteLine("Day 9, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private static bool IsValid(long[] inputArray, long valueToCheck)
        {
            var result = false;

            for (int i = 0; i < inputArray.Length; i++)
            {
                for(int j = 0; j < inputArray.Length; j++)
                {
                    if (inputArray[i] + inputArray[j] == valueToCheck)
                    {
                        result = true;
                        break;
                    }
                }

                if (result)
                    break;
            }

            return result;
        }
    }
}