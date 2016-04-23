using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbVersionLibrary
{
    public class DbUpgradeFile
    {

        public string FullPath { get; set; }

        public string FileName { get; set; }

        public string Content { get; set; }

        public DbUpgradeFile()
        {

        }

        public DbUpgradeFile(String fullPath)
        {
            this.FullPath = fullPath;
            this.FileName = System.IO.Path.GetFileName(fullPath);
            this.Content = System.IO.File.ReadAllText(fullPath);
        }

        public string UpdatedVersionPath(int buildNumber)
        {
            var parentFolder = System.IO.Path.GetDirectoryName(FullPath);
            var newFileName = System.IO.Path.Combine(parentFolder, FileName.Replace(Constants.UpgradeBuildNumber.ToString(), buildNumber.ToString()));
            return newFileName;
        }
    }
}
