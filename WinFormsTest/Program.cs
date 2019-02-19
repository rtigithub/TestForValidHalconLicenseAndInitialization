using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace WinFormsTest
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
            try
            {
                HSystem.GetSystem("version");
            }
            catch (HOperatorException hEx)
            {
                var messageBoxResult = MessageBox.Show($"HALCON unable to initialize. Please check if license and dongle are installed correctly.\r\n{hEx.Message}", "HALCON Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(hEx.GetErrorCode());
            }
            Application.Run(new Form1());
        }
    }
}
