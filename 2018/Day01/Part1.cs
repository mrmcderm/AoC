using System;
using System.Globalization;
using System.Linq;

namespace AoC._2018.Day01
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 1, Part 1");
            Console.WriteLine($"Answer: {RawInput.Split("\r\n").Aggregate(0, (current, freqShift) => current + int.Parse(freqShift, NumberStyles.AllowLeadingSign))}");
        }
    }
}