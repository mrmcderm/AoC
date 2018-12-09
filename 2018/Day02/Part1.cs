using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2018.Day2
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 2, Part 1");

            var result = RawInput;

            var ids = result.Split("\r\n");

            var doubles = 0;
            var triples = 0;
            foreach (var id in ids)
            {
                if (HasMultiples(id, 2))
                {
                    doubles++;
                }

                if (HasMultiples(id, 3))
                {
                    triples++;
                }
            }

            Console.WriteLine($"Checksum: {doubles * triples}");
        }

        private static bool HasMultiples(string id, int multiple)
        {
            var letterCounts = new List<LetterCount>();

            foreach (var letter in id)
            {
                var exisingLetterCount = letterCounts.FirstOrDefault(_ => _.Letter == letter);
                if (exisingLetterCount != null)
                {
                    exisingLetterCount.Count++;
                }
                else
                {
                    letterCounts.Add(new LetterCount { Count = 1, Letter = letter });
                }
            }

            return letterCounts.Any(_ => _.Count == multiple);
        }
    }

    public class LetterCount
    {
        public char Letter { get; set; }
        public int Count { get; set; }
    }
}