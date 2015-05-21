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
    public partial class AllNashesForm : Form
    {

        #region Variables
        private List<List<List<int>>[,]> AllNashes;
        int TheNumberOfPlayers, ThenumberofGames;
        private List<List<int>[,]> AllIndexes;
        private int TempTheNumberOfPlayers;
        private int TempThenumberofGames;
        List<List<int>> FixedPlayers;
        bool AreNoNashesHasBeenAdded = false;
        #endregion


        public AllNashesForm(List<List<int>[,]> list1, List<List<List<int>>[,]> list2, int TempTheNumberOfPlayers, int TempThenumberofGames,List<List<int>> ChoosenPlayers)
        {
            // TODO: Complete member initialization
            this.AllIndexes = list1;
            this.AllNashes = list2;
            this.TempTheNumberOfPlayers = TempTheNumberOfPlayers;
            this.TempThenumberofGames = TempThenumberofGames;
            this.FixedPlayers = ChoosenPlayers;
        } 

        public void MyLoad()
        {
            Size = new System.Drawing.Size(400, 400);
            AutoScroll = true;
            Point Offset = new Point(30, 60);
            int TableCounts = AllIndexes.Count;
            for (int i = 0; i < TableCounts; i++)
            {
                DataGridView dgv = new DataGridView();
                dgv.AutoSize = true;
                dgv.ColumnCount = 2;
                dgv.Columns[0].ReadOnly = true; dgv.Columns[1].ReadOnly = true;
                dgv.Columns[0].HeaderText = "Extreme types"; dgv.Columns[1].HeaderText = "Nashes";
                dgv.RowCount = AllIndexes[i].Length;
                int pointer = 0;
                for (int j = 0; j < AllIndexes[i].GetLength(0); j++)
                    for (int k = 0; k < AllIndexes[i].GetLength(1); k++)
                    {
                        string tempstring=GetValue(AllNashes, i, j, k,1);
                        dgv[1, pointer].Value = tempstring;
                        dgv[0, pointer].Value = GetValue(AllIndexes[i], j, k,1);
                        ++pointer;
                    }
                Controls.Add(dgv);
                Label InfLabel = new Label();
                InfLabel.AutoSize = true;
                string Q = "Choosen Players= (" + FixedPlayers[i][0].ToString() + "," + FixedPlayers[i][1].ToString() + ")"; ;
                InfLabel.Text = Q;
                Controls.Add(InfLabel);
                dgv.Location = new Point(dgv.Size.Width * i + Offset.X * i, Offset.Y);
                InfLabel.Location = new Point(dgv.Location.X,dgv.Location.Y-20);
            }
        }

        private string NashToString(List<int> list,int offset)
        {
            string temp = "(";
            foreach (int item in list)
                temp += (item+offset) + ",";
            temp = temp.Remove(temp.Length - 1);
            temp += ")";
            return temp;
        }
        
        private string GetValue(List<int>[,] list, int j, int k,int offset)
        {
            string temp = NashToString(list[j,k],offset);
            if (temp == "")
            {
                if (!AreNoNashesHasBeenAdded)
                {
                    AreNoNashesHasBeenAdded = true;
                    InputForm.NoNashCounts++;
                }
                return "No Nash"; 
            }
            return temp;
        }

        private string GetValue(List<List<List<int>>[,]> AllNashes, int i, int j, int k, int offset)
        {
            string temp = "";
            foreach (List<int> item in AllNashes[i][j, k])
            {
                temp += NashToString(item,offset);
            }
            if (temp == "")
            {
                if (!AreNoNashesHasBeenAdded)
                {
                    AreNoNashesHasBeenAdded = true;
                    InputForm.NoNashCounts++;
                }
                return "No Nash"; 
            }
            return temp;
        }

        private void AllNashesForm_Load(object sender, EventArgs e)
        {

        }
    }
}