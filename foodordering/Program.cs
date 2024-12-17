using System;
using System.Windows.Forms;

namespace foodordering
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Form1.Instance);  /*Form1.Instance*/
            //SearchResult frm = new SearchResult();
            //Application.Run(frm);
        }
    }
}
