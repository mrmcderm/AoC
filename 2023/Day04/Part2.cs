namespace Aoc._2023.Day04
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var rawCards = RawInput.Split("\r\n").ToList();
            var gameCards = new Dictionary<int, GameCard>();

            foreach (var rawCard in rawCards)
            {
                var cardNumber = int.Parse(rawCard.Split(":")[0].Remove(0, 4));
                var sections = rawCard.Split(": ")[1].Split(" | ");
                var winningNumbers = sections[0].Split(" ").Where(_ => !string.IsNullOrWhiteSpace(_)).ToList();
                var yourNumbers = sections[1].Split(" ").Where(_ => !string.IsNullOrWhiteSpace(_)).ToList();

                var matchingNumbers = 0;
                foreach (var number in yourNumbers)
                {
                    if (winningNumbers.Contains(number))
                    {
                        matchingNumbers++;
                    }
                }

                var gameCard = new GameCard() { Number = cardNumber, MatchingNumbers = matchingNumbers };
                gameCards.Add(gameCard.Number, gameCard);
            }

            foreach(var card in gameCards.Values)
            {
                answer += GetScore(card, gameCards);
            }

            Console.WriteLine("Day 4, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private static int GetScore(GameCard gameCard, Dictionary<int, GameCard> originalCards)
        {
            if (gameCard.MatchingNumbers == 0)
                return 1;

            var result = 1;
            var cardIndex = gameCard.MatchingNumbers + gameCard.Number;
            for (int i = cardIndex; i > gameCard.Number; i--)
            {
                result += GetScore(originalCards[i], originalCards);
            }

            return result;
        }
    }

    public class GameCard
    {
        public int Number { get; set; }

        public int MatchingNumbers { get; set; }

        public override string ToString()
        {
            return $"Card {Number}: {MatchingNumbers} Matching Numbers";
        }
    }
}
