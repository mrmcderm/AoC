using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day07
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var inputs = RawInput.Split(Environment.NewLine).Select(_ => _
                .Replace(" contain ", ":")
                .Replace(" bags.", string.Empty)
                .Replace(" bags", string.Empty)
                .Replace(" bag.", string.Empty)
                .Replace(" bag", string.Empty)
                .Replace(", ", "|")
                .Replace("no other", string.Empty)
            ).ToList();

            foreach (var input in inputs)
            {
                var bag = new Bag(input, inputs);

                if(bag.ContainsBag("shiny gold"))
                    answer ++;
            }

            Console.WriteLine("Day 7, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private class Bag
        {
            public string Name { get; set; }

            public int Count { get; set; }

            public List<Bag> Children { get; set; }

            public Bag(string input, List<string> allInputs)
            {
                var split1 = input.Split(":");
                Name = split1[0];
                var rawContents = split1[1].Split("|").ToList();
                Children = new List<Bag>();

                foreach(var rawContent in rawContents)
                {
                    if (!string.IsNullOrWhiteSpace(rawContent))
                    {
                        Children.Add(new Bag(allInputs.First(_ => _.StartsWith(rawContent[2..])), allInputs)
                        {
                            Count = int.Parse(rawContent.Substring(0, 1))
                        });
                    }
                }
            }

            public bool ContainsBag(string bagName)
            {
                if (Children.Count < 1)
                    return false;

                var result = false;
                foreach (var child in Children)
                {
                    if (child.Name == bagName || child.ContainsBag(bagName))
                    {
                        result = true;
                        break;
                    }
                }

                return result;
            }

            public override string ToString()
            {
                return $"Name: {Name}";
            }
        }
    }
}