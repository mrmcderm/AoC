using System.IO.Enumeration;
using System.IO.Pipes;
using System.Security.Authentication;

namespace Aoc._2022.Day07
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var terminalStatements = RawInput.Split("\r\n");
            Directory rootDirectory = new() { Name = "/" };
            Directory currentDirectory = rootDirectory;

            foreach (var terminalStatement in terminalStatements)
            {
                if (terminalStatement == "$ ls")
                    continue;

                //Parsing a change directory command
                if (terminalStatement.StartsWith("$ cd"))
                {
                    var targetDirectoryName = terminalStatement.Split(" cd ")[1];

                    if (targetDirectoryName == "..")
                    {
                        currentDirectory = currentDirectory.Parent;
                    }
                    else
                    {
                        if (targetDirectoryName == "/")
                            currentDirectory = rootDirectory;
                        else
                            currentDirectory = currentDirectory.Children.First(_ => _.Name == targetDirectoryName);
                    }
                    continue;
                }

                //Parsing a directory definition
                if (terminalStatement.StartsWith("dir"))
                {
                    var newDirectoryName = terminalStatement.Split(" ")[1];
                    var newDirectory = new Directory() { Name = newDirectoryName, Parent = currentDirectory };
                    currentDirectory.Children.Add(newDirectory);
                    continue;
                }

                //Parsing a file definition
                currentDirectory.Files.Add(new File() { Name = terminalStatement.Split(" ")[1], Size = int.Parse(terminalStatement.Split(" ")[0]) });
            }

            rootDirectory.PrettyPrint(string.Empty);
            var totalSize = rootDirectory.CalculateTotalSize();
            var masterList = new List<Directory>();
            rootDirectory.RegisterChildren(masterList);

            answer = masterList.Where(_ => _.Size <= 100000).Sum(_ => _.Size);

            Console.WriteLine("Day 7, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        public class Directory
        {
            public string? Name { get; set; }

            public Directory? Parent { get; set; }

            public List<Directory> Children { get; set; }

            public List<File> Files { get; set; }

            public int Size { get; set; }

            public Directory()
            {
                Children = new List<Directory>();
                Files = new List<File>();
            }

            public int CalculateTotalSize()
            {
                var size = Files.Sum(_ => _.Size);

                foreach (var child in Children)
                {
                    size += child.CalculateTotalSize();
                }

                this.Size = size;

                return size;
            }

            public void RegisterChildren(List<Directory> masterList)
            {
                foreach(var child in Children)
                {
                    child.RegisterChildren(masterList);
                }

                masterList.Add(this);
            }

            public void PrettyPrint(string prefix)
            {
                Console.WriteLine($"{prefix}- {Name} (dir)");
                foreach(var directory in Children)
                {
                    directory.PrettyPrint($"{prefix}  ");
                }

                foreach(var file in Files)
                {
                    Console.WriteLine($"{prefix}  - {file.Name} (file, size={file.Size})");
                }
            }

            public override string ToString()
            {
                return $"Name: {Name}, Size: {Size}, Parent: {Parent?.Name}";
            }
        }

        public class File
        {
            public string? Name { get; set; }
            public int Size { get; set; }
        }
    }
}