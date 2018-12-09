using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC._2018.Day5
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 5, Part 1");

            
            var lowerUnits = new List<string>();
            var upperUnits = new List<string>();

            //Build up the list of polymers starting with lowerUPPER
            var polymers = new List<string>();
            for (var i = 65; i < 91; i++)
            {
                //Also store the halves of the polymers.  We'll go through them later
                lowerUnits.Add(Encoding.ASCII.GetString(new [] {(byte) i}));
                upperUnits.Add(Encoding.ASCII.GetString(new [] {(byte) (i + 32)}));
                polymers.Add(Encoding.ASCII.GetString(new [] { (byte)i }) + Encoding.ASCII.GetString(new [] { (byte)(i + 32) }));
            }

            //Add in the UPPERlower polymers.  Probably a way to do this in the first loop but don't want to do math.
            foreach (var polymer in polymers.ToList())
            {
                var polymerCharArray = polymer.ToCharArray();
                Array.Reverse(polymerCharArray);
                polymers.Add(new string(polymerCharArray));
            }

            //We want to store the polymer chain lengths after trying to remove each polymer type
            var lengths = new int[26];
            for (var i = 0; i < 26; i++)
            {
                //For each polymer type, remove it from the input
                var input = RawInput.Replace(lowerUnits[i], string.Empty);
                input = input.Replace(upperUnits[i], string.Empty);

                //Shrink the polymer chain missing the current polymer type and store the length
                var shrunkInput = Shrink(input, polymers);
                lengths[i] = shrunkInput.Length;
            }

            //Grab the shortest polymer chain
            Console.WriteLine(lengths.Min());
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