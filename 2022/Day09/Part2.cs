using System.Text;

namespace Aoc._2022.Day09
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var vectors = RawInput.Split("\r\n");
            (int headX, int headY) = (0, 0);
            (int tailX, int tailY) = (0, 0);
            var tailVisits = new List<(int, int)>();
            var ropeKnots = new List<(int x, int y)>();
            for (int i = 0; i < 10; i++)
            {
                ropeKnots.Add((0, 0));
            }

            foreach (var vector in vectors)
            {
                var decomposedVector = vector.Split(" ");
                var heading = decomposedVector[0];
                var distance = int.Parse(decomposedVector[1]);

                for (int step = 0; step < distance; step++)
                {
                    //Move the head
                    var head = ropeKnots[0];
                    switch (heading)
                    {
                        case "R":
                            head.x++;
                            break;
                        case "U":
                            head.y++;
                            break;
                        case "L":
                            head.x--;
                            break;
                        case "D":
                            head.y--;
                            break;
                    }
                    ropeKnots[0] = head;

                    //Move the rest
                    for (int i = 1; i < ropeKnots.Count(); i++)
                    {
                        var newKnotPosition = GetNewKnotPosition(ropeKnots[i - 1].x, ropeKnots[i - 1].y, ropeKnots[i].x, ropeKnots[i].y);
                        ropeKnots[i] = newKnotPosition;
                    }

                    tailVisits.Add(ropeKnots[9]);

                    //PrettyPrint(ropeKnots);
                }
            }

            answer = tailVisits.Distinct().Count();

            Console.WriteLine("Day 9, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private (int, int) GetNewKnotPosition(int headX, int headY, int tailX, int tailY)
        {
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
                //Right 1, Up 2 || Right 2, Up 1
                if ((headX - tailX == 1 && headY - tailY == 2) || (headX - tailX == 2 && headY - tailY == 1) || (headX - tailX == 2 && headY - tailY == 2))
                {
                    tailX++;
                    tailY++;
                }

                //Right 1, Down 2 || Right 2, Down 1
                if ((headX - tailX == 1 && tailY - headY == 2) || (headX - tailX == 2 && tailY - headY == 1) || (headX - tailX == 2 && tailY - headY == 2))
                {
                    tailX++;
                    tailY--;
                }

                //Left 1, Up 2 || Left 2, Up 1
                if ((tailX - headX == 1 && tailY - headY == 2) || (tailX - headX == 2 && tailY - headY == 1) || (tailX - headX == 2 && tailY - headY == 2))
                {
                    tailX--;
                    tailY--;
                }

                //Left 1, Down 2 || Left 2, Down 1
                if ((tailX - headX == 1 && headY - tailY == 2) || (tailX - headX == 2 && headY - tailY == 1) || (tailX - headX == 2 && headY - tailY == 2))
                {
                    tailX--;
                    tailY++;
                }
            }

            return (tailX, tailY);
        }

        private void PrettyPrint(List<(int x, int y)> ropeKnots)
        {
            var grid = new List<string>();
            for (int i = 0; i < 21; i++)
            {
                grid.Add("......");
            }

            var sb = new StringBuilder(grid[ropeKnots[9].y]);
            sb[ropeKnots[9].x] = 'T';
            grid[ropeKnots[9].y] = sb.ToString();

            for (int i = 9; i > 0; i--)
            {
                sb = new StringBuilder(grid[ropeKnots[i].y]);
                sb[ropeKnots[i].x] = i.ToString()[0];
                grid[ropeKnots[i].y] = sb.ToString();
            }

            sb = new StringBuilder(grid[ropeKnots[0].y]);
            sb[ropeKnots[0].x] = 'H';
            grid[ropeKnots[0].y] = sb.ToString();

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
