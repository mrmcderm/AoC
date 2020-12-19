using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aoc._2020.Day15
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var numbersSpoken = new List<int>() { 0, 8, 15, 2, 12, 1, 4 };
            var initialTurn = numbersSpoken.Count + 1;

            for(var i = initialTurn; i <= 2020; i++)
            {
                var sw = Stopwatch.StartNew();

                //Get the last number spoken...
                var lastNumberSpoken = numbersSpoken[i-2];

                //Find out how many times that number has been spoken...
                var lastNumberSpokenCount = numbersSpoken.Where(_ => _ == lastNumberSpoken).Count();

                //If it's only been spoken once, speak 0
                if(lastNumberSpokenCount == 1)
                {
                    numbersSpoken.Add(0);
                }
                //If it's been spoken more than once...
                else
                {
                    //Find the last turns where it was spoken...
                    var turnsWhereSpoken = numbersSpoken.AllIndexesOf(lastNumberSpoken).ToList();
                    var previousTurn = turnsWhereSpoken.Last() + 1;
                    var previousPreviousTurn = turnsWhereSpoken[^2] + 1;

                    //Speak the difference in turns
                    numbersSpoken.Add(previousTurn - previousPreviousTurn);
                }

                Console.WriteLine($"Turn: {i} : {numbersSpoken.Last()} - {string.Join(',', numbersSpoken)}");
            }

            answer = numbersSpoken.Last();
            
            Console.WriteLine("Day 15, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}