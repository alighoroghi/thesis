namespace CPR
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
            this.GameCounters = new System.Windows.Forms.NumericUpDown();
            this.PlayerCounters = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Enter = new System.Windows.Forms.Button();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.InputTab = new System.Windows.Forms.TabPage();
            this.EachPlayertypeCount = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Strategy = new System.Windows.Forms.TabPage();
            this.GetStrategies = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TheNumberOfPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BenefitTab = new System.Windows.Forms.TabPage();
            this.EnterPayOFFs = new System.Windows.Forms.Button();
            this.typesTabPage = new System.Windows.Forms.TabPage();
            this.EntertypesButton = new System.Windows.Forms.Button();
            this.Compute_Nash = new System.Windows.Forms.Button();
            this.CPRCHeck = new System.Windows.Forms.Button();
            this.PRCHeck = new System.Windows.Forms.Button();
            this.ShowAllExtremeNashes = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameCounters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCounters)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.InputTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.Strategy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.BenefitTab.SuspendLayout();
            this.typesTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameCounters
            // 
            this.GameCounters.Location = new System.Drawing.Point(33, 107);
            this.GameCounters.Maximum = new decimal(new int[] {
            10,
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
            // PlayerCounters
            // 
            this.PlayerCounters.Location = new System.Drawing.Point(33, 148);
            this.PlayerCounters.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PlayerCounters.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PlayerCounters.Name = "PlayerCounters";
            this.PlayerCounters.Size = new System.Drawing.Size(37, 20);
            this.PlayerCounters.TabIndex = 1;
            this.PlayerCounters.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Game Counts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Player Counts";
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(33, 174);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(75, 56);
            this.Enter.TabIndex = 4;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.InputTab);
            this.TabControl1.Controls.Add(this.Strategy);
            this.TabControl1.Controls.Add(this.BenefitTab);
            this.TabControl1.Controls.Add(this.typesTabPage);
            this.TabControl1.Location = new System.Drawing.Point(12, 12);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(652, 532);
            this.TabControl1.TabIndex = 5;
            // 
            // InputTab
            // 
            this.InputTab.Controls.Add(this.EachPlayertypeCount);
            this.InputTab.Controls.Add(this.numericUpDown1);
            this.InputTab.Controls.Add(this.label3);
            this.InputTab.Controls.Add(this.GameCounters);
            this.InputTab.Controls.Add(this.Enter);
            this.InputTab.Controls.Add(this.PlayerCounters);
            this.InputTab.Controls.Add(this.label2);
            this.InputTab.Controls.Add(this.label1);
            this.InputTab.Location = new System.Drawing.Point(4, 22);
            this.InputTab.Name = "InputTab";
            this.InputTab.Padding = new System.Windows.Forms.Padding(3);
            this.InputTab.Size = new System.Drawing.Size(644, 506);
            this.InputTab.TabIndex = 0;
            this.InputTab.Text = "Input";
            this.InputTab.UseVisualStyleBackColor = true;
            // 
            // EachPlayertypeCount
            // 
            this.EachPlayertypeCount.Location = new System.Drawing.Point(33, 14);
            this.EachPlayertypeCount.Name = "EachPlayertypeCount";
            this.EachPlayertypeCount.Size = new System.Drawing.Size(108, 65);
            this.EachPlayertypeCount.TabIndex = 11;
            this.EachPlayertypeCount.Text = "Enter Each Player type Counts";
            this.EachPlayertypeCount.UseVisualStyleBackColor = true;
            this.EachPlayertypeCount.Click += new System.EventHandler(this.EachPlayertypeCount_Click_1);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(147, 38);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(37, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of types for each player";
            // 
            // Strategy
            // 
            this.Strategy.Controls.Add(this.GetStrategies);
            this.Strategy.Controls.Add(this.dataGridView1);
            this.Strategy.Location = new System.Drawing.Point(4, 22);
            this.Strategy.Name = "Strategy";
            this.Strategy.Padding = new System.Windows.Forms.Padding(3);
            this.Strategy.Size = new System.Drawing.Size(644, 506);
            this.Strategy.TabIndex = 1;
            this.Strategy.Text = "Strategies";
            this.Strategy.UseVisualStyleBackColor = true;
            // 
            // GetStrategies
            // 
            this.GetStrategies.Location = new System.Drawing.Point(232, 6);
            this.GetStrategies.Name = "GetStrategies";
            this.GetStrategies.Size = new System.Drawing.Size(139, 56);
            this.GetStrategies.TabIndex = 5;
            this.GetStrategies.Text = "Enter Strategy Counts for each player";
            this.GetStrategies.UseVisualStyleBackColor = true;
            this.GetStrategies.Click += new System.EventHandler(this.GetStrategies_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TheNumberOfPlayers,
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(220, 144);
            this.dataGridView1.TabIndex = 0;
            // 
            // TheNumberOfPlayers
            // 
            this.TheNumberOfPlayers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TheNumberOfPlayers.HeaderText = "Player ";
            this.TheNumberOfPlayers.Name = "TheNumberOfPlayers";
            this.TheNumberOfPlayers.ReadOnly = true;
            this.TheNumberOfPlayers.Width = 64;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Strategy Counts";
            this.Column1.Name = "Column1";
            this.Column1.Width = 107;
            // 
            // BenefitTab
            // 
            this.BenefitTab.AutoScroll = true;
            this.BenefitTab.Controls.Add(this.EnterPayOFFs);
            this.BenefitTab.Location = new System.Drawing.Point(4, 22);
            this.BenefitTab.Name = "BenefitTab";
            this.BenefitTab.Padding = new System.Windows.Forms.Padding(3);
            this.BenefitTab.Size = new System.Drawing.Size(644, 506);
            this.BenefitTab.TabIndex = 2;
            this.BenefitTab.Text = "PayOffs";
            this.BenefitTab.UseVisualStyleBackColor = true;
            // 
            // EnterPayOFFs
            // 
            this.EnterPayOFFs.Location = new System.Drawing.Point(6, 6);
            this.EnterPayOFFs.Name = "EnterPayOFFs";
            this.EnterPayOFFs.Size = new System.Drawing.Size(83, 56);
            this.EnterPayOFFs.TabIndex = 6;
            this.EnterPayOFFs.Text = "Enter Payoffs";
            this.EnterPayOFFs.UseVisualStyleBackColor = true;
            this.EnterPayOFFs.Click += new System.EventHandler(this.EnterPayOFFs_Click);
            // 
            // typesTabPage
            // 
            this.typesTabPage.AutoScroll = true;
            this.typesTabPage.Controls.Add(this.EntertypesButton);
            this.typesTabPage.Location = new System.Drawing.Point(4, 22);
            this.typesTabPage.Name = "typesTabPage";
            this.typesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.typesTabPage.Size = new System.Drawing.Size(644, 506);
            this.typesTabPage.TabIndex = 3;
            this.typesTabPage.Text = "types";
            this.typesTabPage.UseVisualStyleBackColor = true;
            // 
            // EntertypesButton
            // 
            this.EntertypesButton.Location = new System.Drawing.Point(6, 6);
            this.EntertypesButton.Name = "EntertypesButton";
            this.EntertypesButton.Size = new System.Drawing.Size(99, 56);
            this.EntertypesButton.TabIndex = 7;
            this.EntertypesButton.Text = "Enter type Values";
            this.EntertypesButton.UseVisualStyleBackColor = true;
            this.EntertypesButton.Click += new System.EventHandler(this.Entertypes_Click);
            // 
            // Compute_Nash
            // 
            this.Compute_Nash.Location = new System.Drawing.Point(670, 34);
            this.Compute_Nash.Name = "Compute_Nash";
            this.Compute_Nash.Size = new System.Drawing.Size(103, 56);
            this.Compute_Nash.TabIndex = 5;
            this.Compute_Nash.Text = "Compute_Nash";
            this.Compute_Nash.UseVisualStyleBackColor = true;
            this.Compute_Nash.Click += new System.EventHandler(this.Compute_Nash_Click);
            // 
            // CPRCHeck
            // 
            this.CPRCHeck.Location = new System.Drawing.Point(670, 161);
            this.CPRCHeck.Name = "CPRCHeck";
            this.CPRCHeck.Size = new System.Drawing.Size(103, 56);
            this.CPRCHeck.TabIndex = 7;
            this.CPRCHeck.Text = "Check CPR";
            this.CPRCHeck.UseVisualStyleBackColor = true;
            this.CPRCHeck.Click += new System.EventHandler(this.CPRCHeck_Click);
            // 
            // PRCHeck
            // 
            this.PRCHeck.Location = new System.Drawing.Point(670, 99);
            this.PRCHeck.Name = "PRCHeck";
            this.PRCHeck.Size = new System.Drawing.Size(103, 56);
            this.PRCHeck.TabIndex = 6;
            this.PRCHeck.Text = "Check PR";
            this.PRCHeck.UseVisualStyleBackColor = true;
            this.PRCHeck.Click += new System.EventHandler(this.PRCHeck_Click);
            // 
            // ShowAllExtremeNashes
            // 
            this.ShowAllExtremeNashes.Location = new System.Drawing.Point(670, 223);
            this.ShowAllExtremeNashes.Name = "ShowAllExtremeNashes";
            this.ShowAllExtremeNashes.Size = new System.Drawing.Size(103, 58);
            this.ShowAllExtremeNashes.TabIndex = 8;
            this.ShowAllExtremeNashes.Text = "Show_All_Extreme_Nashes";
            this.ShowAllExtremeNashes.UseVisualStyleBackColor = true;
            this.ShowAllExtremeNashes.Click += new System.EventHandler(this.ShowAllExtremeNashes_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(670, 287);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(103, 58);
            this.btn_Reset.TabIndex = 9;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(691, 473);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(691, 505);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "label5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(670, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 58);
            this.button1.TabIndex = 14;
            this.button1.Text = "Baysian Nashes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 552);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShowAllExtremeNashes);
            this.Controls.Add(this.Compute_Nash);
            this.Controls.Add(this.CPRCHeck);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.PRCHeck);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameCounters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCounters)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.InputTab.ResumeLayout(false);
            this.InputTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.Strategy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.BenefitTab.ResumeLayout(false);
            this.typesTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage InputTab;
        private System.Windows.Forms.TabPage Strategy;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheNumberOfPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button GetStrategies;
        private System.Windows.Forms.TabPage BenefitTab;
        private System.Windows.Forms.Button EnterPayOFFs;
        private System.Windows.Forms.TabPage typesTabPage;
        private System.Windows.Forms.Button Compute_Nash;
        private System.Windows.Forms.Button CPRCHeck;
        private System.Windows.Forms.Button PRCHeck;
        private System.Windows.Forms.Button ShowAllExtremeNashes;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown GameCounters;
        public System.Windows.Forms.NumericUpDown PlayerCounters;
        public System.Windows.Forms.Button Enter;
        public System.Windows.Forms.Button EachPlayertypeCount;
        public System.Windows.Forms.Button EntertypesButton;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}

