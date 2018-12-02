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

            var idComparisons = new List<IdComparison>();
            for (var i = 0; i < ids.Length; i++)
            {
                for (var j = 0; j < ids.Length; j++)
                {
                    //Don't compare to self
                    if (i == j)
                        continue;

                    var deltaCount = GetDeltaCount(ids[i], ids[j]);
                    idComparisons.Add(new IdComparison { Id1 = ids[i], Id2 = ids[j], DeltaCount = deltaCount });

                }
            }

            //Visually compare, no need to write code
            foreach (var idComparison in idComparisons.Where(_ => _.DeltaCount == 1))
            {
                Console.WriteLine(idComparison.Id1);
                Console.WriteLine(idComparison.Id2);
            }
        }

        private static int GetDeltaCount(string firstId, string secondId)
        {
            return firstId.Where((t, i) => t != secondId[i]).Count();
        }
    }

    public class IdComparison
    {
        public string Id1 { get; set; }

        public string Id2 { get; set; }

        public int DeltaCount { get; set; }
    }
}