using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc._2020.Day04
{
    public class Part2 : IPuzzle
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

            Console.WriteLine("Day 4, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private static bool IsValid(Passport passport)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(passport.byr) || !int.TryParse(passport.byr, out int by) || by < 1920 || by > 2002)
                return false;

            if (string.IsNullOrEmpty(passport.iyr) || !int.TryParse(passport.iyr, out int iy) || iy < 2010 || iy > 2020)
                return false;

            if (string.IsNullOrEmpty(passport.eyr) || !int.TryParse(passport.eyr, out int ey) || ey < 2010 || ey > 2030)
                return false;

            if (string.IsNullOrEmpty(passport.hgt) || !passport.hgt.EndsWith("in") && !passport.hgt.EndsWith("cm"))
            {
                return false;
            }
            else
            {
                if (passport.hgt.EndsWith("in"))
                {
                    var ht = int.Parse(passport.hgt[0..^2]);
                    if (ht < 59 || ht > 76)
                        return false;
                }

                if (passport.hgt.EndsWith("cm"))
                {
                    var ht = int.Parse(passport.hgt[0..^2]);
                    if (ht < 150 || ht > 193)
                        return false;
                }
            }

            if (string.IsNullOrEmpty(passport.hcl) || !new Regex("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$").Match(passport.hcl).Success)
                return false;

            //This should probably be a regex as well, but quicker to type this than figure out the expression
            var eyeColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if(string.IsNullOrEmpty(passport.ecl) || !eyeColors.Contains(passport.ecl))
                return false;

            if (string.IsNullOrEmpty(passport.pid) || passport.pid.Length != 9 || !int.TryParse(passport.pid, out int result))
                return false;

            return isValid;
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