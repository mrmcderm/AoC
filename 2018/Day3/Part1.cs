using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2018.Day3
{
    public class Part1 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 3, Part 1");

            var rawClaims = RawInput.Split("\r\n");
            var claims = new List<Claim>();
            foreach (var rawClaim in rawClaims)
            {
                var claim = new Claim();
                var atSplit = rawClaim.Split("@");
                var colonSplit = atSplit[1].Trim().Split(":");
                var commaSplit = colonSplit[0].Split(",");
                var dimensionSplit = colonSplit[1].Trim().Split("x");

                claim.Id = atSplit[0].Trim();
                claim.LeftOffset = int.Parse(commaSplit[0]);
                claim.TopOffset = int.Parse(commaSplit[1]);
                claim.Width = int.Parse(dimensionSplit[0]);
                claim.Height = int.Parse(dimensionSplit[1]);

                claims.Add(claim);
            }

            var fabricWidth = 1000;
            var fabricHeight = 1000;

            var grid = new List<Claim>[fabricWidth, fabricHeight];

            for (var i = 0; i < fabricWidth; i++)
            {
                for (var j = 0; j < fabricHeight; j++)
                {
                    grid[i,j] = new List<Claim>();
                }
            }

            /*
             *  ........
                ...2222.
                ...2222.
                .11XX22.
                .11XX22.
                .111133.
                .111133.
                ........
            */

            foreach (var claim in claims)
            {
                for (var column = claim.LeftOffset; column < claim.LeftOffset + claim.Width; column++)
                {
                    for (var row = claim.TopOffset; row < claim.TopOffset + claim.Height; row++)
                    {
                        grid[column, row].Add(claim);
                    }
                }
            }

            var inchesOverlapped = 0;
            for (var i = 0; i < fabricWidth; i++)
            {
                for (var j = 0; j < fabricHeight; j++)
                {
                    if (grid[i, j].Count > 1)
                    {
                        inchesOverlapped++;
                    }
                }
            }

            Console.WriteLine($"Answer: {inchesOverlapped}");
        }
    }

    public class Claim
    {
        public string Id { get; set; }

        public int TopOffset { get; set; }

        public int LeftOffset { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
    }
}
 