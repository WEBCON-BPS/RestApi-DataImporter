using System;
using System.Windows.Forms;
using WEBCON.BPS.Importer.Forms;

namespace WEBCON.BPS.Importer
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
            Application.Run(new ImporterMainForm());
        }
    }
}
