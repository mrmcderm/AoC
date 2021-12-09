using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aoc._2021.Day08
{
    public class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var lines = RawInput.Split(Environment.NewLine);
            var outputValues = new Dictionary<string, int>();

            /*
             * be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
                edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
                fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
                fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
                aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
                fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
                dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
                bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
                egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
                gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce
            */

            foreach (var line in lines)
            {
                var parsedLine = line.Split(" | ");
                var signalPatterns = parsedLine[0].Split(" ");
                var lineOutputValues = parsedLine[1].Split(" ");
                var answerKey = new Dictionary<int, string>();

                answerKey.Add(1, signalPatterns.First(_ => _.Length == 2));
                answerKey.Add(7, signalPatterns.First(_ => _.Length == 3));
                answerKey.Add(4, signalPatterns.First(_ => _.Length == 4));
                answerKey.Add(8, signalPatterns.First(_ => _.Length == 7));

                //length 2 = 1
                //length 3 = 7
                //length 4 = 4
                //length 5 = 2/3/5
                //length 6 = 0/6/9
                //length 7 = 8

                //1 = length 2
                //7 = length 3
                //4 = length 4
                //8 = length 7
                //9 = length 2 after removing 4
                //2 = length 1 after removing 9
                //0 = length 4 after removing 1
                //6 = length 5 after removing 1
                //3 = length 3 after removing 1
                //5 = length 4 after removing 1

                //Find 9
                var lengthSixNums = signalPatterns.Where(_ => _.Length == 6).ToArray();
                foreach (var lengthSixNum in lengthSixNums)
                {
                    var newLength = Subtract(lengthSixNum, answerKey[4]).Length;

                    if(newLength == 2)
                    {
                        answerKey[9] = lengthSixNum;
                    }
                }

                //Find 2
                var lengthFiveNums = signalPatterns.Where(_ => _.Length == 5).ToArray();
                foreach (var lengthFiveNum in lengthFiveNums)
                {
                    var newLength = Subtract(lengthFiveNum, answerKey[9]).Length;

                    if (newLength == 1)
                    {
                        answerKey[2] = lengthFiveNum;
                    }
                }


                //Find 0 & 6
                foreach (var lengthSixNum in lengthSixNums)
                {
                    if (lengthSixNum != answerKey[9])
                    {
                        var newLength = Subtract(lengthSixNum, answerKey[1]).Length;

                        if (newLength == 4)
                        {
                            answerKey[0] = lengthSixNum;
                        }

                        if (newLength == 5)
                        {
                            answerKey[6] = lengthSixNum;
                        }
                    }
                }


                //Find 3 & 5
                foreach (var lengthFiveNum in lengthFiveNums)
                {
                    if (lengthFiveNum != answerKey[2])
                    {
                        var newLength = Subtract(lengthFiveNum, answerKey[1]).Length;

                        if (newLength == 3)
                        {
                            answerKey[3] = lengthFiveNum;
                        }

                        if (newLength == 4)
                        {
                            answerKey[5] = lengthFiveNum;
                        }
                    }
                }
                
                var outputValueArray = new List<int>();
                foreach(var lineOutputValue in lineOutputValues)
                {
                    outputValueArray.Add(answerKey.Where(_ => new string(_.Value.OrderBy(_ => _).ToArray()) == new string(lineOutputValue.OrderBy(_ => _).ToArray())).First().Key);
                }
                answer += int.Parse(String.Join(string.Empty, outputValueArray));
            }

            Console.WriteLine("Day 8, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private string Subtract(string left, string right)
        {
            var sb = new StringBuilder();
                        
            //Subtracting right from left
            //For every letter in left...
            foreach(var letter in left)
            {
                //if the letter doesn't exist in the right, it stays.
                if(!right.Contains(letter))
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }
    }
}
