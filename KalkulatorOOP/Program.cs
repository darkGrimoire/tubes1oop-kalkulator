using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorException;
using KalkulatorOOP;

//namespace KalkulatorOOP
//{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        //Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new Form1());

        //---DEBUGGING CONSOLE HERE---//

        Parser parser = new Parser("-√3");
        parser.Peek();
        //Console.WriteLine(parser.Solve());
    }
    }
//}
