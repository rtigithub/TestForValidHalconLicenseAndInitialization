using System;
using System.Windows.Forms;
using HalconDotNet;

namespace WinFormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartupLicenseTest();
        }
        private bool StartupLicenseTest()
        {
            bool status = false;

            HImage testImage = new HImage();
            HRegion testRegion = new HRegion();

            try
            {
                // This will fail if we don't have a proper license
                testImage = new HImage("byte", 16, 16);
                testRegion = testImage.Threshold(0.0, 255.0);

                HSystem.SetSystem("temporary_mem_cache", "false");  // This saves RAM significantly!
                HSystem.SetSystem("global_mem_cache", "idle");      // Likewise

                status = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + DateTime.Now);    // Display errors if any in a listbox
            }
            finally
            {
                testImage.Dispose();
                testRegion.Dispose();
            }

            return status;
        }

    }
}
