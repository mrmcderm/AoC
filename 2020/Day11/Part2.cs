using System;
using System.Linq;
using System.Text;

namespace Aoc._2020.Day11
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var inputRows = RawInput.Split(Environment.NewLine).Select(_ => _.ToCharArray()).ToArray();
            var seatLayout = CloneSeatLayout(inputRows);

            var seatsStable = false;
            while (!seatsStable)
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

            Console.WriteLine("Day 11, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private static char[][] GetNextSeatLayout(char[][] seatLayout)
        {
            var newSeatLayout = CloneSeatLayout(seatLayout);

            for (int i = 0; i < newSeatLayout.Length; i++)
            {
                for (int j = 0; j < newSeatLayout[0].Length; j++)
                {
                    string visibleSeats;
                    switch (newSeatLayout[i][j])
                    {
                        case '.':
                            break;
                        case 'L':
                            visibleSeats = GetVisibleSeatsSafely(i, j, seatLayout);
                            if (!visibleSeats.Contains('#'))
                            {
                                newSeatLayout[i][j] = '#';
                            }
                            break;
                        case '#':
                            visibleSeats = GetVisibleSeatsSafely(i, j, seatLayout);
                            if (visibleSeats.Where(_ => _ == '#').Count() >= 5)
                            {
                                newSeatLayout[i][j] = 'L';
                            }
                            break;
                    }
                }
            }

            return newSeatLayout;
        }

        private static string GetVisibleSeatsSafely(int i, int j, char[][] seatLayout)
        {
            var sb = new StringBuilder();
            var maxRows = seatLayout.Length;
            var maxColumns = seatLayout[0].Length;

            //360
            int m;
            int n = j;
            for (m = i-1; m >= 0; m--)
            {
                sb.Append(seatLayout[m][n]);

                if (seatLayout[m][n] == 'L' || seatLayout[m][n] == '#')
                    break;
            };

            //045
            m = i-1;
            n = j+1;
            while(m >= 0 && n < maxColumns)
            {
                sb.Append(seatLayout[m][n]);

                if (seatLayout[m][n] == 'L' || seatLayout[m][n] == '#')
                    break;

                m--;
                n++;
            }

            //090
            m = i;
            for (n = j+1; n < maxColumns; n++)
            {
                sb.Append(seatLayout[m][n]);

                if (seatLayout[m][n] == 'L' || seatLayout[m][n] == '#')
                    break;
            };

            //135
            m = i+1;
            n = j+1;
            while (m < maxRows && n < maxColumns)
            {
                sb.Append(seatLayout[m][n]);

                if (seatLayout[m][n] == 'L' || seatLayout[m][n] == '#')
                    break;

                m++;
                n++;             
            }

            //180
            n = j;
            for (m = i+1; m < maxRows; m++)
            {
                sb.Append(seatLayout[m][n]);

                if (seatLayout[m][n] == 'L' || seatLayout[m][n] == '#')
                    break;             
            };

            //225
            m = i+1;
            n = j-1;
            while (m < maxRows && n >= 0)
            {
                sb.Append(seatLayout[m][n]);

                if (seatLayout[m][n] == 'L' || seatLayout[m][n] == '#')
                    break;

                m++;
                n--;
            }

            //270
            m = i;
            for (n = j-1; n >= 0; n--)
            {
                sb.Append(seatLayout[m][n]);

                if (seatLayout[m][n] == 'L' || seatLayout[m][n] == '#')
                    break;            
            };

            //315
            m = i - 1;
            n = j - 1;
            while (m >= 0 && n >= 0)
            {
                sb.Append(seatLayout[m][n]);

                if (seatLayout[m][n] == 'L' || seatLayout[m][n] == '#')
                    break;

                m--;
                n--;
            }

            return sb.ToString();
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