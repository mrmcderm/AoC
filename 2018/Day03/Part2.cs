using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._2018.Day3
{
    public class Part2 : IPuzzle
    {
        public string RawInput { get; set; }

        public void Solve()
        {
            Console.WriteLine("Day 3, Part 2");

            var rawClaims = RawInput.Split("\r\n");

            //Parse the claims
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
                    grid[i, j] = new List<Claim>();
                }
            }

            //Map the claims
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

            /*
                ........
                ...2222.
                ...2222.
                .11XX22.
                .11XX22.
                .111133.
                .111133.
                ........
            */

            var badClaims = new HashSet<Claim>();
            for (var column = 0; column < fabricWidth; column++)
            {
                for (var row = 0; row < fabricHeight; row++)
                {
                    if (grid[column, row].Count <= 1)
                        continue;

                    foreach (var claim in grid[column, row])
                    {
                        badClaims.Add(claim);
                    }
                }
            }

            foreach (var claim in claims)
            {
                if (badClaims.All(_ => _.Id != claim.Id))
                {
                    Console.WriteLine($"Claim: {claim.Id}");
                }
            }
        }
    }
}
