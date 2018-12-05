using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC._2018.Day5
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 5, Part 1");

            //Build up the list of polymers starting with lowerUPPER
            var polymers = new List<string>();
            for (var i = 65; i < 91; i++)
            {
                polymers.Add(Encoding.ASCII.GetString(new [] { (byte)i }) + Encoding.ASCII.GetString(new [] { (byte)(i + 32) }));
            }

            //Add in the UPPERlower polymers.  Probably a way to do this in the first loop but don't want to do math.
            foreach (var polymer in polymers.ToList())
            {
                var polymerCharArray = polymer.ToCharArray();
                Array.Reverse(polymerCharArray);
                polymers.Add(new string(polymerCharArray));
            }

            var result = Shrink(RawInput, polymers);
            Console.WriteLine(result.Length);
        }

        private static string Shrink(string input, IReadOnlyCollection<string> polymers)
        {
            while (true)
            {
                //Replace all polymers with empty strings
                var newValue = polymers.Aggregate(input, (current, polymer) => current.Replace(polymer, string.Empty));

                //If the resulting string is the same as it was, it means we have no more polymers to remove
                if (newValue == input) return newValue;

                //Otherwise set the new input and loop again
                input = newValue;
            }
        }
    }
}