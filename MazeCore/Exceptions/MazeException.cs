using System;

namespace YonatanMankovich.MazeCore.Exceptions
{
    public class MazeException : Exception
    {
        public MazeException() : this("A maze exception has occurred.") { }
        public MazeException(string message) : base(message) { }
    }
}