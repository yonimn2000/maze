namespace YonatanMankovich.MazeCore.Exceptions
{
    public class MazeUnsolvableException : MazeException
    {
        public MazeUnsolvableException() : base("The maze is unsolvable.") { }
    }
}