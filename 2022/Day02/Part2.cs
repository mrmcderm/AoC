namespace Aoc._2022.Day02
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var rounds = RawInput.Split("\r\n").ToList();

            // A X = ROCK - 1
            // B Y = PAPER - 2 
            // C Z = SCISSORS - 3
            // WIN = 6
            // DRAW = 3
            // LOSE = 0
            // X - LOSE
            // Y - DRAW
            // Z - WIN

            foreach (var round in rounds)
            {
                switch (round)
                {
                    case "A Y":
                        answer += 4;
                        break;
                    case "A X":
                        answer += 3;
                        break;
                    case "A Z":
                        answer += 8;
                        break;
                    case "B Y":
                        answer += 5;
                        break;
                    case "B X":
                        answer += 1;
                        break;
                    case "B Z":
                        answer += 9;
                        break;
                    case "C Y":
                        answer += 6;
                        break;
                    case "C X":
                        answer += 2;
                        break;
                    case "C Z":
                        answer += 7;
                        break;
                }
            }

            Console.WriteLine("Day 2, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
