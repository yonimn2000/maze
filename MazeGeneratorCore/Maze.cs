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
        public Cell[] Cells { get; internal set; }
        public Size Size { get; internal set; }
        public Bitmap Bitmap { get; internal set; }
        public bool IsDone { get; internal set; }
        public Cell CurrentCell { get; internal set; }
        internal Stack<Cell> cellsStack = new Stack<Cell>();
        internal Random random = new Random();

        public Maze(Size size)
        {
            if (size.Height < 3 || size.Width < 3)
                throw new Exception($"Too small maze ({size.Width}x{size.Height})");
            Size = size;
            if (Size.Width % 2 == 0)
                Size = new Size(Size.Width - 1, Size.Height);
            if (Size.Height % 2 == 0)
                Size = new Size(Size.Width, Size.Height - 1);
            Bitmap = new Bitmap(Size.Width, Size.Height);
            Cells = new Cell[Size.Height * Size.Width];
            IsDone = false;
            for (int y = 0; y < Size.Height; y++)
                for (int x = 0; x < Size.Width; x++)
                {
                    Cells[CellCoordinate(x, y)] = new Cell(x, y);
                    if (y == 0 || y == Size.Height - 1 || x == 0 || x == Size.Width - 1 || x % 2 == 0 || y % 2 == 0)
                        SetCellWall(x, y, true); //Set walls around
                    else
                        SetCellWall(x, y, false);
                }
            SetCellWall(1, 0, false); //Start cell
            SetCellWall(Size.Width - 2, Size.Height - 1, false); //End cell
        }

        /// <summary> Creates a maze from an image file. </summary>
        internal Maze(string path)
        {
            Bitmap image = new Bitmap(path);
            Bitmap = new Bitmap(image);
            image.Dispose();
            Size = new Size(Bitmap.Width, Bitmap.Height);
            Cells = new Cell[Size.Height * Size.Width];
            IsDone = false;
            for (int y = 0; y < Size.Height; y++)
                for (int x = 0; x < Size.Width; x++)
                {
                    Cells[CellCoordinate(x, y)] = new Cell(x, y);
                    Cells[CellCoordinate(x, y)].IsWall = Bitmap.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0);
                }
            Bitmap = Bitmap.Clone(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), PixelFormat.Format24bppRgb);
        }

        internal void SetCellWall(int x, int y, bool isWall)
        {
            Cells[CellCoordinate(x, y)].IsWall = isWall;
            Bitmap.SetPixel(x, y, isWall ? Color.Black : Color.White);
        }

        public int CellCoordinate(int x, int y)
        {
            if (y < 0 || x < 0 || x > Size.Width - 1 || y > Size.Height - 1)
                return -1;
            return x + y * Size.Width;
        }

        public List<Cell> GetUnvisitedNeighboringCellsList(Cell currentCell, int radius)
        {
            List<Cell> neighboringCells = new List<Cell>();
            AddNeighboringCellsToList(CellCoordinate(currentCell.X + radius, currentCell.Y));
            AddNeighboringCellsToList(CellCoordinate(currentCell.X - radius, currentCell.Y));
            AddNeighboringCellsToList(CellCoordinate(currentCell.X, currentCell.Y + radius));
            AddNeighboringCellsToList(CellCoordinate(currentCell.X, currentCell.Y - radius));
            return neighboringCells;

            void AddNeighboringCellsToList(int index)
            {
                if (index > 0)
                {
                    Cell cell = Cells[index];
                    if (!cell.IsVisited && !cell.IsWall)
                        neighboringCells.Add(cell);
                }
            }
        }

        public void SaveAsImage(string fileName, bool openAfterSaving = false)
        {
            Bitmap.Clone(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), PixelFormat.Format1bppIndexed).Save(fileName);
            if (openAfterSaving)
                System.Diagnostics.Process.Start(fileName);
        }

        public class Cell
        {
            public int X;
            public int Y;
            public bool IsVisited;
            public bool IsWall;
            public bool IsSolution;

            public Cell(int x, int y)
            {
                X = x;
                Y = y;
                IsVisited = false;
                IsWall = false;
                IsSolution = false;
            }
        }
    }
}