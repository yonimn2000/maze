using System.Drawing;

namespace YonatanMankovich.MazeCore.Exceptions
{
    public class MazeTooSmallException : MazeException
    {
        public Size Size { get; set; }

        public MazeTooSmallException() { }

        public MazeTooSmallException(Size size) : base($"Can't create a maze smaller than 3x3 size (Given size: {size})")
        {
            Size = size;
        }
    }
}