namespace Aoc._2021.Day10
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var lines = RawInput.Split(Environment.NewLine).ToList();
            var bogusCharacters = new List<char>();

            foreach (var line in lines)
            {
                var characters = new Stack<char>();
                foreach(var character in line)
                {
                    char matachingCharacter;
                    switch(character)
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
                            if(matachingCharacter != '(')
                                bogusCharacters.Add(character);
                            continue;
                        case ']':
                            matachingCharacter = characters.Pop();
                            if (matachingCharacter != '[')
                                bogusCharacters.Add(character);
                            continue;
                        case '}':
                            matachingCharacter = characters.Pop();
                            if (matachingCharacter != '{')
                                bogusCharacters.Add(character);
                            continue;
                        case '>':
                            matachingCharacter = characters.Pop();
                            if (matachingCharacter != '<')
                                bogusCharacters.Add(character);
                            continue;
                    }
                }
            }

            answer += bogusCharacters.Count(_ => _ == ')') * 3;
            answer += bogusCharacters.Count(_ => _ == ']') * 57;
            answer += bogusCharacters.Count(_ => _ == '}') * 1197;
            answer += bogusCharacters.Count(_ => _ == '>') * 25137;

            Console.WriteLine("Day 10, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }
    }
}
