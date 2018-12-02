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
            this.GenerateBTN = new System.Windows.Forms.Button();
            this.ColumnsNUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.RowsNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SavePathTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MakerGB = new System.Windows.Forms.GroupBox();
            this.SolverGB = new System.Windows.Forms.GroupBox();
            this.SolveBTN = new System.Windows.Forms.Button();
            this.SolveOutputPathTB = new System.Windows.Forms.TextBox();
            this.SolveInputPathTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNUD)).BeginInit();
            this.MakerGB.SuspendLayout();
            this.SolverGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenerateBTN
            // 
            this.GenerateBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateBTN.Location = new System.Drawing.Point(186, 16);
            this.GenerateBTN.Name = "GenerateBTN";
            this.GenerateBTN.Size = new System.Drawing.Size(106, 36);
            this.GenerateBTN.TabIndex = 2;
            this.GenerateBTN.Text = "Make and save";
            this.GenerateBTN.UseVisualStyleBackColor = true;
            this.GenerateBTN.Click += new System.EventHandler(this.GenerateBTN_Click);
            // 
            // ColumnsNUD
            // 
            this.ColumnsNUD.Location = new System.Drawing.Point(63, 32);
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
            this.label2.Location = new System.Drawing.Point(60, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns";
            // 
            // RowsNUD
            // 
            this.RowsNUD.Location = new System.Drawing.Point(6, 32);
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
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rows";
            // 
            // SavePathTB
            // 
            this.SavePathTB.Location = new System.Drawing.Point(120, 32);
            this.SavePathTB.Name = "SavePathTB";
            this.SavePathTB.Size = new System.Drawing.Size(61, 20);
            this.SavePathTB.TabIndex = 5;
            this.SavePathTB.Text = "maze.bmp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Output Path";
            // 
            // MakerGB
            // 
            this.MakerGB.Controls.Add(this.label2);
            this.MakerGB.Controls.Add(this.label1);
            this.MakerGB.Controls.Add(this.ColumnsNUD);
            this.MakerGB.Controls.Add(this.SavePathTB);
            this.MakerGB.Controls.Add(this.RowsNUD);
            this.MakerGB.Controls.Add(this.label3);
            this.MakerGB.Controls.Add(this.GenerateBTN);
            this.MakerGB.Location = new System.Drawing.Point(12, 12);
            this.MakerGB.Name = "MakerGB";
            this.MakerGB.Size = new System.Drawing.Size(298, 59);
            this.MakerGB.TabIndex = 7;
            this.MakerGB.TabStop = false;
            this.MakerGB.Text = "Maker";
            // 
            // SolverGB
            // 
            this.SolverGB.Controls.Add(this.SolveBTN);
            this.SolverGB.Controls.Add(this.SolveOutputPathTB);
            this.SolverGB.Controls.Add(this.SolveInputPathTB);
            this.SolverGB.Controls.Add(this.label5);
            this.SolverGB.Controls.Add(this.label4);
            this.SolverGB.Location = new System.Drawing.Point(12, 77);
            this.SolverGB.Name = "SolverGB";
            this.SolverGB.Size = new System.Drawing.Size(298, 59);
            this.SolverGB.TabIndex = 8;
            this.SolverGB.TabStop = false;
            this.SolverGB.Text = "Solver";
            // 
            // SolveBTN
            // 
            this.SolveBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SolveBTN.Location = new System.Drawing.Point(186, 15);
            this.SolveBTN.Name = "SolveBTN";
            this.SolveBTN.Size = new System.Drawing.Size(106, 36);
            this.SolveBTN.TabIndex = 9;
            this.SolveBTN.Text = "Solve and save";
            this.SolveBTN.UseVisualStyleBackColor = true;
            this.SolveBTN.Click += new System.EventHandler(this.SolveBTN_Click);
            // 
            // SolveOutputPathTB
            // 
            this.SolveOutputPathTB.Location = new System.Drawing.Point(96, 29);
            this.SolveOutputPathTB.Name = "SolveOutputPathTB";
            this.SolveOutputPathTB.Size = new System.Drawing.Size(85, 20);
            this.SolveOutputPathTB.TabIndex = 8;
            this.SolveOutputPathTB.Text = "solution.bmp";
            // 
            // SolveInputPathTB
            // 
            this.SolveInputPathTB.Location = new System.Drawing.Point(5, 29);
            this.SolveInputPathTB.Name = "SolveInputPathTB";
            this.SolveInputPathTB.Size = new System.Drawing.Size(85, 20);
            this.SolveInputPathTB.TabIndex = 7;
            this.SolveInputPathTB.Text = "maze.bmp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Output Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Input Path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 142);
            this.Controls.Add(this.SolverGB);
            this.Controls.Add(this.MakerGB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Maze Maker and Solver";
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNUD)).EndInit();
            this.MakerGB.ResumeLayout(false);
            this.MakerGB.PerformLayout();
            this.SolverGB.ResumeLayout(false);
            this.SolverGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button GenerateBTN;
        private System.Windows.Forms.NumericUpDown ColumnsNUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown RowsNUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SavePathTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox MakerGB;
        private System.Windows.Forms.GroupBox SolverGB;
        private System.Windows.Forms.TextBox SolveInputPathTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SolveBTN;
        private System.Windows.Forms.TextBox SolveOutputPathTB;
    }
}

