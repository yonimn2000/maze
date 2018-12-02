using System;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateBTN_Click(object sender, EventArgs e)
        {
            MakerGB.Enabled = false;
            SolverGB.Enabled = false;
            Maze.Maker maze;
            maze = new Maze.Maker((int)ColumnsNUD.Value, (int)RowsNUD.Value);
            maze.Make();
            maze.SaveAsImage(SavePathTB.Text);
            MakerGB.Enabled = true;
            SolverGB.Enabled = true;
        }

        private void SolveBTN_Click(object sender, EventArgs e)
        {
            MakerGB.Enabled = false;
            SolverGB.Enabled = false;
            Maze.Solver maze;
            maze = new Maze.Solver(SolveInputPathTB.Text);
            maze.Solve();
            maze.SaveSolutionAsImage(SolveOutputPathTB.Text);
            MakerGB.Enabled = true;
            SolverGB.Enabled = true;
        }
    }
}