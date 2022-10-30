namespace YonatanMankovich.MazeUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StartBTN = new System.Windows.Forms.Button();
            this.BG_Worker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusLBL = new System.Windows.Forms.LinkLabel();
            this.UpscalerNUD = new System.Windows.Forms.NumericUpDown();
            this.ColumnsNUD = new System.Windows.Forms.NumericUpDown();
            this.RowsNUD = new System.Windows.Forms.NumericUpDown();
            this.UpscaleCB = new System.Windows.Forms.CheckBox();
            this.SolveCB = new System.Windows.Forms.CheckBox();
            this.MakeCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.UpscalerNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rows";
            // 
            // StartBTN
            // 
            this.StartBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBTN.Location = new System.Drawing.Point(111, 29);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(162, 30);
            this.StartBTN.TabIndex = 11;
            this.StartBTN.Text = "Start";
            this.StartBTN.UseVisualStyleBackColor = true;
            this.StartBTN.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // BG_Worker
            // 
            this.BG_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BG_Worker_DoWork);
            this.BG_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BG_Worker_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Upscale";
            // 
            // StatusLBL
            // 
            this.StatusLBL.AutoSize = true;
            this.StatusLBL.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.StatusLBL.Location = new System.Drawing.Point(113, 63);
            this.StatusLBL.Name = "StatusLBL";
            this.StatusLBL.Size = new System.Drawing.Size(74, 13);
            this.StatusLBL.TabIndex = 18;
            this.StatusLBL.Text = "Status: Ready";
            this.StatusLBL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.StatusLBL_LinkClicked);
            // 
            // UpscalerNUD
            // 
            this.UpscalerNUD.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::YonatanMankovich.MazeUI.Properties.Settings.Default, "UpscaleFactor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UpscalerNUD.DecimalPlaces = 1;
            this.UpscalerNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.UpscalerNUD.Location = new System.Drawing.Point(56, 59);
            this.UpscalerNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.UpscalerNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpscalerNUD.Name = "UpscalerNUD";
            this.UpscalerNUD.Size = new System.Drawing.Size(51, 20);
            this.UpscalerNUD.TabIndex = 0;
            this.UpscalerNUD.Value = global::YonatanMankovich.MazeUI.Properties.Settings.Default.UpscaleFactor;
            // 
            // ColumnsNUD
            // 
            this.ColumnsNUD.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::YonatanMankovich.MazeUI.Properties.Settings.Default, "Columns", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ColumnsNUD.Location = new System.Drawing.Point(56, 7);
            this.ColumnsNUD.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.ColumnsNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ColumnsNUD.Name = "ColumnsNUD";
            this.ColumnsNUD.Size = new System.Drawing.Size(51, 20);
            this.ColumnsNUD.TabIndex = 1;
            this.ColumnsNUD.Value = global::YonatanMankovich.MazeUI.Properties.Settings.Default.Columns;
            // 
            // RowsNUD
            // 
            this.RowsNUD.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::YonatanMankovich.MazeUI.Properties.Settings.Default, "Rows", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RowsNUD.Location = new System.Drawing.Point(56, 33);
            this.RowsNUD.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.RowsNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RowsNUD.Name = "RowsNUD";
            this.RowsNUD.Size = new System.Drawing.Size(51, 20);
            this.RowsNUD.TabIndex = 1;
            this.RowsNUD.Value = global::YonatanMankovich.MazeUI.Properties.Settings.Default.Rows;
            // 
            // UpscaleCB
            // 
            this.UpscaleCB.AutoSize = true;
            this.UpscaleCB.Checked = global::YonatanMankovich.MazeUI.Properties.Settings.Default.UpscaleCB;
            this.UpscaleCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UpscaleCB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::YonatanMankovich.MazeUI.Properties.Settings.Default, "UpscaleCB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UpscaleCB.Location = new System.Drawing.Point(212, 9);
            this.UpscaleCB.Name = "UpscaleCB";
            this.UpscaleCB.Size = new System.Drawing.Size(65, 17);
            this.UpscaleCB.TabIndex = 13;
            this.UpscaleCB.Text = "Upscale";
            this.UpscaleCB.UseVisualStyleBackColor = true;
            // 
            // SolveCB
            // 
            this.SolveCB.AutoSize = true;
            this.SolveCB.Checked = global::YonatanMankovich.MazeUI.Properties.Settings.Default.SolveCB;
            this.SolveCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SolveCB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::YonatanMankovich.MazeUI.Properties.Settings.Default, "SolveCB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SolveCB.Location = new System.Drawing.Point(162, 9);
            this.SolveCB.Name = "SolveCB";
            this.SolveCB.Size = new System.Drawing.Size(53, 17);
            this.SolveCB.TabIndex = 10;
            this.SolveCB.Text = "Solve";
            this.SolveCB.UseVisualStyleBackColor = true;
            this.SolveCB.CheckedChanged += new System.EventHandler(this.SolveMazeCB_CheckedChanged);
            // 
            // MakeCB
            // 
            this.MakeCB.AutoSize = true;
            this.MakeCB.Checked = global::YonatanMankovich.MazeUI.Properties.Settings.Default.MakeCB;
            this.MakeCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MakeCB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::YonatanMankovich.MazeUI.Properties.Settings.Default, "MakeCB", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MakeCB.Location = new System.Drawing.Point(112, 9);
            this.MakeCB.Name = "MakeCB";
            this.MakeCB.Size = new System.Drawing.Size(53, 17);
            this.MakeCB.TabIndex = 9;
            this.MakeCB.Text = "Make";
            this.MakeCB.UseVisualStyleBackColor = true;
            this.MakeCB.CheckedChanged += new System.EventHandler(this.MakeMazeCB_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(283, 86);
            this.Controls.Add(this.StartBTN);
            this.Controls.Add(this.StatusLBL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UpscalerNUD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ColumnsNUD);
            this.Controls.Add(this.RowsNUD);
            this.Controls.Add(this.UpscaleCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SolveCB);
            this.Controls.Add(this.MakeCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Maze";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.UpscalerNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown ColumnsNUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RowsNUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox MakeCB;
        private System.Windows.Forms.CheckBox SolveCB;
        private System.Windows.Forms.Button StartBTN;
        private System.ComponentModel.BackgroundWorker BG_Worker;
        private System.Windows.Forms.NumericUpDown UpscalerNUD;
        private System.Windows.Forms.CheckBox UpscaleCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel StatusLBL;
    }
}

