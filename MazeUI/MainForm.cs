using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YonatanMankovich.MazeCore;
using YonatanMankovich.MazeCore.Exceptions;
using YonatanMankovich.MazeUI.Properties;

namespace YonatanMankovich.MazeUI
{
    public partial class MainForm : Form
    {
        private static readonly string OutputFolderPath = Directory.GetCurrentDirectory() + "\\Output\\";
        private static readonly string MazePath = OutputFolderPath + "Maze.bmp";
        private static readonly string SolutionPath = OutputFolderPath + "Solution.bmp";
        private static readonly string UpscaleMazePath = OutputFolderPath + "MazeUpscaled.bmp";
        private static readonly string UpscaleSolutionPath = OutputFolderPath + "SolutionUpscaled.bmp";

        public MainForm()
        {
            InitializeComponent();
            UpscalerNUD.DecimalPlaces = 1;
            UpscalerNUD.Increment = 0.1M;
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
            StartBTN.Enabled = MakeCB.Checked || SolveCB.Checked;
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            // Keep dimensions odd.
            ColumnsNUD.Value -= (ColumnsNUD.Value % 2 == 0 ? 1 : 0);
            RowsNUD.Value -= (RowsNUD.Value % 2 == 0 ? 1 : 0);
            BG_Worker.RunWorkerAsync();
            Cursor = Cursors.WaitCursor;
            MakeCB.Enabled = SolveCB.Enabled = UpscaleCB.Enabled = OpenCB.Enabled = StartBTN.Enabled = false;
        }

        private void BG_Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Directory.CreateDirectory(OutputFolderPath);

                if (MakeCB.Checked)
                {
                    MazeGenerator mazeGenerator = new MazeGenerator(new Size((int)ColumnsNUD.Value, (int)RowsNUD.Value));
                    mazeGenerator.Generate();
                    mazeGenerator.SaveAsImage(MazePath);

                    if (UpscaleCB.Checked)
                        mazeGenerator.SaveAsImage(UpscaleMazePath, UpscalerNUD.Value);

                    mazeGenerator = null;
                }

                if (SolveCB.Checked)
                {
                    MazeSolver mazeSolver = new MazeSolver(MazePath);
                    mazeSolver.Solve();
                    mazeSolver.SaveSolutionAsImage(SolutionPath);

                    if (UpscaleCB.Checked)
                        mazeSolver.SaveSolutionAsImage(UpscaleSolutionPath, UpscalerNUD.Value);

                    mazeSolver = null;
                }

                if (OpenCB.Checked)
                    Process.Start(OutputFolderPath);

                GC.Collect();
            }
            catch (MazeException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void BG_Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MakeCB.Enabled = SolveCB.Enabled = UpscaleCB.Enabled = OpenCB.Enabled = StartBTN.Enabled = true;
            BothCheckBoxesChanged();
            Cursor = Cursors.Default;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}