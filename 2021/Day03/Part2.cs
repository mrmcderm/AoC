using System.Collections;

namespace Aoc._2021.Day03
{
    internal class Part2 : IPuzzle
    {
        public string? RawInput { get; set; }

        public void Solve()
        {
            var answer = 0;
            var oxygenDiagnosticNumbers = RawInput.Split(Environment.NewLine).Select(_ => _.ToArray()).ToList();
            var carbonDiagnosticNumbers = RawInput.Split(Environment.NewLine).Select(_ => _.ToArray()).ToList();

            var bitLength = oxygenDiagnosticNumbers[0].Length;
            var oxygenArray = new BitArray(bitLength);
            var carbonArray = new BitArray(bitLength);



            for (int i = 0; i < bitLength; i++)
            {
                var bitCounts = new BitCount[bitLength];

                foreach (var diagnosticNumber in oxygenDiagnosticNumbers)
                {
                    for (int j = 0; j < bitLength; j++)
                    {
                        if(bitCounts[j] == null)
                        {
                            bitCounts[j] = new BitCount()
                            {
                                ZerosCount = 0,
                                OnesCount = 0
                            };
                        }
                        if (diagnosticNumber[j] == '1')
                        {
                            bitCounts[j].OnesCount++;
                        }
                        else
                        {
                            bitCounts[j].ZerosCount++;
                        }
                    }
                }

                if (oxygenDiagnosticNumbers.Count > 1)
                {
                    var bit = bitCounts[i].OnesCount >= bitCounts[i].ZerosCount;

                    var newDiagnosticNumbers = new List<char[]>();

                    foreach (var diagnosticNumber in oxygenDiagnosticNumbers)
                    {
                        if ((bit && diagnosticNumber[i] == '1') || !bit && diagnosticNumber[i] == '0')
                        {
                            newDiagnosticNumbers.Add(diagnosticNumber);
                        }
                    }

                    oxygenDiagnosticNumbers = newDiagnosticNumbers;
                }
            }

            for (int i = 0; i < bitLength; i++)
            {
                var bit = oxygenDiagnosticNumbers[0][i] == '1';
                oxygenArray.Set(i, bit);
            }
            Reverse(oxygenArray);
            int[] array = new int[1];
            oxygenArray.CopyTo(array, 0);
            var oxygen = array[0];








            for (int i = 0; i < bitLength; i++)
            {
                var bitCounts = new BitCount[bitLength];

                foreach (var diagnosticNumber in carbonDiagnosticNumbers)
                {
                    for (int j = 0; j < bitLength; j++)
                    {
                        if (bitCounts[j] == null)
                        {
                            bitCounts[j] = new BitCount()
                            {
                                ZerosCount = 0,
                                OnesCount = 0
                            };
                        }
                        if (diagnosticNumber[j] == '1')
                        {
                            bitCounts[j].OnesCount++;
                        }
                        else
                        {
                            bitCounts[j].ZerosCount++;
                        }
                    }
                }

                if (carbonDiagnosticNumbers.Count > 1)
                {
                    var bit = !(bitCounts[i].OnesCount >= bitCounts[i].ZerosCount);

                    var newDiagnosticNumbers = new List<char[]>();

                    foreach (var diagnosticNumber in carbonDiagnosticNumbers)
                    {
                        if ((bit && diagnosticNumber[i] == '1') || !bit && diagnosticNumber[i] == '0')
                        {
                            newDiagnosticNumbers.Add(diagnosticNumber);
                        }
                    }

                    carbonDiagnosticNumbers = newDiagnosticNumbers;
                }
            }

            for (int i = 0; i < bitLength; i++)
            {
                var bit = carbonDiagnosticNumbers[0][i] == '1';
                carbonArray.Set(i, bit);
            }
            Reverse(carbonArray);
            array = new int[1];
            carbonArray.CopyTo(array, 0);
            var carbon = array[0];









            answer = oxygen * carbon;
            Console.WriteLine("Day 3, Part 2");
            Console.WriteLine($"Answer: {answer}");
        }

        public void Reverse(BitArray array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }
    }
}

public class BitCount
{
    public int ZerosCount { get; set; }

    public int OnesCount { get; set; }
}
