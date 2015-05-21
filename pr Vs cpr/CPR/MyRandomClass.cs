using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPR
{
    static class MyRandomClass
    {
        static Random Rnd = new Random();

        static public int RanNext(int minValue, int maxValue)
        {         
            return Rnd.Next(minValue, maxValue);
        }

        static public double RanNextDouble { get { return Rnd.NextDouble(); } set { } }
    }
}