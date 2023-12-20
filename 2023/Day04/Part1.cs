namespace Aoc._2023.Day04
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var cards = RawInput.Split("\r\n").ToList();

            foreach (var card in cards)
            {
                var sections = card.Split(": ")[1].Split(" | ");
                var winningNumbers = sections[0].Split(" ").Where(_ => !string.IsNullOrWhiteSpace(_)).ToList();
                var yourNumbers = sections[1].Split(" ").Where(_ => !string.IsNullOrWhiteSpace(_)).ToList();

                var score = 0;
                var winningNumbersCount = 0;
                foreach(var number in yourNumbers)
                {
                    if(winningNumbers.Contains(number))
                    {
                        if (winningNumbersCount == 0)
                        {
                            score = 1;
                            winningNumbersCount++;
                        }
                        else
                            score *= 2;
                    }   
                } 

                answer += score;
            }

            Console.WriteLine("Day 4, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
