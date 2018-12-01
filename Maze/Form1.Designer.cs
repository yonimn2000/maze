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
            this.GenerateBTN = new System.Windows.Forms.Button();
            this.ColumnsNUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.RowsNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SavePathTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SolveBTN = new System.Windows.Forms.Button();
            this.SolveOutputPathTB = new System.Windows.Forms.TextBox();
            this.SolveInputPathTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenerateBTN
            // 
            this.GenerateBTN.Location = new System.Drawing.Point(9, 114);
            this.GenerateBTN.Name = "GenerateBTN";
            this.GenerateBTN.Size = new System.Drawing.Size(132, 23);
            this.GenerateBTN.TabIndex = 2;
            this.GenerateBTN.Text = "Generate and save";
            this.GenerateBTN.UseVisualStyleBackColor = true;
            this.GenerateBTN.Click += new System.EventHandler(this.GenerateBTN_Click);
            // 
            // ColumnsNUD
            // 
            this.ColumnsNUD.Location = new System.Drawing.Point(59, 14);
            this.ColumnsNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ColumnsNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ColumnsNUD.Name = "ColumnsNUD";
            this.ColumnsNUD.Size = new System.Drawing.Size(82, 20);
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
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Columns";
            // 
            // RowsNUD
            // 
            this.RowsNUD.Location = new System.Drawing.Point(59, 39);
            this.RowsNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.RowsNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RowsNUD.Name = "RowsNUD";
            this.RowsNUD.Size = new System.Drawing.Size(82, 20);
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
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rows";
            // 
            // SavePathTB
            // 
            this.SavePathTB.Location = new System.Drawing.Point(6, 85);
            this.SavePathTB.Name = "SavePathTB";
            this.SavePathTB.Size = new System.Drawing.Size(135, 20);
            this.SavePathTB.TabIndex = 5;
            this.SavePathTB.Text = "maze.bmp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Output Path";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ColumnsNUD);
            this.groupBox1.Controls.Add(this.SavePathTB);
            this.groupBox1.Controls.Add(this.RowsNUD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.GenerateBTN);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 146);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maker";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SolveBTN);
            this.groupBox2.Controls.Add(this.SolveOutputPathTB);
            this.groupBox2.Controls.Add(this.SolveInputPathTB);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(169, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 145);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Solver";
            // 
            // SolveBTN
            // 
            this.SolveBTN.Location = new System.Drawing.Point(6, 68);
            this.SolveBTN.Name = "SolveBTN";
            this.SolveBTN.Size = new System.Drawing.Size(162, 23);
            this.SolveBTN.TabIndex = 9;
            this.SolveBTN.Text = "Solve and save";
            this.SolveBTN.UseVisualStyleBackColor = true;
            this.SolveBTN.Click += new System.EventHandler(this.SolveBTN_Click);
            // 
            // SolveOutputPathTB
            // 
            this.SolveOutputPathTB.Location = new System.Drawing.Point(68, 40);
            this.SolveOutputPathTB.Name = "SolveOutputPathTB";
            this.SolveOutputPathTB.Size = new System.Drawing.Size(100, 20);
            this.SolveOutputPathTB.TabIndex = 8;
            this.SolveOutputPathTB.Text = "solution.bmp";
            // 
            // SolveInputPathTB
            // 
            this.SolveInputPathTB.Location = new System.Drawing.Point(68, 13);
            this.SolveInputPathTB.Name = "SolveInputPathTB";
            this.SolveInputPathTB.Size = new System.Drawing.Size(100, 20);
            this.SolveInputPathTB.TabIndex = 7;
            this.SolveInputPathTB.Text = "maze.bmp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Output Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Input Path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 168);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Maze Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox SolveInputPathTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SolveBTN;
        private System.Windows.Forms.TextBox SolveOutputPathTB;
    }
}

