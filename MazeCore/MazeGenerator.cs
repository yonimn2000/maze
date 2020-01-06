using System;
using System.Collections.Generic;
using System.Drawing;

namespace YonatanMankovich.MazeCore
{
    public class MazeGenerator : Maze
    {
        public MazeGenerator(Size size) : base(size)
        {
            CreateCellsAndBaseWalls();
            CurrentCell = Cells[1, 1];
        }

        private void CreateCellsAndBaseWalls()
        {
            for (ushort y = 0; y < Size.Height; y++)
                for (ushort x = 0; x < Size.Width; x++)
                {
                    Cells[y, x] = new MazeCell(x, y);
                    Cells[y, x].IsWall = y == 0 || y == Size.Height - 1 || x == 0 || x == Size.Width - 1 || x % 2 == 0 || y % 2 == 0; // Set walls around and inside.
                }
            Cells[0, 1].IsWall = false; //Start cell
            Cells[Size.Height - 1, Size.Width - 2].IsWall = false; //End cell
        }

        public void Generate()
        {
            while (!IsDone) //Step 2
                GenerateStep();
        }

        public void GenerateStep()
        {
            CurrentCell.IsVisited = true; //Step 2.1.4
            List<MazeCell> neighboringCells = GetUnvisitedNeighboringCellsList(CurrentCell, 2);
            if (neighboringCells.Count > 0) //Step 2.1
            {
                MazeCell chosenCell = neighboringCells[Random.Next(neighboringCells.Count)]; //Step 2.1.1
                CellsStack.Push(CurrentCell); //Step 2.1.2
                RemoveWallBetween2Cells(CurrentCell, chosenCell); //Step 2.1.3
                CurrentCell = chosenCell; //Step 2.1.4
            }
            else if (CellsStack.Count > 0) //Step 2.2
                CurrentCell = CellsStack.Pop(); //Step 2.2.1 and 2.2.2
            else
                IsDone = true;

            void RemoveWallBetween2Cells(MazeCell currentCell, MazeCell chosenCell)
            {
                if (currentCell.X - chosenCell.X == -2)
                    Cells[currentCell.Y, currentCell.X + 1].IsWall = false;
                else if (currentCell.X - chosenCell.X == 2)
                    Cells[currentCell.Y, currentCell.X - 1].IsWall = false;
                else if (currentCell.Y - chosenCell.Y == -2)
                    Cells[currentCell.Y + 1, currentCell.X].IsWall = false;
                else if (currentCell.Y - chosenCell.Y == 2)
                    Cells[currentCell.Y - 1, currentCell.X].IsWall = false;
            }
        }
    }
}