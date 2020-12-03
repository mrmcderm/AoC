using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day03
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var rows = RawInput.Split("\n");
            var columnCount = 31;
            int position;
            int treeCount;
            var slopes = new List<List<int>>()
            {
                new List<int>() { 1, 1 },
                new List<int>() { 3, 1 },
                new List<int>() { 5, 1 },
                new List<int>() { 7, 1 },
                new List<int>() { 1, 2 }
            };
            var slopeResults = new List<int>();

            foreach (var slope in slopes)
            {
                treeCount = 0;
                position = 0;
                for (int i = 0; i < rows.Length; i += slope[1])
                {
                    //Console.WriteLine($"Row: {rows[i]}, Slope: {slope[0]}, Position: {position}, Char: {rows[i][position]}");
                    if (rows[i][position] == '#')
                    {
                        treeCount++;
                    }

                    position += slope[0];
                    if (position > (columnCount - 1))
                    {
                        position -= columnCount;
                    }
                }

                slopeResults.Add(treeCount);
            }

            //TODO - this does not do what I think it should do,
            //it doesn't yield the expected answer so I did the last part by hand
            answer = slopeResults.Aggregate((x, y) => x * y);

            Console.WriteLine("Day 3, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}