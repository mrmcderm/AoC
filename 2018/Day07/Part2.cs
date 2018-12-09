using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC._2018.Day7
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 7, Part 2");

            var availableWorkers = 5;
            var secondsElapsed = -1;
            const int baseTime = 60;

            var instructionRules = RawInput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(_ => _.Replace(" must be finished before step ", ","))
                .Select(_ => _.Replace("Step ", string.Empty))
                .Select(_ => _.Replace(" can begin.", string.Empty))
                .Select(_ => new InstructionRule
                {
                    InstructionName = _.Split(",")[1],
                    PredecessorInstructionName = _.Split(",")[0],
                })
                .ToList();

            var remainingInstructions = Part1.SortInstructions(RawInput);
            var completedInstructions = new List<string>();
            var instructionsBeingWorked = new List<ActiveInstruction>();

            Console.WriteLine("Second   Worker 1   Worker 2   Done");
            while (remainingInstructions.Count > 0 || instructionsBeingWorked.Count > 0)
            {
                //Cycle the clock
                secondsElapsed++;

                //Determine if any instructions have been completed, and if so, finalize them
                foreach (var instructionBeingWorked in instructionsBeingWorked.ToList())
                {
                    instructionBeingWorked.TimeRemaining--;

                    if (instructionBeingWorked.TimeRemaining >= 1)
                        continue;

                    availableWorkers++;
                    instructionsBeingWorked.Remove(instructionBeingWorked);
                    completedInstructions.Add(instructionBeingWorked.Name);
                }

                //Determine if we have any remaining instructions, and if so, if we can start them
                foreach (var instruction in remainingInstructions.ToList())
                {
                    //Do we even have any workers availale?
                    if (availableWorkers <= 0)
                        continue;
                    
                    //Does this instruction have a predecessor yet to be started or in-flight?
                    //We need to find this instruction's rules
                    var canStartThisInstruction = true;
                    var rules = instructionRules.Where(_ => _.InstructionName == instruction).ToList();
                    foreach (var rule in rules)
                    {
                        if (remainingInstructions.Contains(rule.PredecessorInstructionName) || instructionsBeingWorked.Select(_ => _.Name).Contains(rule.PredecessorInstructionName))
                        {
                            canStartThisInstruction = false;
                        }
                    }

                    if (!canStartThisInstruction)
                        continue;

                    //Start the instruction
                    instructionsBeingWorked.Add(new ActiveInstruction
                    {
                        Name = instruction,
                        TimeRemaining = (byte) (Encoding.ASCII.GetBytes(instruction)[0] - 64) + baseTime
                    });
                    remainingInstructions.Remove(instruction);
                    availableWorkers--;
                }


                //Output visualization
                var firstWorker = instructionsBeingWorked.Count > 0 ? instructionsBeingWorked[0].Name : ".";
                var secondWorker = instructionsBeingWorked.Count > 1 ? instructionsBeingWorked[1].Name : ".";
                var elapsed = secondsElapsed.ToString().Length < 2 ? "0" + secondsElapsed : secondsElapsed.ToString();
                var complete = string.Join(string.Empty, completedInstructions);
                Console.WriteLine($"   {elapsed}        {firstWorker}          {secondWorker}       {complete}");

            }

            Console.WriteLine($"Answer: {secondsElapsed}");
        }

        private class InstructionRule
        {
            public string InstructionName { get; set; }
            public string PredecessorInstructionName { get; set; }
        }

        private class ActiveInstruction
        {
            public string Name { get; set; }
            public int TimeRemaining { get; set; }
        }
    }
}
