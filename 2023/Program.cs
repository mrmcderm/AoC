using System.Diagnostics;
using System.Reflection;
using Aoc._2023;

const string day = "01";
const int part = 2;

try
{
    //Load puzzle class
    var puzzleType = Assembly.GetExecutingAssembly().GetType($"Aoc._2023.Day{day}.Part{part}") ?? throw new Exception($"Could not resolve puzzle for Day: {day}, Part: {part}");
    
    if (Activator.CreateInstance(puzzleType) is IPuzzle puzzle)
    {
        //Load puzzle input
        puzzle.RawInput = File.ReadAllText($@"/Users/mmcdermott/Repos/Personal/Aoc/2023/Day{day}/Part{part}Input.txt");

        var stopwatch = Stopwatch.StartNew();
        puzzle.Solve();
        Console.WriteLine($"Solution complete in {stopwatch.ElapsedMilliseconds}ms");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();