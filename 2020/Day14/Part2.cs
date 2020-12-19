using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day14
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            long answer = 0;
            var memorySlots = new Dictionary<int, long>();

            var inputs = RawInput.Split(Environment.NewLine).ToList();

            char[] mask = Array.Empty<char>();
            foreach (var input in inputs)
            {
                if (input.StartsWith("mask = "))
                {
                    mask = input[7..].ToArray();
                }
                else
                {
                    var memorySlot = int.Parse(input[4..input.IndexOf(']')]);
                    var memoryValue = int.Parse(input[(input.IndexOf('=') + 2)..]);
                    var newValue = GetMemoryAddresses(memoryValue, mask);
                    //memorySlots[memorySlot] = newValue;
                }
            }

            answer = memorySlots.Values.Sum();

            Console.WriteLine("Day 14, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private static List<long> GetMemoryAddresses(int value, char[] mask)
        {
            var results = new List<long>();
            var valueBits = Convert.ToString(value, 2)
                .PadLeft(36, '0')
                .Select(_ => int.Parse(_.ToString()))
                .ToArray();

            for (int i = 0; i < 36; i++)
            {
                if (mask[i] == 'X')
                    continue;

                valueBits[i] = int.Parse(mask[i].ToString());
            }

            long result = 0;
            for (int i = 0; i < valueBits.Length; i++)
            {
                result *= 2;
                result += valueBits[i];
            }

            return new List<long>() { result };
        }
    }
}