using System.Diagnostics;
using System.Reflection;
using Aoc._2021;

const string day = "03";
const int part = 2;

try
{
    //Load puzzle class //Aoc._2021.Day01
    var puzzleType = Assembly.GetExecutingAssembly().GetType($"Aoc._2021.Day{day}.Part{part}");
    if (puzzleType == null)
    {
        throw new Exception($"Could not resolve puzzle for Day: {day}, Part: {part}");
    }

    var puzzle = (IPuzzle)Activator.CreateInstance(puzzleType);

    //Load puzzle input
    puzzle.RawInput = File.ReadAllText($@"/Users/mmcdermott/Source/Repos/Aoc/2021/Day{day}/Part{part}Input.txt");

    var stopwatch = Stopwatch.StartNew();
    puzzle.Solve();
    Console.WriteLine($"Solution complete in {stopwatch.ElapsedMilliseconds}ms");
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();