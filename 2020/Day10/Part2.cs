using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day10
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }
        public Dictionary<int, int> ArrangementCache = new Dictionary<int, int>();


        public void Solve()
        {
            var answer = 0;
            var adapters = RawInput.Split(Environment.NewLine).Select(_ => int.Parse(_)).OrderBy(_ => _).ToList();
            //adapters.Insert(0, 0);
            //adapters.Add(adapters.Max() + 3);

            answer = GetTotalArrangements(adapters);

            Console.WriteLine("Day 10, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }


        private int GetTotalArrangements(List<int> adapters)
        {
            if (adapters.Count == 1)
                return 1;

            var result = 0;
            var currentAdapter = adapters.Last();
            var nextAdapters = adapters.Where(_ => _ >= currentAdapter - 3 && _ < currentAdapter).ToList();

            foreach (var adapter in nextAdapters)
            {
                var newAdapters = new String(string.Join("|", adapters)).Split("|").Select(_ => int.Parse(_)).ToList();
                newAdapters.RemoveAt(newAdapters.Count - 1);
                var arrangements = GetTotalArrangements(newAdapters);
                result += arrangements;
            }

            return result;
        }
    }
}