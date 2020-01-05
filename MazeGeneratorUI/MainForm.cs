using System;
using System.Drawing;
using System.Windows.Forms;
using YonatanMankovich.MazeGeneratorCore;

namespace YonatanMankovich.MazeGeneratorUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        private void StartBTN_Click(object sender, EventArgs e)
        {
            BG_Worker.RunWorkerAsync();
            Cursor = Cursors.WaitCursor;
            MakeMazeCB.Enabled = SolveMazeCB.Enabled = StartBTN.Enabled = SolverGB.Enabled = MakerGB.Enabled = false;
        }

        private void BG_Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (MakeMazeCB.Checked)
            {
                MazeGenerator mazeGenerator = new MazeGenerator(new Size((int)ColumnsNUD.Value, (int)RowsNUD.Value));
                mazeGenerator.Make();
                mazeGenerator.SaveAsImage(MakeOutputPathTB.Text);
                mazeGenerator = null;
            }
            if (SolveMazeCB.Checked)
            {
                MazeSolver mazeSolver = new MazeSolver(SolveInputPathTB.Text);
                mazeSolver.Solve();
                mazeSolver.SaveSolutionAsImage(SolveOutputPathTB.Text);
                mazeSolver = null;
            }
            GC.Collect();
        }

        private void BG_Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MakeMazeCB.Enabled = SolveMazeCB.Enabled = StartBTN.Enabled = MakerGB.Enabled = SolverGB.Enabled = true;
            BothCheckBoxesChanged();
            Cursor = Cursors.Default;
        }
    }
}