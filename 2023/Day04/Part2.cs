namespace Aoc._2023.Day04
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var rawCards = RawInput.Split("\r\n").ToList();
            var cards = new Dictionary<int, string>();

            foreach(var rawCard in rawCards)
            {
                var cardNumber = int.Parse(rawCard.Split(":")[0].Remove(0, 4));
                cards.Add(cardNumber, rawCard.Split(": ")[1]);
            }

            Console.WriteLine("Day 4, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
