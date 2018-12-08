using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2018.Day8
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 8, Part 2");

            var input = RawInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Console.WriteLine($"Answer: {GetValue(BuildTree(input))}");
        }

        private static Node BuildTree(IList<int> input)
        {
            var node = new Node
            {
                ChildNodeCount = input[0],
                MetadataCount = input[1],
                ChildNodes = new List<Node>(),
                MetadataValues = new List<int>()
            };

            input.RemoveAt(0);
            input.RemoveAt(0);

            if (node.ChildNodeCount < 1)
            {
                for (var i = 0; i < node.MetadataCount; i++)
                {
                    node.MetadataValues.Add(input[0]);
                    input.RemoveAt(0);
                }
                return node;
            }

            for (var i = 0; i < node.ChildNodeCount; i++)
            {
                node.ChildNodes.Add(BuildTree(input));
            }

            for (var i = 0; i < node.MetadataCount; i++)
            {
                node.MetadataValues.Add(input[0]);
                input.RemoveAt(0);
            }
            return node;
        }

        private static int GetValue(Node node)
        {
            if (node.ChildNodeCount < 1)
            {
                return node.MetadataValues.Sum(_ => _);
            }

            return node.MetadataValues
                .Where(metadataValue => metadataValue <= node.ChildNodeCount)
                .Aggregate(0, (current, metadataValue) => current + GetValue(node.ChildNodes[metadataValue - 1]));
        }

        private class Node
        {
            public int ChildNodeCount { get; set; }

            public int MetadataCount { get; set; }

            public IList<Node> ChildNodes { get; set; }

            public IList<int> MetadataValues { get; set; }
        }
    }
}