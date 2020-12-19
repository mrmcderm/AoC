using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day15
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var numbersSpoken = new List<int>() { 0, 8, 15, 2, 12, 1, 4 };
            var initialTurn = numbersSpoken.Count + 1;
            var gameNumbers = new Dictionary<int, GameNumber>();


            //Preload the gameNumbers...
            for (var i = 0; i < numbersSpoken.Count; i++)
            {
                gameNumbers.Add(numbersSpoken[i], new GameNumber()
                {
                    Number = numbersSpoken[i],
                    NumberOfTimesSpoken = 1,
                    PreviousTurn = i + 1
                });
            }

            //Play the game...
            for (var i = initialTurn; i <= 30000000; i++)
            {
                //Get the last number spoken...
                var lastNumberSpoken = numbersSpoken[i - 2];

                //If we don't have a record of it, create one
                var gameNumber = gameNumbers[lastNumberSpoken];
                if(gameNumber == null)
                {
                    gameNumber = new GameNumber
                    {
                        Number = lastNumberSpoken,
                        NumberOfTimesSpoken = 1,
                        PreviousTurn = i
                    };
                    gameNumbers.Add(lastNumberSpoken, gameNumber);
                }

                //If it's only been spoken once, speak 0
                if (gameNumber.NumberOfTimesSpoken == 1)
                {
                    if(!gameNumbers.ContainsKey(0))
                    {
                        gameNumbers.Add(0, new GameNumber
                        {
                            Number = lastNumberSpoken,
                            NumberOfTimesSpoken = 1,
                            PreviousTurn = i
                        });
                    }
                    else
                    {
                        var zeroGameNumber = gameNumbers[0];
                        zeroGameNumber.NumberOfTimesSpoken++;
                        zeroGameNumber.PreviousPreviousTurn = zeroGameNumber.PreviousTurn;
                        zeroGameNumber.PreviousTurn = i;
                    }

                    numbersSpoken.Add(0);
                }

                //If it's been spoken more than once...
                else
                {
                    //Find the last turns where it was spoken...
                    var previousTurn = gameNumber.PreviousTurn;
                    var previousPreviousTurn = gameNumber.PreviousPreviousTurn;

                    var newSpokenNumber = previousTurn - previousPreviousTurn;
                    
                    if (!gameNumbers.ContainsKey(newSpokenNumber.Value))
                    {
                        gameNumbers.Add(newSpokenNumber.Value, new GameNumber
                        {
                            Number = newSpokenNumber.Value,
                            NumberOfTimesSpoken = 1,
                            PreviousTurn = i
                        });
                    }
                    else
                    {
                        var newSpokenGameNumber = gameNumbers[newSpokenNumber.Value];
                        newSpokenGameNumber.NumberOfTimesSpoken++;
                        newSpokenGameNumber.PreviousPreviousTurn = newSpokenGameNumber.PreviousTurn;
                        newSpokenGameNumber.PreviousTurn = i;
                    }

                    numbersSpoken.Add(newSpokenNumber.Value);
                }
            }

            answer = numbersSpoken.Last();

            Console.WriteLine("Day 15, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private class GameNumber
        {
            public int Number { get; set; }

            public int NumberOfTimesSpoken { get; set; }

            public int? PreviousTurn { get; set; }

            public int? PreviousPreviousTurn { get; set; }
        }
    }
}