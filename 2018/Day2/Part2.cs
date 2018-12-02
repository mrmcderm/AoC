using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2018.Day2
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 2, Part 2");

            var result = RawInput;

            var ids = result.Split("\r\n");

            var comparisons = new List<Comparison>();
            for (var i = 0; i < ids.Length; i++)
            {
                for (var j = 0; j < ids.Length; j++)
                {
                    //Don't compare to self
                    if (i == j)
                        continue;

                    var delta = Delta(ids[i], ids[j]);
                    comparisons.Add(new Comparison { Id1 = ids[i], Id2 = ids[j], Delta = delta });

                }
            }

            foreach (var comparison in comparisons.Where(_ => _.Delta == 1))
            {
                Console.WriteLine(comparison.Id1);
                Console.WriteLine(comparison.Id2);
            }
        }

        private int Delta(string firstId, string secondId)
        {
            return firstId.Where((t, i) => t != secondId[i]).Count();
        }
    }

    public class Comparison
    {
        public string Id1 { get; set; }

        public string Id2 { get; set; }

        public int Delta { get; set; }
    }
}