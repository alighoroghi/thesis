using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CPR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new InputForm());
            //Application.Run(new Form1());
            Application.Run(new DecisionForm());
        }
    }
}