namespace Aoc._2021
{
    public interface IPuzzle
    {
        string? RawInput { get; set; }

        void Solve();
    }
}