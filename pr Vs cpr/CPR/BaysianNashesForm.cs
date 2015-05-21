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
    public partial class BaysianNashesForm : Form
    {
        public BaysianNashesForm()
        {
            InitializeComponent();
            AutoScroll = true;
        }

        internal void ShowInfoDoubleGame(List<List<int>>[] BN, int typeCounts)
        {
            int TheNumberOfPlayers = BN.Length;
            Point Location = new Point(46, 46), OffSet = new Point(88, 0);
            int EachPlayertypeCounts = typeCounts;

            for (int i = 0; i < TheNumberOfPlayers; i++)
            {
                DataGridView dgv = new DataGridView(); Label PlayerLabel = new Label();
                this.Controls.Add(dgv); this.Controls.Add(PlayerLabel);
                dgv.ColumnCount = EachPlayertypeCounts;
                dgv.Rows.Add(GetMaxElement(BN[i]));

                for (int j = 0; j < EachPlayertypeCounts; j++)
                {
                    if (j==0)
                        dgv.Columns[j].HeaderText = "1th Extrieme type";
                   else if (j==(EachPlayertypeCounts-1))
                        dgv.Columns[j].HeaderText = "2th Extrieme type";
                    else
                    dgv.Columns[j].HeaderText = (j).ToString() + "th type";
                    for (int temp = 0; temp < BN[i][j].Count; temp++)
                        dgv[j, temp].Value = "S"+(i+1).ToString()+(BN[i][j][temp] + 1).ToString();
                }
                dgv.AutoSize = true;
                dgv.Location = Location;
                PlayerLabel.Location = new Point(dgv.Location.X + dgv.Size.Width / 2, dgv.Location.Y - 40);
                PlayerLabel.Text = (i + 1).ToString() + "th Player";
                Location.X = dgv.Size.Width + Location.X + OffSet.X;
            }
            this.Show();
        }

        private int GetMaxElement(List<List<int>> B)
        {
            int ans = int.MinValue;
            foreach (List<int> x in B)
                foreach (int y in x)
                    if (y > ans)
                        ans = y;
            return ans + 1;
        }

        internal void ShowInfoMultipleGame(List<List<int>>[] ExtriemeBaysianNashes4MultiGame, List<List<int>> NonExtriemeBaysianNashes4MultiGame, int EachPlayertypeCounts, int TempTheNumberOfPlayers)
        {
            int TheNumberOfPlayers = ExtriemeBaysianNashes4MultiGame.Length, typeCounts4EachPlayer = NonExtriemeBaysianNashes4MultiGame[0].Count;
            int ThenumberofGames = ExtriemeBaysianNashes4MultiGame[0].Count; Point Location = new Point(46, 46), OffSet = new Point(88, 0);

            for (int i = 0; i < TheNumberOfPlayers; i++)
            {
                DataGridView dgv = new DataGridView();
                dgv.ColumnCount = ThenumberofGames+typeCounts4EachPlayer;
                dgv.Rows.Add(2); 

                for (int j = 0; j < typeCounts4EachPlayer; j++)
                {
                    dgv[j, 0].Value = "S" + (i + 1).ToString() + (NonExtriemeBaysianNashes4MultiGame[i][j] + 1).ToString();
                    dgv.Columns[j].HeaderText = (j + 1).ToString() + "th type";
                }
                for (int j = typeCounts4EachPlayer; j < ThenumberofGames+typeCounts4EachPlayer; j++)
                {
                    string temp = "";
                    foreach (int x in ExtriemeBaysianNashes4MultiGame[i][j-typeCounts4EachPlayer])
                        temp += "S"+(i+1).ToString()+(x+1).ToString()+",";
                    temp = temp.Remove(temp.Length - 1);
                    dgv[j, 0].Value = temp;
                    dgv.Columns[j].HeaderText=(j-typeCounts4EachPlayer).ToString()+"th Ext type";
                }
                dgv.AutoSize = true;
                dgv.Location = Location;                
                Controls.Add(dgv);
                Label PlayerLabel = new Label();
                PlayerLabel.Text = (i+1).ToString() + "th Player";
                PlayerLabel.Location = new Point( dgv.Location.X,dgv.Location.Y-40);
                Controls.Add(PlayerLabel);
                Location.X = Location.X + OffSet.X + dgv.Size.Width;
            }
            this.Show();
        }
    }
}