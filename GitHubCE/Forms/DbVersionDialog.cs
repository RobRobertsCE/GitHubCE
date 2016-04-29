using GitHubCE.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitHubCE.Forms
{
    public partial class DbVersionDialog : Form
    {
        public DbVersionHelper VersionHelper { get; set; }

        public DbVersionDialog()
        {
            InitializeComponent();
        }
    }
}
