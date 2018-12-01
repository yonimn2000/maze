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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GenerateBTN_Click(object sender, EventArgs e)
        {
            Maze.Maker maze;
            maze = new Maze.Maker((int)ColumnsNUD.Value, (int)RowsNUD.Value);
            maze.Make();
            maze.SaveAsImage(SavePathTB.Text);
        }

        private void SolveBTN_Click(object sender, EventArgs e)
        {
            Maze.Solver maze;
            maze = new Maze.Solver(SolveInputPathTB.Text);
            maze.Solve();
            maze.SaveSolutionAsImage(SolveOutputPathTB.Text);
        }
    }
}