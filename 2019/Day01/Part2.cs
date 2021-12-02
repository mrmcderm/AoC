using System;

namespace Aoc._2019.Day01
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            decimal answer = 0;
            var massValues = RawInput.Split(Environment.NewLine);

            foreach (var massValue in massValues)
            {
                var initialFuelRequirement = Math.Round((decimal)(Convert.ToInt32(massValue) / 3), MidpointRounding.ToZero) - 2;
                var additionalFuelRequirement = GetFuelRequirements(initialFuelRequirement);
                answer += initialFuelRequirement + additionalFuelRequirement;
            }

            Console.WriteLine("Day 1, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        public decimal GetFuelRequirements(decimal inputMass)
        {
            var fuelRequierment = Math.Round((decimal)(Convert.ToInt32(inputMass) / 3), MidpointRounding.ToZero) - 2;

            if (fuelRequierment > 0)
            {
                fuelRequierment += GetFuelRequirements(fuelRequierment);
            }

            return fuelRequierment > 0 ? fuelRequierment : 0;
        }
    }
}
