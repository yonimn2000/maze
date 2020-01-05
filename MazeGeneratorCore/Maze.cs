using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

/* Steps:
    1 Make the initial cell the current cell and mark it as visited
    2 While there are unvisited cells
    2.1 If the current cell has any neighbors which have not been visited
    2.1.1 Choose randomly one of the unvisited neighbors
    2.1.2 Push the current cell to the stack
    2.1.3 Remove the wall between the current cell and the chosen cell
    2.1.4 Make the chosen cell the current cell and mark it as visited
    2.2 Else if stack is not empty
    2.2.1 Pop a cell from the stack
    2.2.2 Make it the current cell 
Source: https://en.wikipedia.org/wiki/Maze_generation_algorithm#Recursive_backtracker */

namespace YonatanMankovich.MazeGeneratorCore
{
    public class Maze
    {
        internal MazeCell[,] Cells { get; set; }
        public Size Size { get; internal set; }
        public bool IsDone { get; internal set; }
        internal MazeCell CurrentCell { get; set; }

        internal Stack<MazeCell> CellsStack { get; set; } = new Stack<MazeCell>();
        internal Random Random { get; set; } = new Random();

        internal Maze(Size size)
        {
            if (size.Height < 3 || size.Width < 3)
                throw new Exception($"Too small maze ({size.Width}x{size.Height})"); // TODO: create custom exception.
            Size = new Size(size.Width - (size.Width % 2 == 0 ? 1 : 0), size.Height - (size.Height % 2 == 0 ? 1 : 0)); // Keep dimensions odd.
            Cells = new MazeCell[Size.Height, Size.Width];
            IsDone = false;
        }

        internal bool IsCoordinateOnMaze(int x, int y)
        {
            if (y < 0 || x < 0 || x > Size.Width - 1 || y > Size.Height - 1)
                return false;
            return true;
        }

        internal List<MazeCell> GetUnvisitedNeighboringCellsList(MazeCell currentCell, ushort radius)
        {
            List<MazeCell> neighboringCells = new List<MazeCell>();
            AddNeighboringCellsToList((ushort)(currentCell.X + radius), currentCell.Y);
            AddNeighboringCellsToList((ushort)(currentCell.X - radius), currentCell.Y);
            AddNeighboringCellsToList(currentCell.X, (ushort)(currentCell.Y + radius));
            AddNeighboringCellsToList(currentCell.X, (ushort)(currentCell.Y - radius));
            return neighboringCells;

            void AddNeighboringCellsToList(ushort x, ushort y)
            {
                if (IsCoordinateOnMaze(x, y))
                {
                    MazeCell cell = Cells[y, x];
                    if (!cell.IsVisited && !cell.IsWall)
                        neighboringCells.Add(cell);
                }
            }
        }

        public void SaveAsImage(string fileName)
        {
            Bitmap bitmap = new Bitmap(Size.Width, Size.Height);
            for (ushort y = 0; y < Size.Height; y++)
                for (ushort x = 0; x < Size.Width; x++)
                    bitmap.SetPixel(x, y, Cells[y, x].IsWall ? Color.Black : Color.White);
            bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.Format1bppIndexed).Save(fileName);
        }
    }
}