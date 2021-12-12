namespace Aoc._2021.Day11
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }
        public int gridSize;

        public void Solve()
        {
            long answer = 0;
            var octos = new List<Octo>();

            var rows = RawInput.Split(Environment.NewLine).ToArray();
            gridSize = rows.Length;
            for (var y = 0; y < rows.Length; y++)
            {
                for (int x = 0; x < rows[y].Length; x++)
                {
                    var octo = new Octo() 
                    { 
                        X = x, 
                        Y = y,
                        Energy = int.Parse(rows[y][x].ToString())
                    };
                    octo.Neighbors = GetNeighborsSafely(octo);
                    octos.Add(octo);
                }
            }

            Console.WriteLine("Before any steps:");
            PrintOctoGrid(octos);

            //TODO: Structure the grid as a dictionary (or list?) of octo.  an octo is defined as it's energy and it's list of neighbors
            //run through list of octos, increase their energy
            //then grab all the octos with an energy of ten
            //set them to 0, find all their neighbors and increase their energy
            //repeat while still energy of 10 in list


            for (int step = 1; step <= 100; step++)
            {
                //Increase energy level by 1
                for (var y = 0; y < gridSize; y++)
                {
                    for (var x = 0; x < gridSize; x++)
                    {
                        var octo = octos.First(_ => _.X == x && _.Y == y);
                        octo.Energy++;
                    }
                }

                while (octos.Any(_ => _.Energy > 9))
                {
                    //Flash all high energy octos
                    var flashOctos = octos.Where(_ => _.Energy > 9).ToList();
                    foreach (var flashOcto in flashOctos)
                    {
                        flashOcto.Energy = 0;
                        answer++;
                    }

                    //Increment the neighbors of all
                    foreach (var flashOcto in flashOctos)
                    {
                        foreach (var neighbor in flashOcto.Neighbors)
                        {
                            var neighborOcto = octos.First(_ => _.X == neighbor.X && _.Y == neighbor.Y);
                            if (neighborOcto.Energy != 0) //exclude just flashed octos
                                neighborOcto.Energy++;
                        }
                    }
                }

                Console.WriteLine($"After step {step}:");
                PrintOctoGrid(octos);
            }

            Console.WriteLine();
            Console.WriteLine("Day 11, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private void PrintOctoGrid(List<Octo> octos)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    var octo = octos.First(_ => _.X == x && _.Y == y);

                    if (octo.Energy == 0)
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    Console.Write(octo.Energy);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private List<Octo> GetNeighborsSafely(Octo octo)
        {
            var results = new List<Octo>();
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    var newX = octo.X + x;
                    var newY = octo.Y + y;

                    if (newX > -1 && newY > -1 && newX < gridSize && newY < gridSize)
                    {
                        results.Add(new Octo() { X = newX, Y = newY });
                    }
                }
            }
            return results;
        }
    }

    public class Octo
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Energy { get; set; }

        public List<Octo> Neighbors { get; set; }

        public Octo()
        {
            Neighbors = new List<Octo>();
        }

        public override string ToString()
        {
            return $"({X}, {Y} - E: {Energy} - {Neighbors.Count} Neigbors";
        }
    }
}
