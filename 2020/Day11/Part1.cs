using System;
using System.Linq;

namespace Aoc._2020.Day11
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var inputRows = RawInput.Split(Environment.NewLine).Select(_ => _.ToCharArray()).ToArray();
            var seatLayout = CloneSeatLayout(inputRows);

            var seatsStable = false;
            while(!seatsStable)
            {
                var nextSeatLayout = GetNextSeatLayout(seatLayout);

                Console.WriteLine(string.Join(Environment.NewLine, seatLayout.Select(_ => string.Join(string.Empty, _))));
                Console.WriteLine("--------------------------------");
                Console.WriteLine(string.Join(Environment.NewLine, nextSeatLayout.Select(_ => string.Join(string.Empty, _))));

                seatsStable = SeatLayoutsAreIdentical(seatLayout, nextSeatLayout);

                seatLayout = CloneSeatLayout(nextSeatLayout);
                Console.WriteLine();
                Console.WriteLine();
            }

            answer = GetOccupiedSeatCount(seatLayout);

            Console.WriteLine("Day 11, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private static char[][] GetNextSeatLayout(char[][] seatLayout)
        {
            var newSeatLayout = CloneSeatLayout(seatLayout);

            for (int i = 0; i < newSeatLayout.Length; i++)
            {
                for (int j = 0; j < newSeatLayout[0].Length; j++)
                {
                    var adjacentSeats = GetAdjacentSeatsSafely(i, j, seatLayout);
                    switch (newSeatLayout[i][j])
                    {
                        case '.':
                            break;
                        case 'L':
                            if (!adjacentSeats.Contains('#'))
                            {
                                newSeatLayout[i][j] = '#';
                            }
                            break;
                        case '#':
                            if (adjacentSeats.Where(_ => _ == '#').Count() >= 4)
                            {
                                newSeatLayout[i][j] = 'L';
                            }
                            break;
                    }
                }
            }

            return newSeatLayout;
        }

        private static string GetAdjacentSeatsSafely(int i, int j, char[][] seatLayout)
        {
            var adjacentSeats = new char[8];
            var maxRows = seatLayout.Length;
            var maxColumns = seatLayout[0].Length;

            adjacentSeats[0] = i > 0 && j > 0 ? seatLayout[i - 1][j - 1] : ' ';
            adjacentSeats[1] = i > 0 ? seatLayout[i - 1][j] : ' ';
            adjacentSeats[2] = i > 0 && j < maxColumns - 1 ? seatLayout[i - 1][j + 1] : ' ';
            adjacentSeats[3] = j > 0 ? seatLayout[i][j - 1] : ' ';
            adjacentSeats[4] = j < maxColumns - 1 ? seatLayout[i][j + 1] : ' ';
            adjacentSeats[5] = i < maxRows - 1 && j > 0 ? seatLayout[i + 1][j - 1] : ' ';
            adjacentSeats[6] = i < maxRows - 1 ? seatLayout[i + 1][j] : ' ';
            adjacentSeats[7] = i < maxRows - 1 && j < maxColumns - 1 ? seatLayout[i + 1][j + 1] : ' ';

            return string.Join(string.Empty, adjacentSeats);
        }

        //I have no idea if this is necessary, I always struggle with ref vs. value
        private static char[][] CloneSeatLayout(char[][] seatLayout)
        {
            var newGrid = new char[seatLayout.Length][];

            for (int i = 0; i < seatLayout.Length; i++)
            {
                newGrid[i] = new char[seatLayout[i].Length];
                for (int j = 0; j < seatLayout[0].Length; j++)
                {
                    newGrid[i][j] = seatLayout[i][j];
                }
            }

            return newGrid;
        }

        private static int GetOccupiedSeatCount(char[][] seatLayout)
        {
            return string.Join(string.Empty, seatLayout.Select(_ => string.Join(string.Empty, _))).Where(_ => _ == '#').Count();
        }

        private static bool SeatLayoutsAreIdentical(char[][] layout1, char[][] layout2)
        {
            return string.Join(string.Empty, layout1.Select(_ => string.Join(string.Empty, _))) == string.Join(string.Empty, layout2.Select(_ => string.Join(string.Empty, _)));
        }
    }
}