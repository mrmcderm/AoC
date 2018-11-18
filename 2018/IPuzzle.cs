namespace AoC._2018
{
    public interface IPuzzle
    {
        string RawInput { get; set; }

        void Solve();
    }
}