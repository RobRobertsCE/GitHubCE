using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbVersionLibrary
{
    public class DbBuildVersion : DbVersion
    {
        public IList<DbUpgradeFile> Files { get; set; }
        
        public DbUpgradeFile BuildUpgradeVbFile { get; set; }

        public string UpgradeClassName
        {
            get
            {
                return String.Format("Upgrade{0}_{1}_{2}", VersionNumber.Major, VersionNumber.Minor, VersionNumber.Build);
            }
        }

        public bool IsUpgradeVersion
        {
            get
            {
                return (VersionNumber.Build == Constants.UpgradeBuildNumber);
            }
        }

        public string UpdatedVersionPath(int buildNumber)
        {
            return RootPath.Replace(Constants.UpgradeBuildNumber.ToString(), buildNumber.ToString());
        }

        public DbBuildVersion(Version versionNumber, string path) :base(versionNumber, path)
        {
            InitializeDbBuildVersion();
        }

        public DbBuildVersion(string path) : base(path)
        {
            InitializeDbBuildVersion();
        }

        private void InitializeDbBuildVersion()
        {
            BuildUpgradeVbFile = GetUpgradeFile(this);
            Files = GetFiles();
        }

        protected virtual internal DbUpgradeFile GetUpgradeFile(DbBuildVersion version)
        {
            var upgradeFileName = String.Format("Upgrade.{0}.vb", version.VersionNumber.MajorMinorBuildVersion().ToString());
            var upgradeFullPath = System.IO.Path.Combine(version.RootPath, upgradeFileName);
            var upgradeFile = new DbUpgradeFile()
            {
                FullPath = upgradeFullPath,
                FileName = upgradeFileName,
                Content = System.IO.File.ReadAllText(upgradeFullPath)
            };
            return upgradeFile;
        }
        
        protected virtual internal IList<DbUpgradeFile> GetFiles()
        {
            var files = new List<DbUpgradeFile>();
            foreach (var fullFilePath in System.IO.Directory.GetFiles(RootPath).Where(f=>f != BuildUpgradeVbFile.FullPath))
            {
                files.Add(new DbUpgradeFile(fullFilePath));
            }
            return files;
        }

        public override string ToString()
        {
            return VersionNumber.ToString();
        }
    }
}
