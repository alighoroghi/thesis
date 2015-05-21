namespace CPR
{
    partial class InputForm
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
            this.typesTabPage = new System.Windows.Forms.TabPage();
            this.EntertypesButton = new System.Windows.Forms.Button();
            this.InputTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.IterationCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.typeCounts = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.GameCounters = new System.Windows.Forms.NumericUpDown();
            this.Enter = new System.Windows.Forms.Button();
            this.TheNumberOfPlayers = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.typesTabPage.SuspendLayout();
            this.InputTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IterationCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameCounters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TheNumberOfPlayers)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // typesTabPage
            // 
            this.typesTabPage.AutoScroll = true;
            this.typesTabPage.Controls.Add(this.EntertypesButton);
            this.typesTabPage.Location = new System.Drawing.Point(4, 22);
            this.typesTabPage.Name = "typesTabPage";
            this.typesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.typesTabPage.Size = new System.Drawing.Size(349, 223);
            this.typesTabPage.TabIndex = 3;
            this.typesTabPage.Text = "types";
            this.typesTabPage.UseVisualStyleBackColor = true;
            // 
            // EntertypesButton
            // 
            this.EntertypesButton.Location = new System.Drawing.Point(8, 6);
            this.EntertypesButton.Name = "EntertypesButton";
            this.EntertypesButton.Size = new System.Drawing.Size(99, 56);
            this.EntertypesButton.TabIndex = 7;
            this.EntertypesButton.Text = "Enter type Values";
            this.EntertypesButton.UseVisualStyleBackColor = true;
            this.EntertypesButton.Click += new System.EventHandler(this.EntertypesButton_Click);
            // 
            // InputTab
            // 
            this.InputTab.Controls.Add(this.label4);
            this.InputTab.Controls.Add(this.IterationCountNumeric);
            this.InputTab.Controls.Add(this.typeCounts);
            this.InputTab.Controls.Add(this.label3);
            this.InputTab.Controls.Add(this.GameCounters);
            this.InputTab.Controls.Add(this.Enter);
            this.InputTab.Controls.Add(this.TheNumberOfPlayers);
            this.InputTab.Controls.Add(this.label2);
            this.InputTab.Controls.Add(this.label1);
            this.InputTab.Location = new System.Drawing.Point(4, 22);
            this.InputTab.Name = "InputTab";
            this.InputTab.Padding = new System.Windows.Forms.Padding(3);
            this.InputTab.Size = new System.Drawing.Size(349, 223);
            this.InputTab.TabIndex = 0;
            this.InputTab.Text = "Input";
            this.InputTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Iteration Counts\r\n";
            // 
            // IterationCountNumeric
            // 
            this.IterationCountNumeric.Location = new System.Drawing.Point(24, 66);
            this.IterationCountNumeric.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.IterationCountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IterationCountNumeric.Name = "IterationCountNumeric";
            this.IterationCountNumeric.Size = new System.Drawing.Size(37, 20);
            this.IterationCountNumeric.TabIndex = 11;
            this.IterationCountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // typeCounts
            // 
            this.typeCounts.Location = new System.Drawing.Point(24, 26);
            this.typeCounts.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.typeCounts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.typeCounts.Name = "typeCounts";
            this.typeCounts.Size = new System.Drawing.Size(37, 20);
            this.typeCounts.TabIndex = 9;
            this.typeCounts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of types for each player";
            // 
            // GameCounters
            // 
            this.GameCounters.Location = new System.Drawing.Point(24, 107);
            this.GameCounters.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.GameCounters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.GameCounters.Name = "GameCounters";
            this.GameCounters.Size = new System.Drawing.Size(37, 20);
            this.GameCounters.TabIndex = 0;
            this.GameCounters.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Enter
            // 
            this.Enter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Enter.Location = new System.Drawing.Point(3, 184);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(343, 36);
            this.Enter.TabIndex = 4;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // TheNumberOfPlayers
            // 
            this.TheNumberOfPlayers.Location = new System.Drawing.Point(24, 147);
            this.TheNumberOfPlayers.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TheNumberOfPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.TheNumberOfPlayers.Name = "TheNumberOfPlayers";
            this.TheNumberOfPlayers.Size = new System.Drawing.Size(37, 20);
            this.TheNumberOfPlayers.TabIndex = 1;
            this.TheNumberOfPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player Counts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Game Counts";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.InputTab);
            this.TabControl1.Controls.Add(this.typesTabPage);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(357, 249);
            this.TabControl1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(363, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 249);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 200);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(198, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(181, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 18);
            this.label12.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(181, 126);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 18);
            this.label11.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(181, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 18);
            this.label10.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(181, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 18);
            this.label9.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Total Iterations";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "CPR Counts:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "PR Counts:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Containing Fully Nashes:";
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 249);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(620, 287);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(620, 287);
            this.Name = "InputForm";
            this.Text = "InputForm";
            this.typesTabPage.ResumeLayout(false);
            this.InputTab.ResumeLayout(false);
            this.InputTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IterationCountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeCounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameCounters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TheNumberOfPlayers)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage typesTabPage;
        private System.Windows.Forms.Button EntertypesButton;
        private System.Windows.Forms.TabPage InputTab;
        private System.Windows.Forms.NumericUpDown typeCounts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown GameCounters;
        private System.Windows.Forms.Button Enter;
        private System.Windows.Forms.NumericUpDown TheNumberOfPlayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown IterationCountNumeric;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;

    }
}