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
            StatusLBL.LinkArea = new LinkArea();
            BG_Worker.RunWorkerAsync();
            Cursor = Cursors.WaitCursor;
            MakeCB.Enabled = SolveCB.Enabled = UpscaleCB.Enabled = StartBTN.Enabled = false;
        }

        private void BG_Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                SetStatusText("Started...");
                Directory.CreateDirectory(OutputFolderPath);

                if (MakeCB.Checked)
                {
                    SetStatusText("Initializing maze generator...");
                    MazeGenerator mazeGenerator = new MazeGenerator(new Size((int)ColumnsNUD.Value, (int)RowsNUD.Value));
                    SetStatusText("Generating maze...");
                    mazeGenerator.Generate();
                    SetStatusText("Saving generated maze...");
                    mazeGenerator.SaveAsImage(MazePath);

                    if (UpscaleCB.Checked)
                    {
                        SetStatusText("Upscaling generated maze...");
                        mazeGenerator.SaveAsImage(UpscaleMazePath, UpscalerNUD.Value);
                    }

                    mazeGenerator = null;
                }

                if (SolveCB.Checked)
                {
                    if (File.Exists(MazePath))
                    {
                        SetStatusText("Initializing maze solver...");
                        MazeSolver mazeSolver = new MazeSolver(MazePath);
                        SetStatusText("Solving maze...");
                        mazeSolver.Solve();
                        SetStatusText("Saving solved maze...");
                        mazeSolver.SaveSolutionAsImage(SolutionPath);

                        if (UpscaleCB.Checked)
                        {
                            SetStatusText("Upscaling solved maze...");
                            mazeSolver.SaveSolutionAsImage(UpscaleSolutionPath, UpscalerNUD.Value);
                        }
                        mazeSolver = null;
                    }
                    else
                        throw new MazeException("Maze file was not found...");
                }

                StatusLBL.Invoke(new Action(() =>
                {
                    string linkText = "View results here";
                    StatusLBL.Text = "Done! " + linkText;
                    StatusLBL.LinkArea = new LinkArea(StatusLBL.Text.IndexOf(linkText), linkText.Length);
                }));

                GC.Collect();
            }
            catch (MazeException ex)
            {
                MessageBox.Show(ex.Message);
                SetStatusText("Status: Ready");
            }
        }

        private void SetStatusText(string text) => StatusLBL.Invoke(new Action(() => { StatusLBL.Text = text; }));

        private void BG_Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MakeCB.Enabled = SolveCB.Enabled = UpscaleCB.Enabled = StartBTN.Enabled = true;
            BothCheckBoxesChanged();
            Cursor = Cursors.Default;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }

        private void StatusLBL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(OutputFolderPath);
        }
    }
}