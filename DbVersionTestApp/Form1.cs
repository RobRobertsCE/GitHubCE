using DbVersionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbVersionTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var lib = new DbVersionLibrary.DbVersionHelper();
                var versionFileVersion = lib.GetVersionFileVersion();
                Console.WriteLine("Current Version.txt Version: {0}", versionFileVersion.ToString());
                var currentMinor = lib.GetLatestMinorVersion();
                Console.WriteLine("Current AdvUpgrade Minor Version: {0}", currentMinor.VersionNumber.ToString());                
                Console.WriteLine("Current AdvUpgrade Build Version: {0}", currentMinor.CurrentBuildVersion.VersionNumber.ToString());
                if (currentMinor.RequiresUpgrade)
                {
                    Console.WriteLine("UPGRADE REQUIRED!");
                }
                else
                {
                    Console.WriteLine("No upgrade required.");
                }
                //lib.UpdateDbBuildVersion(currentMinor);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btnVersionCalculator_Click(object sender, EventArgs e)
        {
            try
            {
                var verDate = this.dtVersionDate.Value;
                var versionHelper = new BranchVersionHelper();
                var result = versionHelper.GetVersionOnDate(verDate);
                this.txtVersion.Text = result.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
