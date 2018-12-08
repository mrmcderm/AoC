using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AoC._2018
{
    internal class Program
    {
        private static void Main()
        {
            const int day = 8;
            const int part = 2;

            try
            {
                //Load puzzle class
                var puzzle = (IPuzzle) Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType($"AoC._2018.Day{day}.Part{part}"));
                
                //Load puzzle input
                puzzle.RawInput = File.ReadAllText($@"..\..\..\Day{day}\Part{part}Input.txt");

                var stopwatch = Stopwatch.StartNew();
                puzzle.Solve();
                Console.WriteLine($"Solution complete in {stopwatch.ElapsedMilliseconds}");
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
