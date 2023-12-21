using System.Diagnostics;

namespace Aoc._2023.Day05
{
    public class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            long answer = 0;
            var almanac = RawInput.Split("\r\n").ToList();
            var seedList = new List<long>();
            var seedToSoilMap = new List<Range>();
            var soilToFertilizerMap = new List<Range>();
            var fertilizerToWaterMap = new List<Range>();
            var waterToLightMap = new List<Range>();
            var lightToTemperatureMap = new List<Range>();
            var temperatureToHumidityMap = new List<Range>();
            var humidityToLocationMap = new List<Range>();

            var locationNumbers = new List<long>();



            //var seedRanges = almanac[0][7..].Split(" ").Select(_ => long.Parse(_)).ToList();


            //Parse the almanac
            for (int i = 0; i < almanac.Count; i++)
            {
                var prefix = almanac[i].Length > 7 ? almanac[i][..7] : almanac[i];
                switch (prefix)
                {
                    //TODO:  Need to process one range at a time, find the smallest of that range, and then move on to the next range
                    case "seeds: ":
                        var seedRanges = almanac[i][7..].Split(" ").Select(_ => long.Parse(_)).ToList();
                        for (int j = 0; j < seedRanges.Count - 1; j += 2)
                        {
                            seedList.AddRange(CreateRange(seedRanges[j], seedRanges[j + 1]).ToList());
                            Console.WriteLine($"{DateTime.Now}: Created range for {j} - {j + 1}");
                        }
                        i++;
                        break;

                    case "seed-to":
                        i++;
                        while (!string.IsNullOrEmpty(almanac[i]))
                        {
                            AddToMap(almanac[i], seedToSoilMap);
                            i++;
                        }
                        break;

                    case "soil-to":
                        i++;
                        while (!string.IsNullOrEmpty(almanac[i]))
                        {
                            AddToMap(almanac[i], soilToFertilizerMap);
                            i++;
                        }
                        break;

                    case "fertili":
                        i++;
                        while (!string.IsNullOrEmpty(almanac[i]))
                        {
                            AddToMap(almanac[i], fertilizerToWaterMap);
                            i++;
                        }
                        break;

                    case "water-t":
                        i++;
                        while (!string.IsNullOrEmpty(almanac[i]))
                        {
                            AddToMap(almanac[i], waterToLightMap);
                            i++;
                        }
                        break;

                    case "light-t":
                        i++;
                        while (!string.IsNullOrEmpty(almanac[i]))
                        {
                            AddToMap(almanac[i], lightToTemperatureMap);
                            i++;
                        }
                        break;

                    case "tempera":
                        i++;
                        while (!string.IsNullOrEmpty(almanac[i]))
                        {
                            AddToMap(almanac[i], temperatureToHumidityMap);
                            i++;
                        }
                        break;

                    case "humidit":
                        i++;
                        while (i < almanac.Count && !string.IsNullOrEmpty(almanac[i]))
                        {
                            AddToMap(almanac[i], humidityToLocationMap);
                            i++;
                        }
                        break;

                    default:
                        i++;
                        break;

                }
            }

            var count = 0;
            var sw = Stopwatch.StartNew();
            foreach (var seedNumber in seedList)
            {
                long soilNumber = GetNextValue(seedToSoilMap, seedNumber);
                long fertilizerNumber = GetNextValue(soilToFertilizerMap, soilNumber);
                long waterNumber = GetNextValue(fertilizerToWaterMap, fertilizerNumber);
                long lightNumber = GetNextValue(waterToLightMap, waterNumber);
                long temperatureNumber = GetNextValue(lightToTemperatureMap, lightNumber);
                long humidityNumber = GetNextValue(temperatureToHumidityMap, temperatureNumber);
                long locationNumber = GetNextValue(humidityToLocationMap, humidityNumber);
                locationNumbers.Add(locationNumber);
                count++;

                if(count > 10000000)
                {
                    Console.WriteLine($"1,000,000 out of {seedList.Count.ToString("N0")} in {sw.ElapsedMilliseconds}ms");
                    sw = Stopwatch.StartNew();
                    count = 0;
                }
            }

            answer = locationNumbers.Min();

            Console.WriteLine("Day 5, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        private static IEnumerable<long> CreateRange(long start, long count)
        {
            var limit = start + count;

            while (start < limit)
            {
                yield return start;
                start++;
            }
        }

        private static void AddToMap(string rangeValues, List<Range> targetMap)
        {
            var range = rangeValues.Split(" ").Select(_ => long.Parse(_)).ToList();
            targetMap.Add(new Range
            {
                Source = range[1],
                Destination = range[0],
                Length = range[2]
            });
        }

        private static long GetNextValue(List<Range> map, long input)
        {
            long result = 0;
            var range = map.FirstOrDefault(_ => input >= _.Source && input <= _.Source + _.Length);
            if (range != null)
            {
                result = range.Destination + (input - range.Source);
            }
            else
            {
                result = input;
            }

            return result;
        }

        private class Range
        {
            public long Source { get; set; }

            public long Destination { get; set; }

            public long Length { get; set; }

            public override string ToString()
            {
                return $"{Destination} {Source} {Length}";
            }
        }
    }
}
