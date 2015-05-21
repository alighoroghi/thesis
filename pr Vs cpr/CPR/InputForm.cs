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
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Start();
            timer.Tick += timer_Tick;
            NoNashCounts = 0;
            PRCounts = 0;
            CPRCounts = 0;
        }

        Form1 f1;
        int iterations = -1;
        public static int NoNashCounts=0;
        public static int PRCounts = 0;
        public static int CPRCounts = 0;
        int TempThenumberofGames, TempTheNumberOfPlayers, TemptypeCounts;
        DataGridView[] typeGridViews=null;
        double[, ,] types;
        Timer timer = new Timer();
        int tempi = 0;

        private void Enter_Click(object sender, EventArgs e)
        {           
            TempThenumberofGames=int.Parse(GameCounters.Value.ToString());
            TempTheNumberOfPlayers = int.Parse(TheNumberOfPlayers.Value.ToString());
            TemptypeCounts=int.Parse(typeCounts.Value.ToString());
            iterations = int.Parse(IterationCountNumeric.Value.ToString());
            typeGridViews = CreatetypeGridViewList(TempTheNumberOfPlayers, TempThenumberofGames,TemptypeCounts);
            ShowtypeTabGridViews();
            CreateRandomtypes(TemptypeCounts);
            AssignRandomtypesToGridViews(TemptypeCounts);
        }

        private void AssignRandomtypesToGridViews(int typeCountsForEachPlayer)
        {
            for (int i = 0; i < TempTheNumberOfPlayers; i++)
            {
                DataGridView dgv = typeGridViews[i];
                for (int j = 0; j < typeCountsForEachPlayer; j++)
                    for (int k = 0; k < TempThenumberofGames; k++)
                        dgv[k, j].Value = types[j, k, i];
            }
        }

        void CreateRandomtypes(int typeCountsForEachPlayer)
        {
            int k = typeCountsForEachPlayer;
            types = new double[typeCountsForEachPlayer, TempThenumberofGames, TempTheNumberOfPlayers];

            for (int i = 0; i < TempTheNumberOfPlayers; i++)
                for (int j = 0; j < typeCountsForEachPlayer; j++)
                {
                    double[] temp = GenerateRandomAssendingLine(TempThenumberofGames);
                    for (int m = 0; m < TempThenumberofGames; m++)
                        types[j, m, i] = temp[m];
                }
        }

        private void EntertypesButton_Click(object sender, EventArgs e)
        {
            Settypes();
            tempi = 0;
          //  try
            {
                for (; tempi < iterations; tempi++)
                {                    
                    f1 = new Form1();
                    f1.Text = tempi.ToString();
                   
                    f1.GameCounters.Value = this.GameCounters.Value;
                    f1.numericUpDown1.Value = this.typeCounts.Value;
                    f1.PlayerCounters.Value = this.TheNumberOfPlayers.Value;
                    f1.EachPlayertypeCount_Click_1(sender, e);
                    f1.Enter_Click(sender, e);
                    f1.GetStrategies_Click(sender, e);
                    f1.EnterPayOFFs_Click(sender, e);                    
                    f1.Entertypes_Click(sender, e, typeGridViews);
                    f1.Compute_Nash_Click(sender, e);
                    f1.PRCHeck_Click(sender, e);
                    f1.ShowAllExtremeNashes_Click(sender, e);
                    f1.CPRCHeck_Click(sender, e);
                }
            }
           // catch (Exception a) 
            {
               // MessageBox.Show(a.Message);
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (tempi == iterations)
            {
                timer.Enabled = false;
                timer.Stop();
            }

            label9.Text = (tempi - NoNashCounts).ToString();
            label10.Text = PRCounts.ToString();
            label11.Text = CPRCounts.ToString();
            label12.Text = iterations.ToString();
            progressBar1.Value = 100 * tempi / iterations;
        }

        private void Settypes()
        {
            try
            {
                types = new double[TemptypeCounts, TempThenumberofGames, TempTheNumberOfPlayers];
                for (int i = 0; i < TempTheNumberOfPlayers; i++)
                {
                    DataGridView dgv = typeGridViews[i];
                    for (int j = 0; j < TemptypeCounts; j++)
                        for (int k = 0; k < TempThenumberofGames; k++)
                        {
                            types[j, k, i] = double.Parse(dgv[k, j].Value.ToString());
                            if (types[j, k, i] == 1)
                                MessageBox.Show("You should NOT have entered an extreme wight in the item( " + j.ToString() + " , " + k.ToString() + " ) for the " + (i + 1) + "th player.\nRevise it and Enter again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
            catch
            {
                MessageBox.Show("Error in data input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataGridView[] CreatetypeGridViewList(int TempTheNumberOfPlayers, int TempThenumberofGames, int typeCountsForEachPlayer)
        {
            DataGridView[] Wlist = new DataGridView[TempTheNumberOfPlayers];
            Point Offset = new Point(30, 100);

            for (int i = 0; i < TempTheNumberOfPlayers; i++)
            {
                DataGridView temp = new DataGridView();
                temp.AutoSize = true;
                temp.ColumnCount = TempThenumberofGames;
                for (int j = 0; j < TempThenumberofGames; j++)
                    temp.Columns[j].HeaderText = (j + 1).ToString() + "th Game";
                if (typeCountsForEachPlayer==1)
                    temp.Rows.Add(typeCountsForEachPlayer);
                else
                    temp.Rows.Add(typeCountsForEachPlayer-1);
                typesTabPage.Controls.Add(temp);
                temp.Location = new Point(temp.Size.Width * i + Offset.X * i, Offset.Y);
                Label tl = new Label();
                tl.AutoSize = false;
                tl.Text = (i + 1).ToString() + "th Player";
                typesTabPage.Controls.Add(tl);
                tl.Location = new Point(temp.Size.Width * i + Offset.X * i, Offset.Y - 20);
                Wlist[i] = temp;
            }
            return Wlist;
        }

        private void ShowtypeTabGridViews()
        {
            foreach (DataGridView item in typeGridViews)
                item.Show();
        }

        double[] GenerateRandomAssendingLine(int cols)
        {
            while (true)
            {
                List<double> array = new List<double>();
                for (int i = 0; i < cols - 1; i++)
                    array.Add(MyRandomClass.RanNextDouble);
                array.Sort();
                array.Add(1);
                List<double> tt = new List<double>();
                tt.Add(array[0]);
                for (int i = 1; i < cols; i++)
                    tt.Add(array[i] - array[i - 1]);
                if (tt.Sum() == 1 && !tt.Contains(1))
                    return tt.ToArray();
            }
        }
    }
}