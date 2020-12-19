using System.Collections.Generic;

namespace Aoc._2020
{
    public static class ExtensionMethods
    {
        public static IEnumerable<int> AllIndexesOf(this List<int> numbers, int searchNumbers)
        {
            int minIndex = numbers.IndexOf(searchNumbers);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = numbers.IndexOf(searchNumbers, minIndex + 1);
            }
        }
    }
}
