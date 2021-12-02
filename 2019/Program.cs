using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Aoc._2019
{
    class Program
    {
        static void Main(string[] args)
        {
            const string day = "01";
            const int part = 2;

            try
            {
                //Load puzzle class //Aoc._2019.Day01.Part1
                var puzzle = (IPuzzle)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType($"Aoc._2019.Day{day}.Part{part}"));

                //Load puzzle input
                puzzle.RawInput = File.ReadAllText($@"..\..\..\Day{day}\Part{part}Input.txt");

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
