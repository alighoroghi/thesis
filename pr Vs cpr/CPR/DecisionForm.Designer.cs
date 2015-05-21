namespace CPR
{
    partial class DecisionForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ReportingradioButton = new System.Windows.Forms.RadioButton();
            this.PR_CPR_Chicking_radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.ReportingradioButton);
            this.groupBox1.Controls.Add(this.PR_CPR_Chicking_radioButton1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choosing Action";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(12, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(105, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "CPR Checking 2";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ReportingradioButton
            // 
            this.ReportingradioButton.AutoSize = true;
            this.ReportingradioButton.Checked = true;
            this.ReportingradioButton.Location = new System.Drawing.Point(12, 25);
            this.ReportingradioButton.Name = "ReportingradioButton";
            this.ReportingradioButton.Size = new System.Drawing.Size(71, 17);
            this.ReportingradioButton.TabIndex = 2;
            this.ReportingradioButton.TabStop = true;
            this.ReportingradioButton.Text = "Reporting";
            this.ReportingradioButton.UseVisualStyleBackColor = true;
            // 
            // PR_CPR_Chicking_radioButton1
            // 
            this.PR_CPR_Chicking_radioButton1.AutoSize = true;
            this.PR_CPR_Chicking_radioButton1.Location = new System.Drawing.Point(103, 25);
            this.PR_CPR_Chicking_radioButton1.Name = "PR_CPR_Chicking_radioButton1";
            this.PR_CPR_Chicking_radioButton1.Size = new System.Drawing.Size(115, 17);
            this.PR_CPR_Chicking_radioButton1.TabIndex = 1;
            this.PR_CPR_Chicking_radioButton1.Text = "PR/CPR Checking";
            this.PR_CPR_Chicking_radioButton1.UseVisualStyleBackColor = true;
            this.PR_CPR_Chicking_radioButton1.CheckedChanged += new System.EventHandler(this.PR_CPR_Chicking_radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(3, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DecisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 114);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 152);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 152);
            this.Name = "DecisionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DecisionForm";
            this.Load += new System.EventHandler(this.DecisionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ReportingradioButton;
        private System.Windows.Forms.RadioButton PR_CPR_Chicking_radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}