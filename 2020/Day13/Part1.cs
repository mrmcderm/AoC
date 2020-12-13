using System;
using System.Linq;

namespace Aoc._2020.Day13
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var inputs = RawInput.Split(Environment.NewLine).ToList();

            var earliestTimeStamp = int.Parse(inputs[0]);
            var busSchedule = inputs[1].Split(",").Where(_ => _ != "x").Select(_ => int.Parse(_)).ToList();
            var foundBus = false;
            var nextTimeStamp = earliestTimeStamp;

            while(!foundBus)
            {
                foreach(var bus in busSchedule)
                {
                    if(nextTimeStamp % bus == 0)
                    {
                        answer = (nextTimeStamp - earliestTimeStamp) * bus;
                        foundBus = true;
                    }
                }
                nextTimeStamp++;
            }

            Console.WriteLine("Day 13, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}