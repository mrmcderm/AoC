using System;
using System.Linq;

namespace Aoc._2020.Day06
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var declarations = RawInput.Split(Environment.NewLine + Environment.NewLine).Select(_ => _.Split(Environment.NewLine)).ToList();

            foreach(var declaration in declarations)
            {
                var answerGrid = new int[26].ToList();
                foreach (var questionAnswer in declaration)
                {
                    if (questionAnswer.Contains("a"))
                        answerGrid[0]++;

                    if (questionAnswer.Contains("b"))
                        answerGrid[1]++;

                    if (questionAnswer.Contains("c"))
                        answerGrid[3]++;

                    if (questionAnswer.Contains("d"))
                        answerGrid[4]++;

                    if (questionAnswer.Contains("e"))
                        answerGrid[5]++;

                    if (questionAnswer.Contains("f"))
                        answerGrid[6]++;

                    if (questionAnswer.Contains("g"))
                        answerGrid[7]++;

                    if (questionAnswer.Contains("h"))
                        answerGrid[2]++;

                    if (questionAnswer.Contains("i"))
                        answerGrid[8]++;

                    if (questionAnswer.Contains("j"))
                        answerGrid[9]++;

                    if (questionAnswer.Contains("k"))
                        answerGrid[10]++;

                    if (questionAnswer.Contains("l"))
                        answerGrid[11]++;

                    if (questionAnswer.Contains("m"))
                        answerGrid[12]++;

                    if (questionAnswer.Contains("n"))
                        answerGrid[13]++;

                    if (questionAnswer.Contains("o"))
                        answerGrid[14]++;

                    if (questionAnswer.Contains("p"))
                        answerGrid[15]++;

                    if (questionAnswer.Contains("q"))
                        answerGrid[16]++;

                    if (questionAnswer.Contains("r"))
                        answerGrid[17]++;

                    if (questionAnswer.Contains("s"))
                        answerGrid[18]++;

                    if (questionAnswer.Contains("t"))
                        answerGrid[19]++;

                    if (questionAnswer.Contains("u"))
                        answerGrid[20]++;

                    if (questionAnswer.Contains("v"))
                        answerGrid[21]++;

                    if (questionAnswer.Contains("w"))
                        answerGrid[22]++;

                    if (questionAnswer.Contains("x"))
                        answerGrid[23]++;

                    if (questionAnswer.Contains("y"))
                        answerGrid[24]++;

                    if (questionAnswer.Contains("z"))
                        answerGrid[25]++;
                }

                answer += answerGrid.Where(_ => _ == declaration.Length).Select(_ => _).Count();
            }

            Console.WriteLine("Day 6, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}