using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using YonatanMankovich.MazeCore.Exceptions;

namespace YonatanMankovich.MazeCore
{
    public class MazeSolver : Maze
    {
        private string InputFile { get; }
        private List<Point> Path { get; } = new List<Point>();

        public MazeSolver(string inputFile) : base(GetImageSize(inputFile))
        {
            InputFile = inputFile;
            CreateMazeFromImage();
            CurrentCell = Cells[1, 1];
        }

        private void CreateMazeFromImage()
        {
            Bitmap image = new Bitmap(InputFile);

            for (ushort y = 0; y < image.Height; y++)
                for (ushort x = 0; x < image.Width; x++)
                {
                    Cells[y, x] = new MazeCell(x, y);

                    if (image.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0))
                        Cells[y, x].IsWall = true;
                }
        }

        private static Size GetImageSize(string inputFile)
        {
            Bitmap image = new Bitmap(inputFile);
            return new Size(image.Width, image.Height);
        }

        public void Solve()
        {
            Path.Add(new Point(1, 0));
            Cells[0, 1].IsVisited = true;

            while (!IsDone) //Step 2
                SolveStep();

            Path.Add(new Point(Size.Width - 2, Size.Width - 1));
        }

        public void SolveStep()
        {
            CurrentCell.IsVisited = true; //Step 2.1.4

            List<MazeCell> neighboringCells = GetUnvisitedNeighboringCellsList(CurrentCell, 1);

            if (neighboringCells.Count > 0) //Step 2.1
            {
                MazeCell chosenCell = neighboringCells[Random.Next(neighboringCells.Count)]; //Step 2.1.1

                CellStack.Push(CurrentCell); //Step 2.1.2
                CurrentCell = chosenCell; //Step 2.1.4
            }
            else if (CellStack.Count > 0) //Step 2.2
                CurrentCell = CellStack.Pop(); //Step 2.2.1 and 2.2.2
            else if (CellStack.Count == 0)
                throw new MazeUnsolvableException();

            if (CurrentCell.X == Size.Width - 2 && CurrentCell.Y == Size.Height - 2)
            {
                Path.Add(new Point(CurrentCell.X, CurrentCell.Y));

                foreach (MazeCell cell in CellStack)
                    Path.Add(new Point(cell.X, cell.Y));

                IsDone = true;
            }
        }

        public void SaveSolutionAsImage(string fileName, decimal scaleFactor = 1)
        {
            Bitmap image = new Bitmap(InputFile);
            Bitmap solutionImage = image.Clone(new Rectangle(0, 0, image.Width, image.Height), PixelFormat.Format24bppRgb);

            for (int i = 0; i < Path.Count; i++)
                solutionImage.SetPixel(Path[i].X, Path[i].Y, ColorFromHSV(360 * i / Path.Count, 1, 1));

            if (scaleFactor > 1)
                UpscaleBitmap(solutionImage, scaleFactor).Save(fileName);
            else
                solutionImage.Save(fileName);
        }

        private static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = (int)Math.Floor(hue / 60) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value *= 255;

            int v = (int)value;
            int p = (int)(value * (1 - saturation));
            int q = (int)(value * (1 - f * saturation));
            int t = (int)(value * (1 - (1 - f) * saturation));

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
}