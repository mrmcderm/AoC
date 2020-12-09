using System;
using System.Linq;

namespace Aoc._2020.Day09
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            long answer = 0;

            var inputs = RawInput.Split(Environment.NewLine).Select(_ => long.Parse(_)).ToArray();

            var invalidNumber = GetInvalidNumber(inputs);

            answer = GetEncryptionWeakness(inputs, invalidNumber);

            Console.WriteLine("Day 9, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private static long GetEncryptionWeakness(long[] inputs, long invalidNumber)
        {
            long result = -1;

            for(int i = 0; i < inputs.Length; i++)
            {
                for(int j = i+1; j < inputs.Length; j++)
                {
                    var currentRange = inputs[i..j];
                    var currentRangeSum = currentRange.Sum();
                    if (currentRangeSum == invalidNumber)
                    {
                        return currentRange.Min() + currentRange.Max();
                    }

                    if (currentRangeSum > invalidNumber)
                        break;
                }
            }

            return result;
        }

        private static long GetInvalidNumber(long[] inputs)
        {
            var preambleLength = 25;

            for (int i = preambleLength; i < inputs.Length; i++)
            {
                var currentPointer = i - preambleLength;
                var currentArray = inputs[currentPointer..(currentPointer + preambleLength)];
                var currentNumberToCheck = inputs[i];

                if (!IsValid(currentArray, currentNumberToCheck))
                {
                    return currentNumberToCheck;
                }
            }

            return -1;
        }

        private static bool IsValid(long[] inputArray, long valueToCheck)
        {
            var result = false;

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
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