using System;
using System.Collections.Generic;
using System.Drawing;

namespace YonatanMankovich.MazeGeneratorCore
{
    public class MazeGenerator : Maze
    {
        public MazeGenerator(Size size) : base(size)
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
}