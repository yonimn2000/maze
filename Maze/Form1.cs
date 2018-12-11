using System;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BothCheckBoxesChanged();
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            MakerGB.Enabled = false;
            SolverGB.Enabled = false;
            if (MakeMazeCB.Checked)
            {
                Maze.Maker mazeMaker;
                mazeMaker = new Maze.Maker((int)ColumnsNUD.Value, (int)RowsNUD.Value);
                mazeMaker.Make();
                mazeMaker.SaveAsImage(MakeOutputPathTB.Text, !SolveMazeCB.Checked);
            }
            if (SolveMazeCB.Checked)
            {
                Maze.Solver mazeSolver;
                mazeSolver = new Maze.Solver(MakeOutputPathTB.Text);
                mazeSolver.Solve();
                mazeSolver.SaveSolutionAsImage(SolveOutputPathTB.Text, true);
            }
            MakerGB.Enabled = true;
            SolverGB.Enabled = true;
            BothCheckBoxesChanged();
        }

        private void MakeMazeCB_CheckedChanged(object sender, EventArgs e)
        {
            BothCheckBoxesChanged();
        }

        private void SolveMazeCB_CheckedChanged(object sender, EventArgs e)
        {
            BothCheckBoxesChanged();
        }

        private void BothCheckBoxesChanged()
        {
            MakerGB.Enabled = MakeMazeCB.Checked;
            SolverGB.Enabled = SolveMazeCB.Checked;
            SolverInputPathLBL.Enabled = SolveInputPathTB.Enabled = !(MakeMazeCB.Checked && SolveMazeCB.Checked);
            StartBTN.Enabled = !(!MakeMazeCB.Checked && !SolveMazeCB.Checked);
        }
    }
}