using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbVersionLibrary
{
    public class DbMinorVersion : DbVersion
    {
        public virtual string UpgradeClassName
        {
            get
            {
                return String.Format("Upgrade{0}_{1}", VersionNumber.Major, VersionNumber.Minor);
            }
        }

        public DbUpgradeFile UpgradeVbFile { get; set; }

        public IList<DbBuildVersion> Builds { get; set; }

        public bool RequiresUpgrade
        {
            get
            {
                return (null != UpgradeBuildVersion);
            }
        }

        public DbBuildVersion UpgradeBuildVersion
        {
            get
            {
                return Builds.FirstOrDefault(b => b.IsUpgradeVersion);
            }
        }

        public DbBuildVersion CurrentBuildVersion
        {
            get
            {
                return Builds.OrderByDescending(b => b.VersionNumber).FirstOrDefault(b => !b.IsUpgradeVersion);
            }
        }

        protected DbMinorVersion()
        {

        }

        public DbMinorVersion(string path) : base(path)
        {
            this.RootPath = path;
            var minorVersionFolder = System.IO.Path.GetDirectoryName(RootPath);
            this.VersionNumber = Version.Parse(minorVersionFolder);
            Initialize();
        }

        public DbMinorVersion(Version versionNumber, string path) : base(versionNumber, path)
        {
            this.RootPath = path;
            this.VersionNumber = versionNumber;
            Initialize();
        }

        private void Initialize()
        {
            this.Builds = new List<DbBuildVersion>();
            this.UpgradeVbFile = GetUpgradeFile(this);
        }

        protected virtual internal DbUpgradeFile GetUpgradeFile(DbVersion version)
        {
            var upgradeFileName = String.Format("Upgrade.{0}.vb", version.VersionNumber.MajorMinorVersion().ToString());
            var upgradeFullPath = System.IO.Path.Combine(version.RootPath, upgradeFileName);
            var upgradeFile = new DbUpgradeFile()
            {
                FullPath = upgradeFullPath,
                FileName = upgradeFileName,
                Content = System.IO.File.ReadAllText(upgradeFullPath)
            };
            return upgradeFile;
        }

        public override string ToString()
        {
            return VersionNumber.ToString();
        }
    }
}
