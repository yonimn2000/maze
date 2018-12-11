using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
/*  1 Make the initial cell the current cell and mark it as visited
    2 While there are unvisited cells
    2.1 If the current cell has any neighbors which have not been visited
    2.1.1 Choose randomly one of the unvisited neighbours
    2.1.2 Push the current cell to the stack
    2.1.3 Remove the wall between the current cell and the chosen cell
    2.1.4 Make the chosen cell the current cell and mark it as visited
    2.2 Else if stack is not empty
    2.2.1 Pop a cell from the stack
    2.2.2 Make it the current cell */
namespace Maze
{
    class Maze
    {
        public Cell[] Cells { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Bitmap Bitmap { get; private set; }
        public bool IsDone { get; private set; }
        public Cell CurrentCell { get; private set; }
        private Stack<Cell> cellsStack = new Stack<Cell>();
        private Random random = new Random();

        public Maze(int columns, int rows)
        {
            if (rows < 3 || columns < 3)
                throw new Exception($"Too small maze ({columns}x{rows})");
            Rows = rows;
            Columns = columns;
            if (Columns % 2 == 0)
                Columns--;
            if (Rows % 2 == 0)
                Rows--;
            Bitmap = new Bitmap(Columns, Rows);
            Cells = new Cell[Rows * Columns];
            IsDone = false;
            for (int y = 0; y < Rows; y++)
                for (int x = 0; x < Columns; x++)
                {
                    Cells[CellCoordinate(x, y)] = new Cell(x, y);
                    if (y == 0 || y == Rows - 1 || x == 0 || x == Columns - 1 || x % 2 == 0 || y % 2 == 0)
                        SetCellWall(x, y, true); //Set walls around
                    else
                        SetCellWall(x, y, false);
                }
            SetCellWall(1, 0, false); //Start cell
            SetCellWall(Columns - 2, Rows - 1, false); //End cell
        }

        /// <summary>
        /// Creates a maze from an image file.
        /// </summary>
        /// <param name="path"></param>
        private Maze(string path)
        {
            Bitmap image = new Bitmap(path);
            Bitmap = new Bitmap(image);
            image.Dispose();
            Rows = Bitmap.Height;
            Columns = Bitmap.Width;
            Cells = new Cell[Rows * Columns];
            IsDone = false;
            for (int y = 0; y < Rows; y++)
                for (int x = 0; x < Columns; x++)
                {
                    Cells[CellCoordinate(x, y)] = new Cell(x, y);
                    Cells[CellCoordinate(x, y)].IsWall = Bitmap.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0);
                }
            Bitmap = Bitmap.Clone(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), PixelFormat.Format24bppRgb);
        }

        private void SetCellWall(int x, int y, bool isWall)
        {
            Cells[CellCoordinate(x, y)].IsWall = isWall;
            Bitmap.SetPixel(x, y, isWall ? Color.Black : Color.White);
        }

        public int CellCoordinate(int x, int y)
        {
            if (y < 0 || x < 0 || x > Columns - 1 || y > Rows - 1)
                return -1;
            return x + y * Columns;
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

        public class Maker : Maze
        {
            public Maker(int columns, int rows) : base(columns, rows)
            {
                CurrentCell = Cells[CellCoordinate(1, 1)];
            }

            public void Make()
            {
                while (!IsDone) //Step 2
                    MakeStep();
            }

            public void MakeStep()
            {
                CurrentCell.IsVisited = true; //Step 2.1.4
                List<Cell> neighboringCells = GetUnvisitedNeighboringCellsList(CurrentCell, 2);
                if (neighboringCells.Count > 0) //Step 2.1
                {
                    Cell chosenCell = neighboringCells[random.Next(neighboringCells.Count)]; //Step 2.1.1
                    cellsStack.Push(CurrentCell); //Step 2.1.2
                    RemoveWallBetween2Cells(CurrentCell, chosenCell); //Step 2.1.3
                    CurrentCell = chosenCell; //Step 2.1.4
                }
                else if (cellsStack.Count > 0) //Step 2.2
                    CurrentCell = cellsStack.Pop(); //Step 2.2.1 and 2.2.2
                else
                    IsDone = true;

                void RemoveWallBetween2Cells(Cell currentCell, Cell chosenCell)
                {
                    if (currentCell.X - chosenCell.X == -2)
                        SetCellWall(currentCell.X + 1, currentCell.Y, false);
                    else if (currentCell.X - chosenCell.X == 2)
                        SetCellWall(currentCell.X - 1, currentCell.Y, false);
                    else if (currentCell.Y - chosenCell.Y == -2)
                        SetCellWall(currentCell.X, currentCell.Y + 1, false);
                    else if (currentCell.Y - chosenCell.Y == 2)
                        SetCellWall(currentCell.X, currentCell.Y - 1, false);
                }
            }
        }

        public class Solver : Maze
        {
            public Solver(string filePath) : base(filePath)
            {
                CurrentCell = Cells[CellCoordinate(1, 1)];
                Cells[CellCoordinate(1, 0)].IsVisited = true;
                Cells[CellCoordinate(1, 0)].IsSolution = true;
                Cells[CellCoordinate(Columns - 2, Rows - 1)].IsSolution = true;
                Bitmap.SetPixel(1, 0, Color.Red);
                Bitmap.SetPixel(Columns - 2, Rows - 1, Color.Red);
            }

            public void Solve()
            {
                while (!IsDone) //Step 2
                    SolveStep();
            }

            public void SolveStep()
            {
                CurrentCell.IsVisited = true; //Step 2.1.4
                CurrentCell.IsSolution = true;
                List<Cell> neighboringCells = GetUnvisitedNeighboringCellsList(CurrentCell, 1);
                if (neighboringCells.Count > 0) //Step 2.1
                {
                    Cell chosenCell = neighboringCells[random.Next(neighboringCells.Count)]; //Step 2.1.1
                    cellsStack.Push(CurrentCell); //Step 2.1.2
                    CurrentCell = chosenCell; //Step 2.1.4
                }
                else if (cellsStack.Count > 0) //Step 2.2
                {
                    Cells[CellCoordinate(CurrentCell.X, CurrentCell.Y)].IsSolution = false;
                    CurrentCell = cellsStack.Pop(); //Step 2.2.1 and 2.2.2
                }
                else if (cellsStack.Count == 0)
                    throw new Exception("No solution.");
                if (Cells[CellCoordinate(Columns - 2, Rows - 2)].IsSolution)
                {
                    double value = 0;
                    foreach (Cell cell in cellsStack)
                    {
                        Bitmap.SetPixel(cell.X, cell.Y, ColorFromHSV(value, 1, 1));
                        value += 360f / cellsStack.Count;
                    }
                    IsDone = true;
                }

                Color ColorFromHSV(double hue, double saturation, double value)
                {
                    int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
                    double f = hue / 60 - Math.Floor(hue / 60);
                    value = value * 255;
                    int v = Convert.ToInt32(value);
                    int p = Convert.ToInt32(value * (1 - saturation));
                    int q = Convert.ToInt32(value * (1 - f * saturation));
                    int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));
                    if (hi == 0)
                        return Color.FromArgb(255, v, t, p);
                    else if (hi == 1)
                        return Color.FromArgb(255, q, v, p);
                    else if (hi == 2)
                        return Color.FromArgb(255, p, v, t);
                    else if (hi == 3)
                        return Color.FromArgb(255, p, q, v);
                    else if (hi == 4)
                        return Color.FromArgb(255, t, p, v);
                    else
                        return Color.FromArgb(255, v, p, q);
                }
            }

            public void SaveSolutionAsImage(string fileName, bool openAfterSaving = false)
            {
                Bitmap.Clone(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), PixelFormat.Format24bppRgb).Save(fileName);
                if (openAfterSaving)
                    System.Diagnostics.Process.Start(fileName);
            }
        }
    }
}