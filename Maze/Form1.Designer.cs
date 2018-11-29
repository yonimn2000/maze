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
            this.components = new System.ComponentModel.Container();
            this.MazeBox = new System.Windows.Forms.PictureBox();
            this.FrameTimer = new System.Windows.Forms.Timer(this.components);
            this.FPS_NUD = new System.Windows.Forms.NumericUpDown();
            this.GenerateMazeBTN = new System.Windows.Forms.Button();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.WidthNUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.HeightNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SlowlyCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MazeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPS_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // MazeBox
            // 
            this.MazeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MazeBox.BackColor = System.Drawing.SystemColors.Control;
            this.MazeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MazeBox.Location = new System.Drawing.Point(129, 0);
            this.MazeBox.Name = "MazeBox";
            this.MazeBox.Size = new System.Drawing.Size(855, 461);
            this.MazeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MazeBox.TabIndex = 0;
            this.MazeBox.TabStop = false;
            // 
            // FrameTimer
            // 
            this.FrameTimer.Interval = 1000;
            this.FrameTimer.Tick += new System.EventHandler(this.FrameTimer_Tick);
            // 
            // FPS_NUD
            // 
            this.FPS_NUD.Location = new System.Drawing.Point(49, 33);
            this.FPS_NUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.FPS_NUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.FPS_NUD.Name = "FPS_NUD";
            this.FPS_NUD.Size = new System.Drawing.Size(74, 20);
            this.FPS_NUD.TabIndex = 1;
            this.FPS_NUD.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.FPS_NUD.ValueChanged += new System.EventHandler(this.FPS_NUD_ValueChanged);
            // 
            // GenerateMazeBTN
            // 
            this.GenerateMazeBTN.Location = new System.Drawing.Point(64, 7);
            this.GenerateMazeBTN.Name = "GenerateMazeBTN";
            this.GenerateMazeBTN.Size = new System.Drawing.Size(59, 23);
            this.GenerateMazeBTN.TabIndex = 2;
            this.GenerateMazeBTN.Text = "Generate";
            this.GenerateMazeBTN.UseVisualStyleBackColor = true;
            this.GenerateMazeBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // SaveBTN
            // 
            this.SaveBTN.Location = new System.Drawing.Point(8, 111);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(115, 23);
            this.SaveBTN.TabIndex = 3;
            this.SaveBTN.Text = "Save";
            this.SaveBTN.UseVisualStyleBackColor = true;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "FPS";
            // 
            // WidthNUD
            // 
            this.WidthNUD.Location = new System.Drawing.Point(49, 59);
            this.WidthNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.WidthNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthNUD.Name = "WidthNUD";
            this.WidthNUD.Size = new System.Drawing.Size(74, 20);
            this.WidthNUD.TabIndex = 1;
            this.WidthNUD.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthNUD.ValueChanged += new System.EventHandler(this.WidthNUD_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Width";
            // 
            // HeightNUD
            // 
            this.HeightNUD.Location = new System.Drawing.Point(49, 85);
            this.HeightNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HeightNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightNUD.Name = "HeightNUD";
            this.HeightNUD.Size = new System.Drawing.Size(74, 20);
            this.HeightNUD.TabIndex = 1;
            this.HeightNUD.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.HeightNUD.ValueChanged += new System.EventHandler(this.HeightNUD_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Height";
            // 
            // SlowlyCB
            // 
            this.SlowlyCB.AutoSize = true;
            this.SlowlyCB.Location = new System.Drawing.Point(12, 10);
            this.SlowlyCB.Name = "SlowlyCB";
            this.SlowlyCB.Size = new System.Drawing.Size(56, 17);
            this.SlowlyCB.TabIndex = 5;
            this.SlowlyCB.Text = "Slowly";
            this.SlowlyCB.UseVisualStyleBackColor = true;
            this.SlowlyCB.CheckedChanged += new System.EventHandler(this.SlowlyCB_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.GenerateMazeBTN);
            this.Controls.Add(this.HeightNUD);
            this.Controls.Add(this.WidthNUD);
            this.Controls.Add(this.FPS_NUD);
            this.Controls.Add(this.MazeBox);
            this.Controls.Add(this.SlowlyCB);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "Form1";
            this.Text = "Maze Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.MazeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FPS_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MazeBox;
        private System.Windows.Forms.Timer FrameTimer;
        private System.Windows.Forms.NumericUpDown FPS_NUD;
        private System.Windows.Forms.Button GenerateMazeBTN;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown WidthNUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown HeightNUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox SlowlyCB;
    }
}

