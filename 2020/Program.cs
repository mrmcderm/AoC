using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Aoc._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            const string day = "07";
            const int part = 2;

            try
            {
                //Load puzzle class
                var puzzle = (IPuzzle)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType($"Aoc._2020.Day{day}.Part{part}"));

                //Load puzzle input
                puzzle.RawInput = File.ReadAllText($@"/Users/mmcdermott/Source/Repos/Aoc/2020/Day{day}/Part{part}Input.txt");

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
        }
    }
}
