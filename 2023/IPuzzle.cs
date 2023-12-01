namespace Aoc._2023
{
    public interface IPuzzle
    {
        string? RawInput { get; set; }

        void Solve();
    }
}