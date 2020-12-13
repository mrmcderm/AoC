using System;
using System.Linq;

namespace Aoc._2020.Day13
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            long answer = 0;
            var inputs = RawInput.Split(Environment.NewLine).ToList();

            var busSchedule = inputs[1].Split(",").ToList();
            var foundAnswer = false;
            long timeStamp = 100000000000000;

            while (!foundAnswer)
            {
                answer = timeStamp;

                if(answer % 100000000 == 0)
                    Console.WriteLine($"{answer} - {DateTime.Now}");

                //Don't bother checking next buses if 1st bus isn't even leaving
                if (timeStamp % long.Parse(busSchedule[0]) == 0)
                {
                    foundAnswer = true;
                    for (int i = 1; i < busSchedule.Count; i++)
                    {
                        //No requirements or restrictions on this timestamp
                        if(busSchedule[i] == "x")
                            continue;

                        var modulo = (timeStamp + i) % long.Parse(busSchedule[i]);
                        if (modulo != 0)
                        {
                            foundAnswer = false;
                            break;
                        }
                    }
                }
                timeStamp++;
            }

            Console.WriteLine("Day 13, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}