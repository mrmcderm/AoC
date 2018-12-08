using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2018.Day8
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 8, Part 1");

            var input = RawInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Console.WriteLine($"Answer: {TraverseTree(BuildTree(input))}");
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

        private static int TraverseTree(Node node)
        {
            return node.ChildNodeCount < 1
                ? node.MetadataValues.Sum(_ => _)
                : node.ChildNodes.Aggregate(node.MetadataValues.Sum(_ => _), (current, childNode) => current + TraverseTree(childNode));
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