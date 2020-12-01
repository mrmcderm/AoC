using System;

namespace Aoc._2020.Day01
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var left = RawInput.Split("\n");
            var center = left;
            var right = left;
            var answer = 0;

            foreach (var leftItem in left)
            {
                var leftItemInt = int.Parse(leftItem);
                foreach (var centerItem in center)
                {
                    var centerItemInt = int.Parse(centerItem);
                    foreach (var rightItem in right)
                    {
                        var rightItemInt = int.Parse(rightItem);
                        if (rightItemInt + centerItemInt + leftItemInt == 2020)
                        {
                            answer = rightItemInt * centerItemInt * leftItemInt;
                            break;
                        }
                    }

                    if(answer > 0)
                    {
                        break;
                    }
                }

                if (answer > 0)
                {
                    break;
                }
            }

            Console.WriteLine("Day 1, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}