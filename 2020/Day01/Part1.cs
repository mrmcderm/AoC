using System;

namespace Aoc._2020.Day01
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var left = RawInput.Split("\n");
            var right = left;
            var answer = 0;

            foreach(var leftItem in left)
            {
                var leftItemInt = int.Parse(leftItem);
                foreach (var rightItem in right)
                {
                    var rightItemInt = int.Parse(rightItem);
                    if (rightItemInt + leftItemInt == 2020)
                    {
                        answer = rightItemInt * leftItemInt;
                        break;
                    }
                }

                if (answer > 0)
                {
                    break;
                }
            }

            Console.WriteLine("Day 1, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}