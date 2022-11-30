namespace Aoc._2022
{
    public interface IPuzzle
    {
        string? RawInput { get; set; }

        void Solve();
    }
}