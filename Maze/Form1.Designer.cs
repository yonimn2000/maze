namespace Maze
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ColumnsNUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.RowsNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.MakeOutputPathTB = new System.Windows.Forms.TextBox();
            this.MakerOutputPathLBL = new System.Windows.Forms.Label();
            this.MakerGB = new System.Windows.Forms.GroupBox();
            this.SolverGB = new System.Windows.Forms.GroupBox();
            this.SolveOutputPathTB = new System.Windows.Forms.TextBox();
            this.SolveInputPathTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SolverInputPathLBL = new System.Windows.Forms.Label();
            this.MakeMazeCB = new System.Windows.Forms.CheckBox();
            this.SolveMazeCB = new System.Windows.Forms.CheckBox();
            this.StartBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNUD)).BeginInit();
            this.MakerGB.SuspendLayout();
            this.SolverGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColumnsNUD
            // 
            this.ColumnsNUD.Location = new System.Drawing.Point(6, 33);
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
            this.ColumnsNUD.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns";
            // 
            // RowsNUD
            // 
            this.RowsNUD.Location = new System.Drawing.Point(63, 33);
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
            this.RowsNUD.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rows";
            // 
            // MakeOutputPathTB
            // 
            this.MakeOutputPathTB.Location = new System.Drawing.Point(120, 33);
            this.MakeOutputPathTB.Name = "MakeOutputPathTB";
            this.MakeOutputPathTB.Size = new System.Drawing.Size(62, 20);
            this.MakeOutputPathTB.TabIndex = 5;
            this.MakeOutputPathTB.Text = "maze.bmp";
            // 
            // MakerOutputPathLBL
            // 
            this.MakerOutputPathLBL.AutoSize = true;
            this.MakerOutputPathLBL.Location = new System.Drawing.Point(117, 17);
            this.MakerOutputPathLBL.Name = "MakerOutputPathLBL";
            this.MakerOutputPathLBL.Size = new System.Drawing.Size(64, 13);
            this.MakerOutputPathLBL.TabIndex = 6;
            this.MakerOutputPathLBL.Text = "Output Path";
            // 
            // MakerGB
            // 
            this.MakerGB.Controls.Add(this.label2);
            this.MakerGB.Controls.Add(this.MakerOutputPathLBL);
            this.MakerGB.Controls.Add(this.ColumnsNUD);
            this.MakerGB.Controls.Add(this.MakeOutputPathTB);
            this.MakerGB.Controls.Add(this.RowsNUD);
            this.MakerGB.Controls.Add(this.label3);
            this.MakerGB.Location = new System.Drawing.Point(12, 12);
            this.MakerGB.Name = "MakerGB";
            this.MakerGB.Size = new System.Drawing.Size(188, 59);
            this.MakerGB.TabIndex = 7;
            this.MakerGB.TabStop = false;
            this.MakerGB.Text = "Maker";
            // 
            // SolverGB
            // 
            this.SolverGB.Controls.Add(this.SolveOutputPathTB);
            this.SolverGB.Controls.Add(this.SolveInputPathTB);
            this.SolverGB.Controls.Add(this.label5);
            this.SolverGB.Controls.Add(this.SolverInputPathLBL);
            this.SolverGB.Location = new System.Drawing.Point(12, 77);
            this.SolverGB.Name = "SolverGB";
            this.SolverGB.Size = new System.Drawing.Size(188, 59);
            this.SolverGB.TabIndex = 8;
            this.SolverGB.TabStop = false;
            this.SolverGB.Text = "Solver";
            // 
            // SolveOutputPathTB
            // 
            this.SolveOutputPathTB.Location = new System.Drawing.Point(99, 33);
            this.SolveOutputPathTB.Name = "SolveOutputPathTB";
            this.SolveOutputPathTB.Size = new System.Drawing.Size(87, 20);
            this.SolveOutputPathTB.TabIndex = 8;
            this.SolveOutputPathTB.Text = "solution.bmp";
            // 
            // SolveInputPathTB
            // 
            this.SolveInputPathTB.Location = new System.Drawing.Point(6, 33);
            this.SolveInputPathTB.Name = "SolveInputPathTB";
            this.SolveInputPathTB.Size = new System.Drawing.Size(87, 20);
            this.SolveInputPathTB.TabIndex = 7;
            this.SolveInputPathTB.Text = "maze.bmp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Output Path";
            // 
            // SolverInputPathLBL
            // 
            this.SolverInputPathLBL.AutoSize = true;
            this.SolverInputPathLBL.Location = new System.Drawing.Point(3, 17);
            this.SolverInputPathLBL.Name = "SolverInputPathLBL";
            this.SolverInputPathLBL.Size = new System.Drawing.Size(56, 13);
            this.SolverInputPathLBL.TabIndex = 6;
            this.SolverInputPathLBL.Text = "Input Path";
            // 
            // MakeMazeCB
            // 
            this.MakeMazeCB.AutoSize = true;
            this.MakeMazeCB.Checked = true;
            this.MakeMazeCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MakeMazeCB.Location = new System.Drawing.Point(12, 142);
            this.MakeMazeCB.Name = "MakeMazeCB";
            this.MakeMazeCB.Size = new System.Drawing.Size(53, 17);
            this.MakeMazeCB.TabIndex = 9;
            this.MakeMazeCB.Text = "Make";
            this.MakeMazeCB.UseVisualStyleBackColor = true;
            this.MakeMazeCB.CheckedChanged += new System.EventHandler(this.MakeMazeCB_CheckedChanged);
            // 
            // SolveMazeCB
            // 
            this.SolveMazeCB.AutoSize = true;
            this.SolveMazeCB.Checked = true;
            this.SolveMazeCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SolveMazeCB.Location = new System.Drawing.Point(12, 165);
            this.SolveMazeCB.Name = "SolveMazeCB";
            this.SolveMazeCB.Size = new System.Drawing.Size(53, 17);
            this.SolveMazeCB.TabIndex = 10;
            this.SolveMazeCB.Text = "Solve";
            this.SolveMazeCB.UseVisualStyleBackColor = true;
            this.SolveMazeCB.CheckedChanged += new System.EventHandler(this.SolveMazeCB_CheckedChanged);
            // 
            // StartBTN
            // 
            this.StartBTN.Location = new System.Drawing.Point(63, 142);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(137, 40);
            this.StartBTN.TabIndex = 11;
            this.StartBTN.Text = "Start";
            this.StartBTN.UseVisualStyleBackColor = true;
            this.StartBTN.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 190);
            this.Controls.Add(this.StartBTN);
            this.Controls.Add(this.SolveMazeCB);
            this.Controls.Add(this.MakeMazeCB);
            this.Controls.Add(this.SolverGB);
            this.Controls.Add(this.MakerGB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Maze";
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNUD)).EndInit();
            this.MakerGB.ResumeLayout(false);
            this.MakerGB.PerformLayout();
            this.SolverGB.ResumeLayout(false);
            this.SolverGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown ColumnsNUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RowsNUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MakeOutputPathTB;
        private System.Windows.Forms.Label MakerOutputPathLBL;
        private System.Windows.Forms.GroupBox MakerGB;
        private System.Windows.Forms.GroupBox SolverGB;
        private System.Windows.Forms.TextBox SolveInputPathTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SolverInputPathLBL;
        private System.Windows.Forms.TextBox SolveOutputPathTB;
        private System.Windows.Forms.CheckBox MakeMazeCB;
        private System.Windows.Forms.CheckBox SolveMazeCB;
        private System.Windows.Forms.Button StartBTN;
    }
}

