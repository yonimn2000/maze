using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace YonatanMankovich.MazeGeneratorCore
{
    public class MazeSolver : Maze
    {
        public MazeSolver(string filePath) : base(filePath)
        {
            CurrentCell = Cells[CellCoordinate(1, 1)];
            Cells[CellCoordinate(1, 0)].IsVisited = true;
            Cells[CellCoordinate(1, 0)].IsSolution = true;
            Cells[CellCoordinate(Size.Width - 2, Size.Height - 1)].IsSolution = true;
            Bitmap.SetPixel(1, 0, Color.Red);
            Bitmap.SetPixel(Size.Width - 2, Size.Height - 1, Color.Red);
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
            if (Cells[CellCoordinate(Size.Width - 2, Size.Height - 2)].IsSolution)
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