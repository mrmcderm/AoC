using System;
using System.Globalization;
using System.Collections.Generic;

namespace AoC._2018.Day1
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var input = RawInput.Split("\r\n");
            var frequenciesSeen = new List<int>();
            var result = 0;
            var foundSecondInstance = false;

            while (!foundSecondInstance)
            {
                foreach (var freqShift in input)
                {
                    result = result + int.Parse(freqShift, NumberStyles.AllowLeadingSign);
                    if (frequenciesSeen.Contains(result))
                    {
                        foundSecondInstance = true;
                        break;
                    }
                    
                    frequenciesSeen.Add(result);
                }
            }

            Console.WriteLine("Day 1, Part 2");
            Console.WriteLine(result);
        }
    }
}