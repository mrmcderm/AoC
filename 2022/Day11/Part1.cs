using System.ComponentModel.DataAnnotations;

namespace Aoc._2022.Day11
{
    public class Part1 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var monkeyRules = RawInput.Split("\r\n\r\n");
            var monkeys = new List<Monkey>();

            foreach (var rule in monkeyRules)
            {
                var decomposedRule = rule.Split("\r\n");
                var monkey = new Monkey();

                //Parse Id
                monkey.Id = int.Parse(decomposedRule[0].Split(" ")[1].Split(":")[0]);

                //Parse Starting Items
                monkey.Items = decomposedRule[1].Split(": ")[1].Split(", ").Select(_ => int.Parse(_)).ToList();

                //Parse Operation
                var decomposedOperation = decomposedRule[2].Split(" = ")[1].Split(" ");
                monkey.Operand1 = decomposedOperation[0];
                monkey.Operator = decomposedOperation[1];
                monkey.Operand2 = decomposedOperation[2];

                //Parse Test Value
                monkey.TestValue = int.Parse(decomposedRule[3].Split("Test: divisible by ")[1]);

                //Parse Target Monkey when Test is True
                monkey.TargetMonkeyIdWhenTestTrue = int.Parse(decomposedRule[4].Split("If true: throw to monkey ")[1]);

                //Parse Target Monkey when Test is False
                monkey.TargetMonkeyIdWhenTestFalse = int.Parse(decomposedRule[5].Split("If false: throw to monkey ")[1]);

                monkeys.Add(monkey);
            }

            for(int round = 1; round <= 20; round++)
            {
                foreach(var monkey in monkeys)
                {
                    //Need to clone monkey's items because we can't change the original list while iterating over it (i.e. can't remove)
                    var items = new List<int>(monkey.Items);

                    foreach (var item in items)
                    {
                        var old = item;
                        monkey.Items.RemoveAt(0);

                        var worryLevel = GetWorryLevel(monkey.Operand1 == "old" ? old : int.Parse(monkey.Operand1), monkey.Operator, monkey.Operand2 == "old" ? old : int.Parse(monkey.Operand2));

                        monkey.InspectionCount++;

                        var modifiedWorryLevel = worryLevel / 3;

                        if(modifiedWorryLevel % monkey.TestValue == 0)
                        {
                            monkeys.First(_ => _.Id == monkey.TargetMonkeyIdWhenTestTrue).Items.Add(modifiedWorryLevel);
                        }
                        else
                        {
                            monkeys.First(_ => _.Id == monkey.TargetMonkeyIdWhenTestFalse).Items.Add(modifiedWorryLevel);
                        }
                    }
                }
            }

            var inspectionCounts = monkeys.Select(_ => _.InspectionCount).OrderByDescending(_ => _).ToList();

            answer = inspectionCounts[0] * inspectionCounts[1];

            Console.WriteLine("Day 11, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private static int GetWorryLevel(int operand1, string @operator, int operand2)
        {
            return @operator switch
            {
                "*" => operand1 * operand2,
                "+" => operand1 + operand2,
                _ => 0,
            };
        }

        public class Monkey
        {
            public int Id { get; set; }

            public List<int> Items;

            public string Operand1 { get; set; }

            public string Operand2 { get; set; }

            public string Operator { get; set; }

            public int TestValue { get; set; }

            public int TargetMonkeyIdWhenTestTrue { get; set; }

            public int TargetMonkeyIdWhenTestFalse { get; set; }

            public int InspectionCount { get; set; }

            public override string ToString()
            {
                return $"{Id}: {String.Join(",", Items)}; {Operand1} {Operator} {Operand2}; {TestValue}; True Monkey: {TargetMonkeyIdWhenTestTrue}; False Monkey: {TargetMonkeyIdWhenTestFalse}; Inspection Count: {InspectionCount}";
            }
        }
    }
}
