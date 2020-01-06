namespace YonatanMankovich.MazeCore
{
    public class MazeCell
    {
        public ushort X { get; set; }
        public ushort Y { get; set; }
        public bool IsVisited { get; set; } = false;
        public bool IsWall { get; set; } = false;

        public MazeCell(ushort x, ushort y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}