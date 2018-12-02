using System;
using System.IO;
using System.Reflection;

namespace AoC._2018
{
    class Program
    {
        static void Main(string[] args)
        {
            const int day = 2;
            const int part = 2;

            try
            {
                //Load puzzle class
                var puzzle = (IPuzzle) Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType($"AoC._2018.Day{day}.Part{part}"));
                
                //Load puzzle input
                puzzle.RawInput = File.ReadAllText($@"..\..\..\Day{day}\Part{part}Input.txt");
                
                puzzle.Solve();
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
