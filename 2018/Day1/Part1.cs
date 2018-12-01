using System;
using System.Globalization;

namespace AoC._2018.Day1
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var input = RawInput.Split("\r\n");
            var result = 0;

            foreach(var freqShift in input)
            {
                result = result + int.Parse(freqShift, NumberStyles.AllowLeadingSign);
            }

            Console.WriteLine("Day 1, Part 1");
            Console.WriteLine(result);
        }
    }
}