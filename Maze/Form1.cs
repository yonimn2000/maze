using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        Maze maze;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FPS_NUD_ValueChanged(sender, e);
        }

        private void FPS_NUD_ValueChanged(object sender, EventArgs e)
        {
            FrameTimer.Interval = (int)(1000 / FPS_NUD.Value);
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            if (!maze.IsDone)
                maze.Step();
            else
                FrameTimer.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MazeBox.Height >= HeightNUD.Value && MazeBox.Width >= WidthNUD.Value)
            {
                maze = new Maze((int)HeightNUD.Value, (int)WidthNUD.Value, 1, MazeBox.CreateGraphics());
            }
            else
            {
                maze = new Maze((int)HeightNUD.Value, (int)WidthNUD.Value, 1);
            }
            if (SlowlyCB.Checked)
                FrameTimer.Enabled = true;
            else
                maze.DrawAll();
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            maze.Save("maze.bmp");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            MazeBox.Width = Width - 145;
        }

        private void SlowlyCB_CheckedChanged(object sender, EventArgs e)
        {
            if (FrameTimer.Enabled)
                if (!maze.IsDone)
                {
                    FrameTimer.Enabled = false;
                    maze.DrawAll();
                }
        }

        private void WidthNUD_ValueChanged(object sender, EventArgs e)
        {
            MazeBox.Width = (int)WidthNUD.Value;
        }

        private void HeightNUD_ValueChanged(object sender, EventArgs e)
        {
            MazeBox.Height = (int)HeightNUD.Value;
        }
    }

    class Maze
    {
        Bitmap Bitmap;
        Graphics Graphics;
        Cell[] Cells;
        int Rows;
        int Columns;
        int PixelWidth;
        public bool IsDone;
        public Maze(int hieght, int width, int pixelWidth, Graphics graphics = null)
        {
            PixelWidth = pixelWidth;
            IsDone = false;
            Rows = hieght / pixelWidth;
            Columns = width / pixelWidth; ;
            if (Columns % 2 == 0)
                Columns--;
            if (Rows % 2 == 0)
                Rows--;
            Cells = new Cell[Rows * Columns];
            Bitmap = new Bitmap(Columns, Rows);
            Graphics = graphics != null ? graphics : Graphics.FromImage(Bitmap);
            for (int y = 0; y < Rows; y++)
                for (int x = 0; x < Columns; x++)
                {
                    Cells[Index(x, y)] = new Cell(x, y);
                    if (y == 0 || y == Rows - 1 || x == 0 || x == Columns - 1 || x % 2 == 0 || y % 2 == 0)
                        Cells[Index(x, y)].IsWall = true;
                }
        }

        private int Index(int x, int y)
        {
            if (y < 0 || x < 0 || x > Columns - 1 || y > Rows - 1)
                return -1;
            return x + y * Columns;
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
                for (int x = 0; x < Columns; x++)
                    Graphics.FillRectangle(new SolidBrush(Cells[Index(x, y)].IsWall ? Color.Black : Color.White), x * PixelWidth, y * PixelWidth, PixelWidth, PixelWidth);
        }

        public void DrawAll()
        {
            while (!IsDone) //Step 2
                Step();
        }

        Cell currentCell;
        public int stepsCount = 0;
        Stack<Cell> cellsStack = new Stack<Cell>();
        Random Random = new Random();
        public void Step()
        {
            if (stepsCount == 0)
            {
                Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, Columns * PixelWidth, Rows * PixelWidth);
                currentCell = Cells[Index(1, 1)]; //Step 1
            }
            currentCell.IsVisited = true; //Step 2.1.4
            currentCell.Draw(Color.White, PixelWidth, Graphics);
            List<Cell> neighboringCells = GetUnvisitedNeighboringCells(currentCell);
            if (neighboringCells.Count > 0) //Step 2.1
            {
                Cell chosenCell = neighboringCells[Random.Next(neighboringCells.Count)]; //Step 2.1.1
                cellsStack.Push(currentCell); //Step 2.1.2
                RemoveWall(currentCell, chosenCell); //Step 2.1.3
                currentCell = chosenCell; //Step 2.1.4
            }
            else if (cellsStack.Count > 0) //Step 2.2
                currentCell = cellsStack.Pop(); //Step 2.2.1 and 2.2.2
            else
                IsDone = true;
            stepsCount++;
            if (IsDone)
            {
                Cells[Index(1, 0)].IsWall = false; //Start cell
                Cells[Index(Columns - 2, Rows - 1)].IsWall = false; //End cell
            }
        }

        private void RemoveWall(Cell currentCell, Cell chosenCell)
        {
            int index = 0;
            if (currentCell.X - chosenCell.X == -2)
                index = Index(currentCell.X + 1, currentCell.Y);
            else if (currentCell.X - chosenCell.X == 2)
                index = Index(currentCell.X - 1, currentCell.Y);
            else if (currentCell.Y - chosenCell.Y == -2)
                index = Index(currentCell.X, currentCell.Y + 1);
            else if (currentCell.Y - chosenCell.Y == 2)
                index = Index(currentCell.X, currentCell.Y - 1);
            Cells[index].IsWall = false;
            Cells[index].Draw(Color.White, PixelWidth, Graphics);
            //Graphics.FillRectangle(new SolidBrush(Color.White), Cells[index].X * PixelWidth, Cells[index].Y * PixelWidth, PixelWidth, PixelWidth);
        }

        private List<Cell> GetUnvisitedNeighboringCells(Cell currentCell)
        {
            List<Cell> neighboringCells = new List<Cell>();
            AddNeighboringCells(neighboringCells, Index(currentCell.X + 2, currentCell.Y));
            AddNeighboringCells(neighboringCells, Index(currentCell.X - 2, currentCell.Y));
            AddNeighboringCells(neighboringCells, Index(currentCell.X, currentCell.Y + 2));
            AddNeighboringCells(neighboringCells, Index(currentCell.X, currentCell.Y - 2));
            return neighboringCells;
        }

        private void AddNeighboringCells(List<Cell> neighboringCells, int index)
        {
            if (index > 0)
            {
                Cell cell = Cells[index];
                if (!cell.IsVisited)
                    neighboringCells.Add(cell);
            }
        }

        public void Save(string fileName)
        {
            for (int y = 0; y < Rows; y++)
                for (int x = 0; x < Columns; x++)
                    Bitmap.SetPixel(x, y, Cells[Index(x, y)].IsWall ? Color.Black : Color.White);
            Bitmap.Save(fileName);
            MessageBox.Show("Saved to " + Application.ExecutablePath);
        }
    }

    class Cell
    {
        public int X;
        public int Y;
        public bool IsVisited;
        public bool IsWall;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            IsVisited = false;
            IsWall = false;
        }

        public void Draw(Color color, int width, Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.White), X * width, Y * width, width, width);
        }

        public override string ToString()
        {
            return $"({X}, {Y}), {(IsVisited ? "" : "Not ")}Visited, {(IsWall ? "" : "Not ")}Wall";
        }
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
