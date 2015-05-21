using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CPR
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
            dataGridView1.RowCount = 4;
        }
        
        private void ResultForm_Load(object sender, EventArgs e)
        {
            dataGridView1[0, 0].Value = "Containing Fully Nashes";
            dataGridView1[0, 1].Value = "PR Counts";
            dataGridView1[0, 2].Value = "CPR Counts";
            dataGridView1[0, 3].Value = "Total Iterations";
        }

        public void  SetData(int PRCounts, int CPRCounts, int NashCounts, int TotalIterations)
        {
            dataGridView1[1, 0].Value = NashCounts.ToString();
            dataGridView1[1, 1].Value = PRCounts;
            dataGridView1[1, 2].Value = CPRCounts;
            dataGridView1[1, 3].Value = TotalIterations;
        }
    }
}