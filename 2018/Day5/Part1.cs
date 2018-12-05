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

            var polymers = new List<string>();
            for (var i = 65; i < 91; i++)
            {
                polymers.Add(Encoding.ASCII.GetString(new byte[] { (byte)i }) + Encoding.ASCII.GetString(new byte[] { (byte)(i + 32) }));
            }

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
                var newValue = polymers.Aggregate(input, (current, polymer) => current.Replace(polymer, string.Empty));
                if (newValue == input) return newValue;
                input = newValue;
            }
        }
    }
}