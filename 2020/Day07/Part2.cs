using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day07
{
    public class Part2 : IPuzzle
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

            var bags = new List<Bag>();

            foreach (var input in inputs)
            {
                bags.Add(new Bag(input, inputs));
            }

            var myBag = bags.First(_ => _.Name == "shiny gold");

            answer = myBag.GetBagCount();

            Console.WriteLine("Day 7, Part 2");
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

                foreach (var rawContent in rawContents)
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

            public int GetBagCount()
            {
                var result = 0;
                if (Children.Count < 1)
                {
                    return result;
                }
                
                foreach(var child in Children)
                {
                    result += child.Count * (1 + child.GetBagCount());
                }

                return result;
            }
        }
    }
}