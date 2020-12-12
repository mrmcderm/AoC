using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day10
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }
        public Dictionary<int, long> ArrangementCache = new Dictionary<int, long>();
        public List<int> adapters;
        public int max;

        public void Solve()
        {
            long answer = 0;
            adapters = RawInput.Split(Environment.NewLine).Select(_ => int.Parse(_)).OrderBy(_ => _).ToList();
            adapters.Insert(0, 0);
            adapters.Add(adapters.Max() + 3);
            max = adapters.Max();

            answer = GetTotalArrangements(0);

            Console.WriteLine("Day 10, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }


        private long GetTotalArrangements(int i)
        {
            long answer = 0;

            if(i == max)
            {
                return 1;
            }

            if (adapters.Any(_ => _ == i + 1))
            {
                if (ArrangementCache.ContainsKey(i + 1))
                {
                    answer += ArrangementCache[i + 1];
                }
                else
                {
                    var result = GetTotalArrangements(i + 1);
                    answer += result;
                    ArrangementCache.Add(i + 1, result);
                }
            }

            if (adapters.Any(_ => _ == i + 2))
            {
                if (ArrangementCache.ContainsKey(i + 2))
                {
                    answer += ArrangementCache[i + 2];
                }
                else
                {
                    var result = GetTotalArrangements(i + 2);
                    answer += result;
                    ArrangementCache.Add(i + 2, result);
                }
            }

            if (adapters.Any(_ => _ == i + 3))
            {
                if (ArrangementCache.ContainsKey(i + 3))
                {
                    answer += ArrangementCache[i + 3];
                }
                else
                {
                    var result = GetTotalArrangements(i + 3);
                    answer += result;
                    ArrangementCache.Add(i + 3, result);
                }
            }

            return answer;
        }
    }
}