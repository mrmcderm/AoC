using System;

namespace Aoc._2020.Day03
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var rows = RawInput.Split("\n");
            var columnCount = 31;
            var position = 0;
            var treeCount = 0;
            var slope = 3;
            var rowSkip = 1;

            for (int i = 0; i < rows.Length; i += rowSkip)
            {
                //Console.WriteLine($"Row: {row}, Position: {position}, Char: {row[position]}");
                if(rows[i][position] == '#')
                {
                    treeCount++;
                }

                position += slope;
                if(position > (columnCount - 1))
                {
                    position -= columnCount;
                }
            }

            answer = treeCount;

            Console.WriteLine("Day 3, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}