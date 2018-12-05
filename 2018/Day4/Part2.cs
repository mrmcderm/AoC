using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2018.Day4
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 4, Part 2");

            var rawEntries = RawInput.Split("\r\n");

            //Deserialize the raw input into an initial collection of guard entries
            var guardEntries = rawEntries.Select(rawEntry => new GuardEntry
            {
                TimeStamp = DateTime.Parse(rawEntry.Substring(1, rawEntry.IndexOf("]") - 1)),
                Action = rawEntry.Split("]")[1].TrimStart()
            }).ToList();


            //Order the entries by time stamp, break down the activities further,
            //and make sure each activity is mapped to the correct guard
            var guardId = string.Empty;
            foreach (var guardEntry in guardEntries.OrderBy(_ => _.TimeStamp))
            {
                if (guardEntry.Action.Contains("#"))
                {
                    guardId = guardEntry.Action.Split("#")[1].Replace("begins shift", string.Empty).Trim();
                    guardEntry.Action = "begins shift";
                }
                guardEntry.Id = guardId;
            }

            //Group the entries by guard
            var guardEntryGroups = guardEntries.GroupBy(_ => _.Id).ToDictionary(_ => _.Key, _ => _.ToList());

            var guards = new List<Guard>();
            foreach (var guardEntryGroup in guardEntryGroups)
            {
                var guard = new Guard { Id = guardEntryGroup.Key, SleepArray = new int[60] };

                var fallsAsleep = 0;
                foreach (var guardEntry in guardEntryGroup.Value.OrderBy(_ => _.TimeStamp))
                {
                    //Console.WriteLine($"Guard #{guard.Id}: {guardEntry.TimeStamp} - {guardEntry.Action}");
                    if (guardEntry.Action == "falls asleep")
                    {
                        fallsAsleep = guardEntry.TimeStamp.Minute;
                        continue;
                    }

                    if (guardEntry.Action == "wakes up")
                    {
                        var minutesSlept = ((guardEntry.TimeStamp.Minute) - fallsAsleep);
                        guard.TotalMinutesAsleep = guard.TotalMinutesAsleep + minutesSlept;

                        for (var i = fallsAsleep; i < minutesSlept + fallsAsleep; i++)
                        {
                            guard.SleepArray[i] = guard.SleepArray[i] + 1;
                        }
                    }
                }

                guards.Add(guard);
            }

            Console.WriteLine("Guard #\tTotal Mins\t000000000011111111112222222222333333333344444444445555555555");
            Console.WriteLine("       \t          \t012345678901234567890123456789012345678901234567890123456789");
            Console.WriteLine("-------\t----------\t------------------------------------------------------------");
            foreach (var guard in guards)
            {
                Console.Write($"{guard.Id}\t{guard.TotalMinutesAsleep}\t\t");
                foreach (var sleepMinute in guard.SleepArray)
                {
                    Console.Write(sleepMinute);
                }
                Console.WriteLine();
            }

            var answerGuard = guards.First(_ => _.TotalMinutesAsleep == guards.Max(__ => __.TotalMinutesAsleep));
            var answerGuardId = int.Parse(answerGuard.Id);
            var answerGuardMostSleptMinute = answerGuard.SleepArray.ToList().IndexOf(answerGuard.SleepArray.Max());
            Console.WriteLine($"Answer: {answerGuardId * answerGuardMostSleptMinute}");
        }
    }
}