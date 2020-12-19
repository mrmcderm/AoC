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

            var busSchedule = inputs[1].Replace("x", "1").Split(",").Select(_ => long.Parse(_)).ToList();
            var busScheduleMax = busSchedule.Count - 1;
            var busScheduleLast = busSchedule.Last();
            var foundAnswer = false;
            long timeStamp = 100000000000000;

            while (!foundAnswer)
            {
                answer = timeStamp;

                var foo = timeStamp % busSchedule[0];
                var bar = (timeStamp + busScheduleMax) % busScheduleLast;

                //Don't bother checking next buses if 1st bus isn't even leaving
                if (foo == 0 && bar != 0)
                {
                    timeStamp += busScheduleMax;
                    continue;
                }

                //if both 1st bus and last bus are leaving, check the middles
                if (foo == 0 && bar == 0)
                {
                    foundAnswer = true;
                    for (int i = 1; i < busScheduleMax; i++)
                    {
                        var modulo = (timeStamp + i) % busSchedule[i];
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