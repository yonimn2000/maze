using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Maze
{
    class Maze
    {
        public Cell[] Cells { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public Bitmap Bitmap { get; private set; }

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

        private Maze(string path)
        {
            Bitmap = new Bitmap(path);
            Rows = Bitmap.Height;
            Columns = Bitmap.Width;
            Cells = new Cell[Rows * Columns];
            for (int y = 0; y < Rows; y++)
                for (int x = 0; x < Columns; x++)
                {
                    Cells[CellCoordinate(x, y)] = new Cell(x, y);
                    Cells[CellCoordinate(x, y)].IsWall = Bitmap.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0);
                }
            Bitmap = Bitmap.Clone(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), PixelFormat.Format32bppArgb);
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
            AddNeighboringCellsToList(neighboringCells, CellCoordinate(currentCell.X + radius, currentCell.Y));
            AddNeighboringCellsToList(neighboringCells, CellCoordinate(currentCell.X - radius, currentCell.Y));
            AddNeighboringCellsToList(neighboringCells, CellCoordinate(currentCell.X, currentCell.Y + radius));
            AddNeighboringCellsToList(neighboringCells, CellCoordinate(currentCell.X, currentCell.Y - radius));
            return neighboringCells;
        }

        private void AddNeighboringCellsToList(List<Cell> neighboringCells, int index)
        {
            if (index > 0)
            {
                Cell cell = Cells[index];
                if (!cell.IsVisited && !cell.IsWall)
                    neighboringCells.Add(cell);
            }
        }

        public void SaveAsImage(string fileName)
        {
            Bitmap.Clone(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), PixelFormat.Format1bppIndexed).Save(fileName);
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

            public override string ToString()
            {
                return $"({X}, {Y}), {(IsVisited ? "" : "Not ")}Visited, {(IsWall ? "" : "Not ")}Wall";
            }
        }

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

        public class Maker : Maze
        {
            public bool IsDone { get; private set; }
            public Cell CurrentCell { get; private set; }
            public int StepsCount { get; private set; }
            private Stack<Cell> cellsStack = new Stack<Cell>();
            private Random random = new Random();

            public Maker(int columns, int rows) : base(columns, rows)
            {
                IsDone = false;
                StepsCount = 0;
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
                StepsCount++;
            }

            private void RemoveWallBetween2Cells(Cell currentCell, Cell chosenCell)
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

        public class Solver : Maze
        {
            public bool IsDone { get; private set; }
            public Cell CurrentCell { get; private set; }
            public int StepsCount { get; private set; }
            private Stack<Cell> cellsStack = new Stack<Cell>();
            private Random random = new Random();

            public Solver(string filePath) : base(filePath)
            {
                IsDone = false;
                StepsCount = 0;
                CurrentCell = Cells[CellCoordinate(1, 1)];
                Cells[CellCoordinate(1, 0)].IsVisited=true;
                Cells[CellCoordinate(1, 0)].IsVisited = true;
                SetCellSolution(1, 0, true); //Start cell
                SetCellSolution(Columns - 2, Rows - 1, true); //End cell
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
                SetCellSolution(CurrentCell.X, CurrentCell.Y, true);
                List<Cell> neighboringCells = GetUnvisitedNeighboringCellsList(CurrentCell, 1);
                if (neighboringCells.Count > 0) //Step 2.1
                {
                    Cell chosenCell = neighboringCells[random.Next(neighboringCells.Count)]; //Step 2.1.1
                    cellsStack.Push(CurrentCell); //Step 2.1.2
                    CurrentCell = chosenCell; //Step 2.1.4
                }
                else if (cellsStack.Count > 0) //Step 2.2
                {
                    SetCellSolution(CurrentCell.X, CurrentCell.Y, false);
                    CurrentCell = cellsStack.Pop(); //Step 2.2.1 and 2.2.2
                }
                if (Cells[CellCoordinate(Rows - 2, Columns - 2)].IsSolution)
                    IsDone = true;
                StepsCount++;
            }

            private void SetCellSolution(int x, int y, bool isSolution)
            {
                Cells[CellCoordinate(x, y)].IsSolution = isSolution;
                Bitmap.SetPixel(x, y, isSolution ? Color.Gray : Color.White);
            }

            public void SaveSolutionAsImage(string fileName)
            {
                Bitmap.Clone(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height), PixelFormat.Format8bppIndexed).Save(fileName);
                System.Diagnostics.Process.Start(fileName);
            }
        }
    }
}