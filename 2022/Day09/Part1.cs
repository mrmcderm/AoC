using System.Text;

namespace Aoc._2022.Day09
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;

            var vectors = RawInput.Split("\r\n");
            (int headX, int headY) = (0, 0);
            (int tailX, int tailY) = (0, 0);
            var tailVisits = new List<(int, int)>();

            foreach (var vector in vectors)
            {
                var decomposedVector = vector.Split(" ");
                var heading = decomposedVector[0];
                var distance = int.Parse(decomposedVector[1]);

                for (int step = 0; step < distance; step++)
                {

                    //Move the head
                    switch (heading)
                    {
                        case "R":
                            headX += 1;
                            break;
                        case "U":
                            headY += 1;
                            break;
                        case "L":
                            headX -= 1;
                            break;
                        case "D":
                            headY -= 1;
                            break;
                    }

                    //Move the tail
                    //If head is direclty 2 steps up, down, left, or right, move tail 1 spot in that direction
                    //Up
                    if (headX == tailX && headY - tailY == 2)
                        tailY++;

                    //Down
                    if (headX == tailX && tailY - headY == 2)
                        tailY--;

                    //left
                    if (headY == tailY && tailX - headX == 2)
                        tailX--;

                    //right
                    if (headY == tailY && headX - tailX == 2)
                        tailX++;



                    //if the head and tail aren't touching and aren't in the same row or column, the tail always moves one step diagonally to keep up:
                    if (headY != tailY && headX != tailX //Not in same row or column
                        && (Math.Abs(headX - tailX) == 2 || Math.Abs(headY - tailY) == 2)) //Not touching...i.e. greater than 1 space apart in either direction
                    {
                        //Right 1, Up 2 || //Right 2, Up 1
                        if ((headX - tailX == 1 && headY - tailY == 2) || (headX - tailX == 2 && headY - tailY == 1))
                        {
                            tailX++;
                            tailY++;
                        }

                        //Right 1, Down 2 || Right 2, Down 1
                        if ((headX - tailX == 1 && tailY - headY == 2) || (headX - tailX == 2 && tailY - headY == 1))
                        {
                            tailX++;
                            tailY--;
                        }

                        //Left 1, Up 2 || Left 2, Up 1
                        if ((tailX - headX == 1 && tailY - headY == 2) || (tailX - headX == 2 && tailY - headY == 1))
                        {
                            tailX--;
                            tailY--;
                        }

                        //Left 1, Down 2 || Left 2, Down 1
                        if ((tailX - headX == 1 && headY - tailY == 2) || (tailX - headX == 2 && headY - tailY == 1))
                        {
                            tailX--;
                            tailY++;
                        }
                    }

                    tailVisits.Add((tailX, tailY));

                    //PrettyPrint(headX, headY, tailX, tailY);
                }
            }

            answer = tailVisits.Distinct().Count();

            Console.WriteLine("Day 9, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private void PrettyPrint(int headX, int headY, int tailX, int tailY)
        {
            var grid = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                grid.Add("......");
            }

            var sb = new StringBuilder(grid[tailY]);
            sb[tailX] = 'T';
            grid[tailY] = sb.ToString();

            sb = new StringBuilder(grid[headY]);
            sb[headX] = 'H';
            grid[headY] = sb.ToString();

            grid.Reverse();

            foreach (var row in grid)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine("------");
            Console.WriteLine(string.Empty);
        }
    }
}
