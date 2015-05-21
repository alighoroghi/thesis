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
    public partial class Form1 : Form
    {
        #region Variables
        Controller Cr;
        int TempTheNumberOfPlayers = 0, TempThenumberofGames = 0;
        int[] PlayerStrategiesCounts;
        DataGridView[] BenefitTabGridViews;
        DataGridView[] typeTabGridViews;
        double[, ,] Benefits;
        double[, ,] types;
        Controller Control = new Controller();
        AllNashesForm alfm;
        public static int EachPlayertypeCounts;
        List<List<int>>[] BaysianNashes4DoubleGame;
        List<List<int>>NonExtriemeBaysianNashes4MultiGame;
        List<List<int>>[] ExtriemeBaysianNashes4MultiGame;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }


        /* In this method:
         *  First: I declare player and game counts respectively as TempTheNumberOfPlayers and TempThenumberofGames.
         *  Second: If the game is Double Game, then I bound each player to have 2 strategies.
         *  Third: If TempThenumberofGames >= 4 or (TempThenumberofGames > 2 and TempTheNumberOfPlayers > 2)) I Initialize 7 types for each player randomly.
         */
        public void Enter_Click(object sender, EventArgs e)
        {
            TempTheNumberOfPlayers = (int)PlayerCounters.Value;
            TempThenumberofGames = (int)GameCounters.Value;
            try
            {
                typeTabGridViews = CreatetypeGridViewList(TempTheNumberOfPlayers, TempThenumberofGames, EachPlayertypeCounts);
                ShowtypeTabGridViews();
                CreateRandomtypes(EachPlayertypeCounts);
                AssignRandomtypesToGridViews(EachPlayertypeCounts);
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry,\nYou shoud have assigned the value for 'Number of types for each player'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//////////////////////////////////////////////////////////////////////////////
                return;
            }
            
            dataGridView1.RowCount = TempTheNumberOfPlayers;

            for (int i = 0; i < (int)PlayerCounters.Value; i++)
            {
                dataGridView1[0, i].Value = "Player " + (i + 1).ToString();
                if (TempThenumberofGames == 2)
                    dataGridView1[1, i].Value = 2;
            }

            if (TempThenumberofGames == 2)
            {
                GetStrategies_Click(sender, e);
                GetStrategies.Enabled = false;
            }
            else
                for (int i = 0; i < (int)PlayerCounters.Value; i++)
                    dataGridView1[1, i].Value = MyRandomClass.RanNext(2, TempThenumberofGames + 1);
        }

        private void AssignRandomtypesToGridViews(int typeCountsForEachPlayer)
        {
            for (int i = 0; i < TempTheNumberOfPlayers; i++)
            {
                DataGridView dgv = typeTabGridViews[i];
                for (int j = 0; j < typeCountsForEachPlayer; j++)
                {
                    for (int k = 0; k < TempThenumberofGames; k++)
                    {
                        dgv[k, j].Value = types[j, k, i];
                    }
                }
            }
        }

        private void ShowtypeTabGridViews()
        {
            foreach (DataGridView item in typeTabGridViews)
                item.Show();
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
                if (typeCountsForEachPlayer ==1)
                    temp.Rows.Add(1);
                else 
                    temp.Rows.Add(typeCountsForEachPlayer - 1);
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

        // In this method we assign each player the number of his strategies.
        public void GetStrategies_Click(object sender, EventArgs e)
        {
            Exception a = new Exception("Strategies should be greater than 2 and lower than ThenumberofGames");
            try
            {
                PlayerStrategiesCounts = new int[TempTheNumberOfPlayers];

                if (TempThenumberofGames > 2)
                    for (int i = 0; i < TempTheNumberOfPlayers; i++)
                    {
                        if (!(int.Parse(dataGridView1[1, i].Value.ToString()) >= 2 && int.Parse(dataGridView1[1, i].Value.ToString()) <= TempThenumberofGames))
                            throw a;
                        PlayerStrategiesCounts[i] = int.Parse(dataGridView1[1, i].Value.ToString());
                    }

                if (TempThenumberofGames == 2)
                    for (int i = 0; i < TempTheNumberOfPlayers; i++)
                    {
                        PlayerStrategiesCounts[i] = 2;
                    }                
            }
            
            catch (Exception v)
            {
                MessageBox.Show(v.Message);
                return;
            }

            int TempMultiply = 1;
            for (int i = 0; i < TempTheNumberOfPlayers; i++)
                TempMultiply *= PlayerStrategiesCounts[i];

            CreateDataGridViewForBenefitsTab(TempMultiply);
            //if (TempThenumberofGames >= 4 || (TempThenumberofGames>2&&TempTheNumberOfPlayers>2))
            {
                //EnterPayOFFs.Enabled = false;
                CreateRandomBenefits();
            }
        }

        private void CreateDataGridViewForBenefitsTab(int RowCountsforGVs)
        {
            BenefitTabGridViews = new DataGridView[TempThenumberofGames];
            DataGridView temp;
            Point Offset = new Point(30, 90);
            
            for (int i = 0; i < TempThenumberofGames; i++)
            {
                temp = new DataGridView();
                temp.ColumnCount = TempTheNumberOfPlayers + 1;
                temp.Columns[0].ReadOnly = true;
                temp.Rows.Add(RowCountsforGVs - 1);
                
                temp.AutoSize = true;
                BenefitTab.Controls.Add(temp);
                BenefitTabGridViews[i] = temp;
                temp.Name = "KK" + i.ToString();
                temp.Location = new Point(temp.Size.Width * i + Offset.X * i, Offset.Y);
                temp.Columns[0].HeaderText = "Strategies";
                for (int j = 1; j <= TempTheNumberOfPlayers; j++)
                    temp.Columns[j].HeaderText = "Player " + j.ToString() + "th Benefit";
                temp.Show();
                Label tl = new Label();
                BenefitTab.Controls.Add(tl);
                tl.AutoSize = false;
                tl.Location = new Point(temp.Size.Width * i + Offset.X * i, Offset.Y - 20);
                tl.Text = (i + 1).ToString() + "th Game";
            }
            
            foreach (DataGridView item in BenefitTabGridViews)
                item.CellEnter+=dgv_CellEnter;

            int[] Temp = new int[PlayerStrategiesCounts.Length];
            for (int i = 0; i < RowCountsforGVs; i++)
            {
                string TempString = "(";
                foreach (int x in Temp)
                    TempString += (x + 1).ToString() + ",";
                TempString = TempString.Remove(TempString.Length - 1);
                TempString += ")";

                for (int m = 0; m < TempThenumberofGames; m++)
                {
                    DataGridView dgv = (BenefitTabGridViews[m]);
                    dgv[0, i].Value = TempString;
                }

                Temp[1]++; int j = 1;
                try
                {                    if (Temp[1] >= PlayerStrategiesCounts[1])
                    {
                        Temp[1] = 0; Temp[0]++; j = 0;
                    }
                    else continue;
                    
                    if (Temp[0] >= PlayerStrategiesCounts[0])
                    {
                        Temp[0] = 0; j = 2; Temp[j]++;
                    }
                    else continue;
                    
                    while (Temp[j] >= PlayerStrategiesCounts[j] && j < Temp.Length)
                    {
                        Temp[j] = 0; Temp[j + 1]++; j++;
                    }
                }
                catch { }                
            }
        }

        // In this method we assign random PayOFFs
        private void CreateRandomBenefits()
        {
            int K = BenefitTabGridViews[0].RowCount;
            Benefits = new double[K, TempTheNumberOfPlayers, TempThenumberofGames];

            for (int m = 0; m < TempThenumberofGames; m++)
                for (int n = 0; n < TempTheNumberOfPlayers; n++)
                    for (int p = 0; p < K; p++)
                    {
                        DataGridView dgv = (BenefitTabGridViews[m]);
                        int x = MyRandomClass.RanNext(1, 21);
                        dgv[n + 1, p].Value = x;
                        Benefits[p, n, m] = x;
                    }
        }

        // In this method we take PayOffs from the user.
        public void EnterPayOFFs_Click(object sender, EventArgs e)
        {
            int K = 1;
            foreach (int item in PlayerStrategiesCounts)
                K *= item;
            Benefits = new double[K, TempTheNumberOfPlayers, TempThenumberofGames];

            //int q = int.Parse(BenefitTabGridViews[0][0, 0].Value.ToString());



            //with highly percent I think that our problem is started here!!!!!!
            for (int m = 0; m < TempThenumberofGames; m++)
                for (int n = 0; n < TempTheNumberOfPlayers; n++)
                    for (int p = 0; p < K; p++)
                    {
                        DataGridView dgv = (BenefitTabGridViews[m]);
                        Benefits[p, n, m] = double.Parse(dgv[n + 1,p].Value.ToString());
                    }
        }

        //Boolean bEnteredInBenefitTab = false;
        void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView send = (DataGridView)sender;
            Point loc = new Point(send.Location.X - BenefitTab.AutoScrollPosition.X - BenefitTab.Size.Width / 2, send.Location.Y - BenefitTab.AutoScrollPosition.Y - BenefitTab.Size.Height / 2);
            try
            {
                Point location = send.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                BenefitTab.AutoScrollPosition = new Point(location.X + loc.X, location.Y + loc.Y);
            }
            catch { }
        }

        // In this method we take the types of each player correspondence to games
        public void Entertypes_Click(object sender, EventArgs e)
        {
            try
            {
                types = new double[EachPlayertypeCounts, TempThenumberofGames, TempTheNumberOfPlayers];
                for (int i = 0; i < TempTheNumberOfPlayers; i++)
                {
                    DataGridView dgv = typeTabGridViews[i];
                    for (int j = 0; j < EachPlayertypeCounts; j++)
                    {
                        for (int k = 0; k < TempThenumberofGames; k++)
                        {
                            types[j, k, i] = double.Parse(dgv[k, j].Value.ToString());
                            if (types[j, k, i] == 1)
                            {
                                //MessageBox.Show("You should NOT have entered an extreme wight in the item( " + j.ToString() + " , " + k.ToString()
                                 //   + " ) for the " + (i + 1) + "th player.\nRevise it and Enter again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch
            {
                //MessageBox.Show("Error in data input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Creating a line of types which sum to 1.
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
            return null;
        }

        // Creating Random types
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

        public void Compute_Nash_Click(object sender, EventArgs e)
        {
            label4.Text = "PR:"; label5.Text = "CPR:";
            Control.SetInfo(types, Benefits, TempThenumberofGames, TempTheNumberOfPlayers, PlayerStrategiesCounts);
            Control.ComputeAllNashForExtTypetypes(Benefits);
        }

        public void CPRCHeck_Click(object sender, EventArgs e)
        {
            if (Control.ISPureRegular)
            {
                if (TempThenumberofGames == 2)
                {
                    Control.DoubleGameCheckCPR();
                }
                else
                    if (DecisionForm.bUseNewCPR)
                    {
                        Control.CPRChecking2(ref NonExtriemeBaysianNashes4MultiGame);
                    }
                    else
                    {
                        Control.IsMultipleGameACPR(); 
                    }

                if (Control.ISCompletePureRegular)
                {
                    this.Show();
                    if (TempThenumberofGames > 2)
                    {
                        Control.GetBaysianEQ(ref NonExtriemeBaysianNashes4MultiGame);
                        Control.GetBaysianNashes4MultipleGames(ref this.ExtriemeBaysianNashes4MultiGame);
                    }
                    if (TempThenumberofGames == 2)
                        BaysianNashes4DoubleGame = Control.CheckBaysianNash4DoubleGame();
                    label5.Text = "CPR: Yes";
                    InputForm.CPRCounts++;
                }
                else
                    label5.Text = "CPR: No";
            }
            else
                label5.Text = "CPR: No";
        }

        public void PRCHeck_Click(object sender, EventArgs e)
        {
            if (Control.ISPureRegular)
            {
                label4.Text = "PR: Yes";
                InputForm.PRCounts++;
            }else
                label4.Text = "PR: No";
        }

        public void ShowAllExtremeNashes_Click(object sender, EventArgs e)
        {
            alfm = new AllNashesForm(Control.AllIndexesOfAllNashes, Control.AllNashes, TempTheNumberOfPlayers, TempThenumberofGames, Control.ChosenPlayersToBeFixed);
            alfm.MyLoad();
            if (DecisionForm.CheckPRCPR)
                alfm.Show();
        }

        public void EachPlayertypeCount_Click_1(object sender, EventArgs e)
        {
            EachPlayertypeCounts = int.Parse(numericUpDown1.Value.ToString());
        }

        internal void Entertypes_Click(object sender, EventArgs e, DataGridView[] typeGridViews)
        {
            for (int i = 0; i < typeTabGridViews.Length; i++)
                for (int m = 0; m < EachPlayertypeCounts; m++)
                    for (int p = 0; p < TempThenumberofGames; p++)
                        typeTabGridViews[i][p, m].Value = typeGridViews[i][p, m].Value;
            Entertypes_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = "PR:"; label5.Text = "CPR:";
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            label4.Text = "PR:";
            label5.Text = "CPR:";
            for (int i = 0; i < BenefitTab.Controls.Count; i++)
            {
                string temp = BenefitTab.Controls[i].GetType().ToString();
                if ("System.Windows.Forms.DataGridView" == temp || "System.Windows.Forms.Label" == temp)
                {
                    BenefitTab.Controls.Remove(BenefitTab.Controls[i]);
                     --i;
                }
            }

            for (int i = 0; i < typesTabPage.Controls.Count; i++)
            {
                string temp = typesTabPage.Controls[i].GetType().ToString();
                if ("System.Windows.Forms.DataGridView" == temp || "System.Windows.Forms.Label" == temp)
                {
                    typesTabPage.Controls.Remove(typesTabPage.Controls[i]);
                    --i;
                }
            }
            GetStrategies.Enabled = true;
            MessageBox.Show("Please come back to the Input TabPage then enter your data respectively!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Control.ISCompletePureRegular)
            {
                if (TempThenumberofGames==2)
                {
                    BaysianNashesForm bnf = new BaysianNashesForm();
                    bnf.ShowInfoDoubleGame(BaysianNashes4DoubleGame,EachPlayertypeCounts+2);// +2 baraye 2ta vazne hadi hast !!!!
                }
                if (TempThenumberofGames>2)
                {
                    BaysianNashesForm bnf = new BaysianNashesForm();
                    bnf.ShowInfoMultipleGame(ExtriemeBaysianNashes4MultiGame,NonExtriemeBaysianNashes4MultiGame, EachPlayertypeCounts,TempTheNumberOfPlayers);
                }
            }
        }
    }
}