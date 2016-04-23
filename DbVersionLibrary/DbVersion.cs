using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbVersionLibrary
{
    public class DbVersion
    {
        public Version VersionNumber { get; set; }

        public string RootPath { get; set; }

        //public virtual string ClassName
        //{
        //    get
        //    {
        //        return String.Format("Upgrade{0}_{1}", VersionNumber.Major, VersionNumber.Minor);
        //    }
        //}

        //public DbUpgradeFile UpgradeVbFile { get; set; }

        //public IList<DbBuildVersion> Builds { get; set; }
        
        //public bool RequiresUpgrade
        //{
        //    get
        //    {
        //        return Builds.Any(b => b.IsUpgradeVersion);
        //    }
        //}

        protected DbVersion()
        {

        }

        public DbVersion(string path)
        {
            this.RootPath = path;
            var minorVersionFolder = System.IO.Path.GetDirectoryName(RootPath);
            this.VersionNumber = Version.Parse(minorVersionFolder);
            //Initialize();
        }

        public DbVersion(Version versionNumber, string path)
        {
            this.RootPath = path;
            this.VersionNumber = versionNumber;
            //Initialize();
        }

        //private void Initialize()
        //{
        //    this.Builds = new List<DbBuildVersion>();
        //    this.UpgradeVbFile = GetUpgradeFile(this);
        //}

        //protected virtual internal DbUpgradeFile GetUpgradeFile(DbVersion version)
        //{
        //    var upgradeFileName = String.Format("Upgrade.{0}.vb", version.VersionNumber.MajorMinorVersion().ToString());
        //    var upgradeFullPath = System.IO.Path.Combine(version.RootPath, upgradeFileName);
        //    var upgradeFile = new DbUpgradeFile()
        //    {
        //        FullPath = upgradeFullPath,
        //        FileName = upgradeFileName,
        //        Content = System.IO.File.ReadAllText(upgradeFullPath)
        //    };
        //    return upgradeFile;
        //}
    }
}
