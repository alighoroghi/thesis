using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CPR
{
    class Controller
    {
        #region Variables
        public bool ISPureRegular { get; set; }
        public bool ISCompletePureRegular{ get; set; }
        int[] PlayerStrategiesCounts;
        public int TheNumberOfPlayers { get; set; }
        public int ThenumberofGames { get; set; }
        public double[,,] PayOffs{ get; set; }
        public double[, ,] types { get; set; }
        public List<List<List<int>>[,]> AllNashes;
        public List<List<int>[,]> AllIndexesOfAllNashes;
        public List<List<int>> ChosenPlayersToBeFixed;
        List<List<int>>[] CommonNashes4Extriemetypes;
        #endregion

        public Controller()
        {
        }
        
        private double[,] GetrequestedDimension(int dim,Point[,]array)
        {
            double[,] Temp = new double[array.GetLength(0), array.GetLength(1)];
            
            if (dim==1)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        Temp[i, j] = array[i, j].X;
            }
            if (dim == 2)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        Temp[i, j] = array[i, j].Y;
            }
            return Temp;
        }

        internal void SetInfo(double[, ,] types, double[, ,] Benefits, int TempThenumberofGames, int TempTheNumberOfPlayers, int[] PlayerStrategiesCounts)
        {
            this.types = types; this.PayOffs = Benefits; this.ThenumberofGames = TempThenumberofGames; this.TheNumberOfPlayers = TempTheNumberOfPlayers; this.PlayerStrategiesCounts = PlayerStrategiesCounts;
            this.CommonNashes4Extriemetypes =new List<List<int>>[TheNumberOfPlayers];
            for (int i = 0; i < TheNumberOfPlayers; i++)
            {
                CommonNashes4Extriemetypes[i] = new List<List<int>>();
                for (int j = 0; j < ThenumberofGames; j++)
                    CommonNashes4Extriemetypes[i].Add(new List<int>());
            }
        }

        public List<List<int>> ComputeNash(List<double>[] Array, int[] capacities)
        {
            //Array = TransposeFirstAndSecondDimension(Array, capacities);
            List<double> []Transposed = TransposeFirstAndSecondDimension(Array,capacities);
            int temp = capacities[0];
            capacities[0] = capacities[1];
            capacities[1] = temp;
            int ItemCounts = Array.Length;
            int dimensions = capacities.Length; //TheNumberOfPlayers;
            List<List<int>> Nash = new List<List<int>>();
            
            for (int i = 0; i < ItemCounts; i++)
            {
                bool nsh = true;
                for (int j = 0; j < dimensions; j++)
                {
                    double[] OneDimension = MultiDimToUnarDimin(Transposed, j);
                    if (!Myfunc(i, j, capacities, OneDimension))
                    {
                        nsh = false;
                        break;
                    }
                }
                if (nsh)
                    Nash.Add(Coordinates(i, capacities));
            }

            foreach (List<int> item in Nash)
            {
                int mytemp= item[0];
                item[0] = item[1];
                item[1] = mytemp;
            }
            return Nash;
        }

        private bool Myfunc(int item, int dim, int[] capacities, double[] array)
        {
            int Multiply = 1;
            int upperbound = 1,lowerbound=0;

            if (dim == 1)
                Multiply = capacities[1];

            if (dim > 1)
                for (int i = 0; i < dim; i++)
                {
                    Multiply *= capacities[i];
                }
            int temp = item;
            if (item==0)
            {
                
            }
            temp = item;

            Get_Upper_And_Lower_Bound(array, item, ref upperbound, ref lowerbound, capacities, dim);

            int NextUpItem = item + Multiply;
            int NextDownItem = item - Multiply;

            for (int i = NextDownItem; i >= 0&&i>=lowerbound; i -= Multiply)
                if (array[i] > array[item])
                    return false;
            
            for (int i = NextUpItem; i < upperbound; i += Multiply)
                if (array[i] > array[item])
                    return false;
            return true;
        }

        void Get_Upper_And_Lower_Bound(double[]array,int item,ref  int upper, ref int lower,int[]capacities,int dim)
        {            
            if (dim>=2)
            {
                List<int> coor = Coordinates(item, capacities);
                int i = (coor[dim] = 0);
                for (; i < array.Length; i++)
                    if (Equal(coor,Coordinates(i,capacities)))
                    {
                        lower = i; break;
                    }
                coor[dim] = capacities[dim] - 1;
                for (; i < array.Length; i++)
                    if (Equal(coor,Coordinates(i,capacities)))
                    {
                        upper = i+1; return;
                    }
                upper = array.Length ;
            }
            if (dim==0)
            {
                List<int> coor = Coordinates(item, capacities);
                int i =(coor[1] = 0);
                for (; i < array.Length; i++)
                    if (Equal(coor, Coordinates(i, capacities)))
                    { lower = i; break; }
                coor[1] = capacities[1] - 1;
                for (; i < array.Length; i++)
                    if (Equal(coor, Coordinates(i, capacities)))
                    {
                        upper =i+1; return;
                    }
            }

            if (dim == 1)
            {
                List<int> coor = Coordinates(item, capacities);
                int i = (coor[0] = 0);
                for (; i < array.Length; i++)
                    if (Equal(coor, Coordinates(i, capacities)))
                    { lower = i; break; }
                coor[0] = capacities[0] - 1;
                for (; i < array.Length; i++)
                    if (Equal(coor, Coordinates(i, capacities)))
                    {
                        upper =i+1; return;
                    }
            }
        }

        private bool Equal(List<int> coor, List<int> list)
        {
            for (int i = 0; i < coor.Count; i++)
                if (coor[i]!=list[i])
                    return false;
            return true;
        }


        private bool EqualInGreaterElements(int temp1, int temp2, int dim,int[]capacities)
        {
            if (dim==capacities.Length-1)
            {
                int temp = 1;
                foreach (int item in capacities)
                    temp *= item;
                if (temp2>=temp)
                {
                    return false;                    
                }
            }
            try
            {
                List<int> I1 = Coordinates(temp1, capacities), I2 = Coordinates(temp2, capacities);
                if (dim==0)
                    return I1[0] == I2[0];
                    if (I1[dim] >I2[dim])
                        return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool EqualInLowerElements(int temp1, int temp2, int dim, int[] capacities)
        {
            if (temp2 < 0)
                return false;
            try
            {
                List<int> I1 = Coordinates(temp1, capacities), I2 = Coordinates(temp2, capacities);
                      for (int i = capacities.Length-1; i >dim; i--)
                    if (I1[i] <I2[i])
                        return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        List<double>[] TransposeFirstAndSecondDimension(List<double>[]Input,int[]Capacities)
        {
            List<double>[] Transposed = new List<double>[Input.Length];
            for (int i = 0; i < Input.Length; i++)
                Transposed[i] = new List<double>();
            
            int m = 0;
            int temp = 0;
            while (m < Input.Length)
            {
                for (int i = m; i < m + (Capacities[0] * Capacities[1]); i++)
                {
                    List<int> Coordination1 = Coordinates(i, Capacities);
                    List<int> Coordination2 = Clone(Coordination1);
                     temp = Coordination2[0];
                    Coordination2[0] = Coordination2[1];
                    Coordination2[1] = temp;
                    temp=Capacities[0];
                    Capacities[0] = Capacities[1];
                    Capacities[1] = temp;
                    int Target = GetItemFromTransposed(Coordination2, Capacities);
                    temp=Capacities[0];
                    Capacities[0] = Capacities[1];
                    Capacities[1] = temp;

                    Transposed[Target] = Input[i];
                }
                m += Capacities[0] * Capacities[1];
            }
            return Transposed;
        }

        private int GetItemFromTransposed(List<int> Coordination2, int[] InvCapacity)
        {
            int item = 0;
            item=Coordination2[0]*InvCapacity[1]+Coordination2[1];

            for (int DIM = 2; DIM < InvCapacity.Length; DIM++)
            {
                int multiply = Coordination2[DIM];
                for (int j = 0; j < DIM; j++)
                    multiply *= InvCapacity[j];
                item += multiply;
            }
            return item;
        }

        private List<int> Clone(List<int> x)
        {
            List<int> temp = new List<int>();
            foreach (int item in x)
                temp.Add(item);
            return temp;
        }
        
        double[] MultiDimToUnarDimin(List<double>[] Array, int dim)
        {
            List<double> temp = new List<double>();
            foreach (List<double> item in Array)
            {
                temp.Add(item[dim]);
            }
            return temp.ToArray();
        }

        private List<int> Coordinates(int item, int[] capacities)
        {
            List<int> Answer = new List<int>();
            int temp = 0;

            temp = capacities[0];
            capacities[0] = capacities[1];
            capacities[1] = temp;
            for (int i = capacities.Length - 2; i >= 0; i--)
            {
                int multiply = 1;
                for (int j = 0; j <= i; j++)
                    multiply *= capacities[j];
                temp = item / multiply;
                item = item % multiply;
                Answer.Insert(0, temp);
            }
            Answer.Insert(0, item);
            temp = Answer[0];
            Answer[0] = Answer[1];
            Answer[1] = temp;


            temp = capacities[0];
            capacities[0] = capacities[1];
            capacities[1] = temp;
            return Answer;
        }

        List<int> BaseGame_PR(int item)
        {
            List<int> ans=new List<int>();

            if (item / ThenumberofGames == 0 && ans.Count < TheNumberOfPlayers - 2)
                ans.Add(item);

            while (item/ThenumberofGames!=0)
            {
                ans.Add(item%ThenumberofGames);
                item /= ThenumberofGames;

                if (item/ThenumberofGames==0)
                    ans.Add(item);
            }
            
            while (ans.Count < TheNumberOfPlayers - 2)
                ans.Add(0);
            return ans;
        }

        List<double> []GettypeedMatrix(double[, ,] PayOff, int k, int m, int i, int j, int p)
        {
            List<int> Tetas = BaseGame_PR(p);
            Tetas.Insert(k, i);
            Tetas.Insert(m, j);
            List<double>[]Answer=new List<double>[PayOff.GetLength(0)];
            for (int o = 0; o < Answer.GetLength(0); o++)
            {
                Answer[o] = new List<double>();
            }
            for (int n = 0; n < Answer.GetLength(0); n++)
                for (int h = 0; h < TheNumberOfPlayers; h++)
                {
                    double temp = PayOff[n, h, Tetas[h]];
                    Answer[n].Add(temp);
                }
            return Answer;
        }

        List<double>[] GettypeedMatrix(double[, ,] PayOff, int i, int m, int Others)
        {
            List<int> Tetas = BaseGame_CPR(Others);
            Tetas.Insert(i, m);
            
            List<double>[] Answer = new List<double>[PayOff.GetLength(0)];
            for (int o = 0; o < Answer.GetLength(0); o++)
            {
                Answer[o] = new List<double>();
            }
            for (int n = 0; n < Answer.GetLength(0); n++)
                for (int h = 0; h < TheNumberOfPlayers; h++)
                {
                    double temp = PayOff[n, h, Tetas[h]];
                    Answer[n].Add(temp);
                }
            return Answer;
        }

        private List<int> BaseGame_CPR(int item)
        {
            List<int> ans = new List<int>();

            if (item / ThenumberofGames == 0 && ans.Count < TheNumberOfPlayers - 1)
                ans.Add(item);

            while (item / ThenumberofGames != 0)
            {
                ans.Add(item % ThenumberofGames);
                item /= ThenumberofGames;

                if (item / ThenumberofGames == 0)
                    ans.Add(item);
            }

            while (ans.Count < TheNumberOfPlayers - 1)
                ans.Add(0);
            return ans;
        }

        public void ComputeAllNashForExtTypetypes(double[, ,] PayOff)
        {
            List<List<int>>[,] TemporaryNashes= new List<List<int>>[(int)Math.Pow(ThenumberofGames, TheNumberOfPlayers - 2), (int)Math.Pow(ThenumberofGames, 2)];
            List<int>[,] TemporaryIndexOfNashes = new List<int>[(int)Math.Pow(ThenumberofGames, TheNumberOfPlayers - 2), (int)Math.Pow(ThenumberofGames, 2)];
            AllNashes = new List<List<List<int>>[,]>();
            AllIndexesOfAllNashes = new List<List<int>[,]>();
            ChosenPlayersToBeFixed = new List<List<int>>();

            for (int k = 0; k < TheNumberOfPlayers; k++)
            {
                for (int m = k + 1; m < TheNumberOfPlayers; m++)
                {
                    for (int i = 0; i < ThenumberofGames; i++)
                        for (int j = 0; j < ThenumberofGames; j++)
                            for (int p = 0; p < (int)Math.Pow(ThenumberofGames, TheNumberOfPlayers - 2); p++)
                            {
                                List<double>[] typeed = GettypeedMatrix(PayOff, k, m, i, j, p);
                                int[] capacities = new int[TheNumberOfPlayers];
                                PlayerStrategiesCounts.CopyTo(capacities, 0);
                                List<List<int>> Nash = ComputeNash(typeed, capacities);
                                TemporaryNashes[p, ThenumberofGames * i + j] = Clone(Nash);
                                TemporaryIndexOfNashes[p, ThenumberofGames * i + j] = GetIndexOfNashe(k,m,i,j,p);
                            }
                    AllIndexesOfAllNashes.Add(TemporaryIndexOfNashes);
                    AllNashes.Add(TemporaryNashes);
                    
                    List<int> ChosenPlayers = new List<int>(); ChosenPlayers.Add(k); ChosenPlayers.Add(m);
                    ChosenPlayersToBeFixed.Add(ChosenPlayers);

                    this.ISPureRegular= CheckPR(TemporaryNashes, k, m);
                    if (!this.ISPureRegular)
                        return;

                    TemporaryIndexOfNashes = new List<int>[(int)Math.Pow(ThenumberofGames, TheNumberOfPlayers - 2), (int)Math.Pow(ThenumberofGames, 2)];
                    TemporaryNashes=new List<List<int>>[(int)Math.Pow(ThenumberofGames, TheNumberOfPlayers - 2), (int)Math.Pow(ThenumberofGames, 2)];
                    //Save data here
                }
            }
        }

        private List<int> GetIndexOfNashe(int k, int m, int i, int j, int p)
        {
            List<int> Tetas = BaseGame_PR(p);
            Tetas.Insert(k, i);
            Tetas.Insert(m, j);
            return Tetas;
        }

        private bool CheckPR(List<List<int>>[,] Table, int p1, int p2)
        {
            try
            {
                for (int row = 0; row < (int)Math.Pow(ThenumberofGames,TheNumberOfPlayers-2); row++)
                {
                    for (int i = 0; i < (int)Math.Pow(ThenumberofGames,2); i++)
                        for (int j = i+1; j < (i-i%ThenumberofGames)+ThenumberofGames; j++)
                            if (!HaveInCommon(Table[row,i],Table[row,j],p1))
                                return false;

                    for (int i = 0; i < (int)Math.Pow(ThenumberofGames, 2); i++)
                        for (int j = i + ThenumberofGames; j < (ThenumberofGames*ThenumberofGames) ; j+=ThenumberofGames)
                            if (!HaveInCommon(Table[row,i],Table[row,j],p2))
                                return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool HaveInCommon(List<List<int>> p1Nash, List<List<int>> p2Nash, int player)
        {
            foreach (List<int> x in p1Nash)
                foreach (List<int> y in p2Nash)
                    if (x[player].ToString() == y[player].ToString())
                        return true;
            return false;
        }

       private List<List<int>> Clone(List<List<int>> Nash)
       {
           List<List<int>> ans = new List<List<int>>();
           foreach (List<int> item in Nash)
           {
               ans.Add(Clone(item));
           }
           return ans;
       }

       public void DoubleGameCheckCPR()
       {
           for (int m = 0; m < (int)Math.Pow(ThenumberofGames, TheNumberOfPlayers - 2); m++)
               for (int i = 0; i < TheNumberOfPlayers; i++)
                   for (int j =0; j < TheNumberOfPlayers; j++)//PLAYER DOWOM
                   {
                       if (j==i)
                           continue;
                       List<int> ConstantNash = new List<int>();
                       int[,] Pashne = new int[,] { { -1, -2 }, { -3, -4 } };
                       List<List<double>> SortedList = SortPlayertypes(types, j); //    ----------------inja miaim va list ro sort mikonim
                       for (int haddi = 0; haddi < 2; haddi++)//    ---------------- be ezaye 2 ta vazn haddie player e awwal
                       {
                           List<List<List<int>>> NineNashes = new List<List<List<int>>>();
                           int ConstantNashIndex = 0, EarlyNashCount = 0;

                           for (int k = 0; k < SortedList.Count; k++)//    ---------------- be ezaye vazn haye sort swhodeye player e dowwom
                           {
                               List<double>[] Temptype = GetDoubleGameCPRtypes(SortedList[k], j, haddi, i, m);   //    ----------------inja vazn haro dar payoff zarb mikoneem va matris amade mishe vase hesabe nash
                               bool bBreak = true; List<List<int>> TempNash = new List<List<int>>(); int[] capacities = new int[TheNumberOfPlayers];
                               PlayerStrategiesCounts.CopyTo(capacities, 0);

                               for (int tempVar = 0; tempVar < Temptype.GetLength(0); tempVar++)
                                   for (int tempvar2 = 0; tempvar2 < Temptype[tempVar].Count; tempvar2++)
                                       Temptype[tempVar][tempvar2] = Math.Round(Temptype[tempVar][tempvar2]);

                               TempNash = ComputeNash(Temptype, capacities);//    ----------------inja nash ha hesab mishand
                               NineNashes.Add(TempNash);//    ---------------- nash haye hesab shode ro mirizim tuye in list
                               if (k == 0)
                               { ConstantNash = TempNash[ConstantNashIndex]; EarlyNashCount = TempNash.Count; continue; }//    ---------------- awwalin nash hast ke bayad ba baqye moqayese shavad ta pashne bedast biad

                               foreach (List<int> x in TempNash)
                                   if (x[j] == ConstantNash[j])//    ----------------moqayeseye nash e avallye ba nash e hesab shode
                                   {
                                       bBreak = false;
                                       break; 
                                   }

                               if (bBreak&&ConstantNashIndex<EarlyNashCount-1)
                               {
                                   ConstantNashIndex++; NineNashes = new List<List<List<int>>>(); k = -1; continue;
                               }

                               if (bBreak)//    ----------------??????????????????????????
                               {
                                   bool bFindPashne = false;
                                   Pashne[haddi, 0] = k;
                                   foreach (List<int> x in NineNashes[k - 1])
                                       foreach (List<int> y in TempNash)//    ----------------inja migim ke agar 2 ta pashne daSHTEEM MAQADEERRESH SABT SHAND
                                           if (x[j] == y[j])
                                               Pashne[haddi, 1] = k - 1;
                                   if (haddi == 0) break;
                                   if (haddi == 1)
                                   {
                                       if (Pashne[0, 0] == Pashne[1, 0] || Pashne[0, 0] == Pashne[1, 1] || Pashne[0, 1] == Pashne[1, 0] || Pashne[0, 1] == Pashne[1, 1])
                                           bFindPashne = true;

                                       if (bFindPashne) break;
                                       ISCompletePureRegular= false;
                                       return;
                                   }
                               }
                           }
                       }
                   }
           ISCompletePureRegular= true;
       }

       private List<double>[] GetDoubleGameCPRtypes(List<double> w, int p2, int haddi, int p1, int m)
       {
           List<int> temp = BaseGame_PR(m);
           List<double>Tetas=new List<double> ();
           for (int i = 0; i < temp.Count; i++)
               Tetas.Add((double)temp[i]);
           if (p1 < p2)
           {
               Tetas.Insert(p1, haddi);
               Tetas.Insert(p2, w[0]);
           }
           else { Tetas.Insert(p2, w[0]); Tetas.Insert(p1, haddi); }
           List<double>[] typeed = new  List<double>[(int)Math.Pow(ThenumberofGames,TheNumberOfPlayers)];
           
           for (int i = 0; i < (int)Math.Pow(ThenumberofGames, TheNumberOfPlayers); i++)
           {
               typeed[i] = new List<double>();
               for (int pn = 0; pn < TheNumberOfPlayers; pn++)
                   typeed[i].Add((1-Tetas[pn]) * PayOffs[i, pn, 0] + ( Tetas[pn]) * PayOffs[i, pn, 1]);
           }
           return typeed;
       }

       private List<List<double>> SortPlayertypes(double[, ,] types, int j)
       {
           List<List<double>> Temptypes = new List<List<double>>(); List<double> temp;
           int Rows=types.GetLength(0);
           for (int i = 0; i < Rows; i++)
           {
               temp = new List<double>();
               for (int n = 0; n < ThenumberofGames; n++)
                   temp.Add(types[i,n,j]);
               Temptypes.Add(temp);
           }
           temp = new List<double>(); temp.Add(1); temp.Add(0); Temptypes.Add(temp);
           temp = new List<double>(); temp.Add(0); temp.Add(1); Temptypes.Add(temp);
           var Sorted= from element in Temptypes
                         orderby element[0]
                         select element;
           List< List<double> >answers = new List<List<double>>();
           foreach (List<double> item in Sorted)
               //answers.Insert(0,item);
               answers.Add( item);
           return answers;
       }

       public List<List<int>>[] CheckBaysianNash4DoubleGame()
       {
           List<List<int>>[] BaysianNashes = new List<List<int>>[TheNumberOfPlayers];
           for (int m = 0; m < (int)Math.Pow(ThenumberofGames, TheNumberOfPlayers - 2); m++)
               for (int i = 0; i < TheNumberOfPlayers; i++)
                   for (int j = 0; j < TheNumberOfPlayers && BaysianNashes[j] == null; j++)
                   {
                       if (j==i)
                           continue;
                       List<List<double>> SortedList = SortPlayertypes(types, j);
                       List<List<int>> TempBayse = new List<List<int>>();
                       
                       for (int k = 0; k < SortedList.Count; k++)
                       {
                           List<double>[] TemptypeLeft = GetDoubleGameCPRtypes(SortedList[k], j, 0, i, m);
                           List<List<int>> TempNashLeft = new List<List<int>>(); int[] capacities = new int[TheNumberOfPlayers];
                           PlayerStrategiesCounts.CopyTo(capacities, 0);
                           for (int tempVar = 0; tempVar < TemptypeLeft.GetLength(0); tempVar++)
                               for (int tempvar2 = 0; tempvar2 < TemptypeLeft[tempVar].Count; tempvar2++)
                                   TemptypeLeft[tempVar][tempvar2] = Math.Round(TemptypeLeft[tempVar][tempvar2]);
                           TempNashLeft= ComputeNash(TemptypeLeft, capacities);


                           List<double>[] TemptypeRight = GetDoubleGameCPRtypes(SortedList[k], j, 1, i, m);
                           List<List<int>> TempNashRight = new List<List<int>>(); 
                           for (int tempVar = 0; tempVar < TemptypeRight.GetLength(0); tempVar++)
                               for (int tempvar2 = 0; tempvar2 < TemptypeRight[tempVar].Count; tempvar2++)
                                   TemptypeRight[tempVar][tempvar2] = Math.Round(TemptypeRight[tempVar][tempvar2]);
                           TempNashRight = ComputeNash(TemptypeRight, capacities);
                           
                           List<int> Intersection = new List<int>();
                           Intersection = GetIntersection(TempNashLeft, TempNashRight,j);
                           TempBayse.Add(Intersection);
                       }
                       BaysianNashes[j] = TempBayse;
                   }
           return BaysianNashes;
       }

       private List<int> GetIntersection(List<List<int>> TempNashLeft, List<List<int>> TempNashRight, int j)
       {
           List<int> temp = new List<int>();

           foreach (List<int> x in TempNashLeft)
               foreach (List<int> y in TempNashRight)
                   if (x[j]==y[j]&&!temp.Contains(x[j]))
                   {
                       temp.Add(x[j]); break;
                   }
           return temp;
       }

       public void IsMultipleGameACPR()
       {
           try
           {
               bool PatternIsEqual = false, TempIsEqual = false;
               List<double> PatternSigns = new List<double>(), TempSigns = new List<double>();

               for (int i = 0; i < TheNumberOfPlayers; i++)
                   for (int m = 0; m < ThenumberofGames; m++)
                       for (int n = m+1; n < ThenumberofGames; n++)
                           for (int j = 0; j < (int)Math.Pow(ThenumberofGames, TheNumberOfPlayers - 1); j++)
                               if (j == 0)
                               {
                                   PatternSigns = GetSigns(i, m, n, j, ref PatternIsEqual); continue;
                               }
                               else
                               {
                                   TempSigns = GetSigns(i,m,n,j,ref TempIsEqual);
                                   if ((PatternIsEqual) && (!TempIsEqual) || (!PatternIsEqual) && (TempIsEqual))
                                   {
                                       ISCompletePureRegular= false;
                                       return ; 
                                   }
                                   if ((PatternIsEqual) && (TempIsEqual) )
                                       continue;
                                   if (HaveTheSameSigns(TempSigns, PatternSigns))
                                       continue;
                                   ISCompletePureRegular= false;
                                   return ;
                               }
               ISCompletePureRegular= true;
           }
           catch (Exception)
           {
               ISCompletePureRegular= false;
               return ;
           }
       }

       private bool HaveTheSameSigns(List<double> TempSigns, List<double> PatternSigns)
       {
           for (int i = 0; i < TempSigns.Count; i++)
               if (TempSigns[i].ToString()!=PatternSigns[i].ToString())
                   return false;
           return true;
       }

       private List<double> GetSigns(int i, int m, int n, int j, ref bool IsEqual)    
       {
           // m is the number of first typeand n is the number of second type comparing, j is the number of other
           List<double>[] type1 = GettypeedMatrix(PayOffs, i, m, j), type2 = GettypeedMatrix(PayOffs, i, n, j);
           List<int> Coeficient1 = new List<int>(), Coeficient2 = new List<int>(), FinalCoeficient = new List<int>();
           
           int[] capacities = new int[TheNumberOfPlayers];PlayerStrategiesCounts.CopyTo(capacities, 0);

           List<int> Nash1 = ComputeNash(type1, capacities)[0], Nash2 = ComputeNash(type2, capacities)[0];

           if (Nash1[i].ToString()==Nash2[i].ToString())
           {
               IsEqual = true; return null;
           }
           for (int k= 0; k < ThenumberofGames; k++)
           {
               Coeficient1.Add(GetCoeficient4Tetas(Nash1, i, k));
               Coeficient2.Add(GetCoeficient4Tetas(Nash2, i, k));
               FinalCoeficient.Add(Coeficient1[k]-Coeficient2[k]);
           }

           double sum = 0;
           List<double> Signs = new List<double>();
           
           for (int k = 0; k < Form1.EachPlayertypeCounts; k++)
           {
               for (int h = 0; h < ThenumberofGames; h++)
                   sum += FinalCoeficient[h] * types[k, h, i];
               Signs.Add(Math.Sign(sum));
               sum = 0;
           }
           return Signs;
       }

       private int GetCoeficient4Tetas(List<int> Nash, int i, int k)
       {//i is the ith player and k is the number of game(I mean the number of exterieme game)
           int row = 0;
           for (int j = 1; j < Nash.Count; j++)
               row += Nash[j] * PlayerStrategiesCounts[j - 1];
           row += Nash[0];
           return (int)PayOffs[row, i, k];
       }

       public void CPRChecking2(ref List<List<int>>BaysianNashEquilibrium)
       {
           try
           {
               List<List<int>>TempBaysianNAsh  = new List<List<int>>();
               for (int temp = 0; temp < TheNumberOfPlayers; temp++)
                   TempBaysianNAsh.Add(new List<int>());

               int upperLimit=(int)Math.Pow(ThenumberofGames,TheNumberOfPlayers-1);
               int typeCounts=types.GetLength(0);
               List<int> ConstantNash=new List<int> ();

               for (int i = 0; i < TheNumberOfPlayers; i++)
                   for (int w = 0,NashCount = 0,ConstantNashIndex=0;w < typeCounts; w++)
                   {
                       for (int others = 0; others < upperLimit; others++)
                       {
                           bool bBreak = true;
                           List<double>[] temptypeed = GettypeedMatrix2(PayOffs, i, w, others);
                           int[] capacities = new int[TheNumberOfPlayers];
                           PlayerStrategiesCounts.CopyTo(capacities, 0);
                           List<List<int>> TempNash = ComputeNash(temptypeed, capacities);
                           if (others == 0)
                           {
                               ConstantNash = TempNash[ConstantNashIndex];
                               NashCount = TempNash.Count;
                           }
                           else
                           {
                               foreach (List<int> item in TempNash)
                                   if (ConstantNash[i] == item[i])
                                   {
                                       bBreak = false;
                                       break;
                                   }
                               if (bBreak)
                               {
                                   if (ConstantNashIndex == NashCount - 1)
                                   {
                                       ISCompletePureRegular= false; BaysianNashEquilibrium = null; return;
                                   }
                                   ++ConstantNashIndex; others = -1;//-1 neveshtam ta tuye edameye halqe others++ beshe va meqdaresh beshe 0, yani az awal dobare halqe ejra she !
                               }
                           }
                       }
                       TempBaysianNAsh[i].Add(ConstantNash[i]);
                   }
               ISCompletePureRegular= true;
               for (int i = 0; i < TheNumberOfPlayers; i++)
               {
                   //TempBaysianNAsh.Add(CommonNashes4Extriemetypes[i]);
               }
               BaysianNashEquilibrium=TempBaysianNAsh;
           }
           catch (Exception)
           {
               BaysianNashEquilibrium = null;
               ISCompletePureRegular=false;
           }
       }

       private List<double>[] GettypeedMatrix2(double[, ,] PayOffs, int i, int m, int others)
       {
           List<int> Tetas = BaseGame_CPR(others);
           Tetas.Insert(i, m);
           List<double>[] Ans = new List<double>[PayOffs.GetLength(0)];
           int upperlimit = Ans.GetLength(0);
           for (int temp = 0; temp < upperlimit; temp++)
               Ans[temp] = new List<double>();

           for (int n = 0; n < upperlimit; n++)
               for (int h = 0; h < TheNumberOfPlayers; h++)
                   if (h != i)
                   {
                       double temp = PayOffs[n, h, Tetas[h]];
                       Ans[n].Add(temp);
                   }
                   else
                   {
                       double temp = 0;
                       for (int g = 0; g < ThenumberofGames; g++)
                           temp += types[m, g, h] * PayOffs[n, h, g];
                       Ans[n].Add(temp);
                   }
           return Ans;
       }

       internal void GetBaysianEQ(ref List<List<int>> BaysianNash)
       {
           if (ThenumberofGames > 2)
               CPRChecking2(ref BaysianNash);
           //if (ThenumberofGames == 2)
             //  BaysianNash=CheckBaysianNash4DoubleGame();
       }

       public void GetBaysianNashes4MultipleGames(ref List<List<int>>[] BaysianNashes4MultiGame)
       {
           for (int i = 0,temp=0; i < TheNumberOfPlayers - 1; i++)
           {
               CalculateCommonNashes(AllNashes[temp], i,false);
               temp += TheNumberOfPlayers - 1 - i;
           }
           CalculateCommonNashes(AllNashes[AllNashes.Count-1], TheNumberOfPlayers-1,true);
           BaysianNashes4MultiGame = CommonNashes4Extriemetypes;
       }

       private void CalculateCommonNashes(List<List<int>>[,] Table, int p1,bool bIsLastPlayer)
       {
           for (int i = 0; i < ThenumberofGames; i++)
           {
               List<List<int>> Intersection = new List<List<int>>();
               for (int j = 0; j <ThenumberofGames; j++)
                   for (int row = 0; row < (int)Math.Pow(ThenumberofGames,TheNumberOfPlayers-2); row++)
                   {
                       List<List<int>> TempNashes = new List<List<int>>();
                       if (!bIsLastPlayer)
                           TempNashes = Table[row, ThenumberofGames * i + j];
                       else
                           TempNashes = Table[row, i + j * ThenumberofGames];
                       if (j==0&&row==0)
                       {
                           Intersection = TempNashes;
                           continue;
                       }
                       Intersection = GetIntersection2(Intersection, TempNashes, p1);
                   }
               List<int> temp = new List<int>();
               foreach (List<int>  x in Intersection)
                   if (!temp.Contains(x[p1]))
                       temp.Add(x[p1]);
               CommonNashes4Extriemetypes[p1][i] = temp;
           }
       }

       private List<List<int>> GetIntersection2(List<List<int>> l1, List<List<int>> l2, int p1)
       {
           List<List<int>> Temp = new List<List<int>>();
           foreach (List<int>  x in l1)
               foreach (List<int>  y in l2)
                   if (x[p1]==y[p1])
                   {
                       Temp.Add(x);
                       break;
                   }
           return Temp;
       }
    }
}