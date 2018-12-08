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

            /*
            As you're about to begin construction, four of the Elves offer to help. 
            "The sun will set soon; it'll go faster if we work together." Now, you 
            need to account for multiple people working on steps simultaneously. If 
            multiple steps are available, workers should still begin them in alphabetical order.

            Each step takes 60 seconds plus an amount corresponding to its letter: 
            A=1, B=2, C=3, and so on. So, step A takes 60+1=61 seconds, while step Z 
            takes 60+26=86 seconds. No time is required between steps.

            To simplify things for the example, however, suppose you only have help from 
            one Elf (a total of two workers) and that each step takes 60 fewer seconds 
            (so that step A takes 1 second and step Z takes 26 seconds). Then, using the 
            same instructions as above, this is how each second would be spent:

            Second   Worker 1   Worker 2   Done
                00        C          .        
                01        C          .        
                02        C          .        
                03        A          F       C
                04        B          F       CA
                05        B          F       CA
                06        D          F       CAB
                07        D          F       CAB
                08        D          F       CAB
                09        D          .       CABF
                10        E          .       CABFD
                11        E          .       CABFD
                12        E          .       CABFD
                13        E          .       CABFD
                14        E          .       CABFD
                15        .          .       CABFDE
            Each row represents one second of time. The Second column identifies how many 
            seconds have passed as of the beginning of that second. Each worker column shows 
            the step that worker is currently doing (or . if they are idle). The Done column 
            shows completed steps.

            Note that the order of the steps has changed; this is because steps now take 
            time to finish and multiple workers can begin multiple steps simultaneously.

            In this example, it would take 15 seconds for two workers to complete these steps.

            With 5 workers and the 60+ second step durations described above, how long will 
            it take to complete all of the steps?
            */

            var instructionRules = RawInput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(_ => _.Replace(" must be finished before step ", ","))
                .Select(_ => _.Replace("Step ", string.Empty))
                .Select(_ => _.Replace(" can begin.", string.Empty))
                .Select(_ => new Instruction
                {
                    Name = _.Split(",")[1],
                    PredecessorName = _.Split(",")[0],
                })
                .ToList();

            var instructionsRemaining = instructionRules.Select(_ => _.PredecessorName).Union(instructionRules.Select(_ => _.Name)).Distinct().OrderBy(_ => _).ToList();

            var originalInput = RawInput.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(_ => _.Replace(" must be finished before step ", ","))
                .Select(_ => _.Replace("Step ", string.Empty))
                .Select(_ => _.Replace(" can begin.", string.Empty))
                .Select(_ => new Instruction
                {
                    Name = _.Split(",")[1],
                    PredecessorName = _.Split(",")[0],
                })
                .ToList();

            var availableWorkers = 2;
            var secondsElapsed = -1;
            var baseTime = 0;
            var instructionsBeingWorked = new List<ActiveInstruction>();
            var completedInstructions = new List<string>();
            Console.WriteLine("Second   Worker 1   Worker 2   Done");

            while (instructionsRemaining.Count > 0 || instructionsBeingWorked.Count > 0)
            {
                //Cycle the clock
                secondsElapsed++;

                foreach (var instruction in instructionsBeingWorked.ToList())
                {
                    instruction.TimeRemaining--;

                    if (instruction.TimeRemaining >= 1)
                        continue;

                    availableWorkers++;
                    instructionsBeingWorked.Remove(instruction);
                    completedInstructions.Add(instruction.Name);
                }

                //Do we have any available workers?
                if (availableWorkers > 0)
                {
                    //Find the ready instructions
                    var readyInstructions = instructionRules
                        .Select(_ => _.PredecessorName)
                        .Where(c1 => instructionRules.Select(_ => _.Name)
                        .All(c2 => c2 != c1))
                        .Distinct()
                        .OrderBy(_ => _)
                        .ToList();

                    //Get the tail instruction
                    if (readyInstructions.Count == 0 && instructionsRemaining.Count == 1 && instructionsBeingWorked.Count == 0)
                    {
                        readyInstructions.Add(instructionsRemaining[0]);
                    }

                    //Assign an instruction to a worker
                    foreach (var instruction in readyInstructions)
                    {
                        //Is it already being worked?
                        if(instructionsBeingWorked.Select(_ => _.Name).ToList().Contains(originalInput.Where(_ => _.Name == instruction).Select(_ => _.PredecessorName).FirstOrDefault()))
                            continue;

                        instructionsBeingWorked.Add(new ActiveInstruction
                        {
                            Name = instruction,
                            TimeRemaining = (byte)(Encoding.ASCII.GetBytes(instruction)[0] - 64) + baseTime
                        });

                        //Pop the ready instruction off the original stack
                        instructionRules.RemoveAll(_ => _.PredecessorName == instruction);
                        instructionsRemaining.Remove(instruction);

                        //Reduce available worker count
                        availableWorkers--;

                        //If we have no more available workers, stop trying to assign instructions
                        if (availableWorkers < 1)
                            break;
                    }
                }
           
                var firstWorker = instructionsBeingWorked.Count > 0 ? instructionsBeingWorked[0].Name : ".";
                var secondWorker = instructionsBeingWorked.Count > 1 ? instructionsBeingWorked[1].Name : ".";
                var elapsed = secondsElapsed.ToString().Length < 2 ? "0" + secondsElapsed : secondsElapsed.ToString();

                var complete = string.Join(string.Empty, completedInstructions);
                Console.WriteLine($"   {elapsed}        {firstWorker}          {secondWorker}       {complete}");
            }

            Console.WriteLine($"Answer: {secondsElapsed}");
        }

        private class Instruction
        {
            public string Name { get; set; }
            public string PredecessorName { get; set; }
        }

        private class ActiveInstruction
        {
            public string Name { get; set; }
            public int TimeRemaining { get; set; }
        }
    }
}
