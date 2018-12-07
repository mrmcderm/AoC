using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2018.Day7
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 7, Part 1");
            
            var input = RawInput.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(_ => _.Replace(" must be finished before step ", ","))
                .Select(_ => _.Replace("Step ", string.Empty))
                .Select(_ => _.Replace(" can begin.", string.Empty))
                .Select(_ => new Instruction {Name = _.Split(",")[1], PredecessorName = _.Split(",")[0]})
                .ToList();


            var predecessors = input.Select(_ => _.PredecessorName).ToList();
            var instructions = input.Select(_ => _.Name).ToList();
            var lastInstruction = instructions.Where(c2 => predecessors.All(c1 => c1 != c2)).ToList()[0];
            var result = new List<string>();
            while (input.Count > 0)
            {
                //Get all the predecessor instructions
                predecessors = input.Select(_ => _.PredecessorName).ToList();

                //Get all the instructions
                instructions = input.Select(_ => _.Name).ToList();

                //Get all the instructions that do not have a predecessor - these are ready - order them by alpha
                var candidates = predecessors.Where(c1 => instructions.All(c2 => c2 != c1)).Distinct().OrderBy(_ => _).ToList();

                //for each value in the input, pull out the values where the predecessor is equal to our top candidate
                foreach (var value in input.ToList())
                {
                    if (value.PredecessorName == candidates[0])
                    {
                        input.Remove(value);
                    }
                }

                //Add the candidate to the results
                result.Add(candidates[0]);
            }

            result.Add(lastInstruction);

            Console.WriteLine($"Answer: {string.Join(string.Empty, result.ToArray())}");
        }

        private class Instruction
        {
            public string Name { get; set; }
            public string PredecessorName { get; set; }
        }
    }
}
 