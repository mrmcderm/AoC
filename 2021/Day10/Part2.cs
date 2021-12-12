namespace Aoc._2021.Day10
{
    public class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            long answer = 0;
            var lines = RawInput.Split(Environment.NewLine).ToList();
            var incompleteLines = new List<Stack<char>>();
            var scores = new List<long>();

            foreach (var line in lines)
            {
                var characters = new Stack<char>();
                var isCorrupt = false;
                foreach (var character in line)
                {
                    char matachingCharacter;
                    switch (character)
                    {
                        case '(':
                            characters.Push(character);
                            break;
                        case '[':
                            characters.Push(character);
                            break;
                        case '{':
                            characters.Push(character);
                            break;
                        case '<':
                            characters.Push(character);
                            break;
                        case ')':
                            matachingCharacter = characters.Pop();
                            if (matachingCharacter != '(')
                                isCorrupt = true;
                            continue;
                        case ']':
                            matachingCharacter = characters.Pop();
                            if (matachingCharacter != '[')
                                isCorrupt = true;
                            continue;
                        case '}':
                            matachingCharacter = characters.Pop();
                            if (matachingCharacter != '{')
                                isCorrupt = true;
                            continue;
                        case '>':
                            matachingCharacter = characters.Pop();
                            if (matachingCharacter != '<')
                                isCorrupt = true;
                            continue;
                    }
                }

                if (!isCorrupt)
                    incompleteLines.Add(characters);
            }


            foreach(var incompleteLine in incompleteLines)
            {
                long characterScore = 0;
                foreach(var character in incompleteLine)
                {
                    characterScore *= 5;
                    switch(character)
                    {
                        case '(':
                            characterScore += 1;
                            break;
                        case '[':
                            characterScore += 2;
                            break;
                        case '{':
                            characterScore += 3;
                            break;
                        case '<':
                            characterScore += 4;
                            break;
                    }
                }

                scores.Add(characterScore);
            }
            scores = scores.OrderBy(_ => _).ToList();
            answer = scores[(scores.Count - 1) / 2];

            Console.WriteLine("Day 10, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
