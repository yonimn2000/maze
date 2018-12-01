using System;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        Maze.Maker maze;
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
                maze.MakeStep();
            else
                FrameTimer.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int width = Math.Min((Width - 145) / (int)WidthNUD.Value, (Height - 40) / (int)HeightNUD.Value);
            maze = new Maze.Maker((int)WidthNUD.Value, (int)HeightNUD.Value);
            if (SlowlyCB.Checked)
                FrameTimer.Enabled = true;
            else
                maze.Make();
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            maze.SaveAsImage("maze.bmp");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            MazeBox.Width = Width - 145;
            MazeBox.Height = Height - 40;
            HeightNUD.Maximum = MazeBox.Height;
            WidthNUD.Maximum = MazeBox.Width;
            HeightNUD.Value = MazeBox.Height;
            WidthNUD.Value = MazeBox.Width;
        }

        private void SlowlyCB_CheckedChanged(object sender, EventArgs e)
        {
            FPS_NUD.Enabled = SlowlyCB.Checked;
            if (FrameTimer.Enabled)
                if (!maze.IsDone)
                {
                    FrameTimer.Enabled = false;
                    maze.Make();
                }
        }
    }
}