using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc._2020.Day04
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var passportInputStrings = RawInput.Split("\n\n").ToList().Select(_ => _.Replace('\n', ' '));
            var passports = new List<Passport>();

            foreach (var passportInputString in passportInputStrings)
            {
                var passport = new Passport(passportInputString.TrimStart());
                passports.Add(passport);
                if (IsValid(passport))
                {
                    answer++;
                }
            }

            Console.WriteLine("Day 4, Part 1");
            Console.WriteLine($"Answer: {answer}");
        }

        private static bool IsValid(Passport passport)
        {
            return !string.IsNullOrWhiteSpace(passport.byr)
                && !string.IsNullOrWhiteSpace(passport.iyr)
                && !string.IsNullOrWhiteSpace(passport.eyr)
                && !string.IsNullOrWhiteSpace(passport.hgt)
                && !string.IsNullOrWhiteSpace(passport.hcl)
                && !string.IsNullOrWhiteSpace(passport.ecl)
                && !string.IsNullOrWhiteSpace(passport.pid);
        }

        private class Passport
        {
            public string byr { get; set; }
            public string iyr { get; set; }
            public string eyr { get; set; }
            public string hgt { get; set; }
            public string hcl { get; set; }
            public string ecl { get; set; }
            public string pid { get; set; }
            public string cid { get; set; }

            public Passport(string input)
            {
                var attributes = input.Split(" ");

                foreach (var attribute in attributes)
                {
                    var values = attribute.Split(":");
                    switch (values[0])
                    {
                        case "byr":
                            byr = values[1];
                            break;
                        case "iyr":
                            iyr = values[1];
                            break;
                        case "eyr":
                            eyr = values[1];
                            break;
                        case "hgt":
                            hgt = values[1];
                            break;
                        case "hcl":
                            hcl = values[1];
                            break;
                        case "ecl":
                            ecl = values[1];
                            break;
                        case "pid":
                            pid = values[1];
                            break;
                        case "cid":
                            cid = values[1];
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}