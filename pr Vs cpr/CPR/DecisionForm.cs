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
    public partial class DecisionForm : Form
    {
        static bool newcpr ;
        static bool Check_PR_CPR=false;
        public static bool bUseNewCPR { get { return newcpr; } set { } }
        public static bool CheckPRCPR{ get { return Check_PR_CPR; } set { } }
        
        public DecisionForm()
        {
            InitializeComponent();
            newcpr = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            Form F=null;
            if (PR_CPR_Chicking_radioButton1.Checked)
                F=new Form1 ();
            if (ReportingradioButton.Checked)
                F = new InputForm();
            F.Show();
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            newcpr = checkBox1.Checked;
        }

        private void PR_CPR_Chicking_radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Check_PR_CPR = PR_CPR_Chicking_radioButton1.Checked;
        }

        private void DecisionForm_Load(object sender, EventArgs e)
        {
            List<int> []lll = new List<int>[8];
        }
    }
}