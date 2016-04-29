using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubCE.Logic
{
    public class DbVersionHelper
    {
        public string RepoName { get; private set; }
        public string WinUserName { get; private set; }
        public Version CurrentDbVersion { get; private set; }
        public Version NewDbVersion { get; private set; }
        public Version PendingDbVersion { get; private set; }
        public Version VersionFileVersion { get; private set; }

        protected string UpgradeProjectFolder
        {
            get
            {
                return String.Format(@"C:\Users\{0}\Source\Repos\{1}\src\AdvUpgrade\AdvUpgrade\", WinUserName, RepoName);
            }
        }
        protected string VersionFile
        {
            get
            {
                return String.Format(@"C:\Users\{0}\Source\Repos\{1}\src\version.txt", WinUserName, RepoName);
            }
        }
        protected string MinorVersionFolder
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\
                return String.Format(@"{0}{1}.{2}\", UpgradeProjectFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor);
            }
        }
        protected string MinorVersionVbFile
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\Upgrade.16.3.vb
                return String.Format(@"{0}Upgrade.{1}.{2}.vb", MinorVersionFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor);
            }
        }

        protected string PendingVersionBuildFolder
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\16.3.100\
                return String.Format(@"{0}{1}.{2}.100\", MinorVersionFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor);
            }
        }
        protected string PendingVersionBuildVbFile
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\16.3.100\Upgrade.16.3.100.vb
                return String.Format(@"{0}Upgrade.{1}.{2}.100.vb", PendingVersionBuildFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor);
            }
        }

        protected string NewVersionBuildFolder
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\16.3.24
                return String.Format(@"{0}{1}.{2}.{3}\", MinorVersionFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor, NewDbVersion.Build);
            }
        }
        protected string NewVersionBuildVbFile
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\16.3.24\Upgrade.16.3.24.vb
                return String.Format(@"{0}Upgrade.{1}.{2}.{3}.vb", NewVersionBuildFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor, NewDbVersion.Build);
            }
        }

        protected IList<string> PendingBuildFiles { get; private set; }
        protected IList<string> NewBuildFiles { get; private set; }

        bool RequeresUpdate
        {
            get
            {
                return File.Exists(PendingVersionBuildVbFile);
            }
        }

        public DbVersionHelper(string repoName, string winUserName)
        {
            this.RepoName = repoName;
            this.WinUserName = winUserName;
            ReadUpgradeProject();
        }

        void ReadUpgradeProject()
        {
            // populate the vars.
            VersionFileVersion = GetVersionFileVersion();
            CurrentDbVersion = GetCurrentDbVersion();
            PendingDbVersion = new Version(CurrentDbVersion.Major, CurrentDbVersion.Minor, 100);
            NewDbVersion = new Version(CurrentDbVersion.Major, CurrentDbVersion.Minor, CurrentDbVersion.Build + 1);
            PendingBuildFiles = GetPendingBuildFiles();
            NewBuildFiles = GetNewBuildFiles(PendingBuildFiles);
        }

        Version GetVersionFileVersion()
        {
            var versionFileContent = File.ReadAllText(VersionFile);
            return new Version(versionFileContent);
        }
        Version GetCurrentDbVersion()
        {
            Version maxDbVersion = new Version(0, 0, 0, 0);
            string maxMinorDbVersionDirectory = "";
            foreach (var minorDirectory in Directory.GetDirectories(UpgradeProjectFolder))
            {
                if (minorDirectory.Contains('.'))
                {
                    string minorDirectoryPath = Path.GetFullPath(minorDirectory).TrimEnd(Path.DirectorySeparatorChar);
                    string minorDirectoryName = Path.GetFileName(minorDirectoryPath);
                    Version directoryVersion = new Version(minorDirectoryName);
                    if (directoryVersion > maxDbVersion)
                    {
                        maxDbVersion = directoryVersion;
                        maxMinorDbVersionDirectory = minorDirectory;
                    }
                }
            }
            foreach (var minorDirectory in Directory.GetDirectories(maxMinorDbVersionDirectory))
            {
                string minorDirectoryPath = Path.GetFullPath(minorDirectory).TrimEnd(Path.DirectorySeparatorChar);
                string minorDirectoryName = Path.GetFileName(minorDirectoryPath);
                Version directoryVersion = new Version(minorDirectoryName);
                if (directoryVersion.Build != 100 && directoryVersion > maxDbVersion)
                {
                    maxDbVersion = directoryVersion;
                    maxMinorDbVersionDirectory = minorDirectory;
                }
            }
            return maxDbVersion;
        }

        IList<string> GetPendingBuildFiles()
        {
            var pendingFiles = new List<string>();
            foreach (var pendingFile in Directory.GetFiles(PendingVersionBuildFolder))
            {
                if (!pendingFile.Contains("100.vb"))
                {
                    pendingFiles.Add(pendingFile);
                }
            }
            return pendingFiles;
        }

        IList<string> GetNewBuildFiles(IList<string> pendingFiles)
        {
            var newFiles = new List<string>();
            var pendingVersionString = String.Format("{0}.{1}.100", NewDbVersion.Major, NewDbVersion.Minor);
            var newVersionString = String.Format("{0}.{1}.{2}", NewDbVersion.Major, NewDbVersion.Minor, NewDbVersion.Build);
            foreach (var pendingFile in pendingFiles)
            {
                var newFile = pendingFile.Replace(pendingVersionString, newVersionString);
                newFiles.Add(newFile);
            }
            return newFiles;
        }

        TaskResult UpdateBuildFiles()
        {
            var result = new TaskResult() { IsValid = true };
            try
            {

            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        TaskResult UpdateMinorVersionFile()
        {
            var result = new TaskResult() { IsValid = true };
            try
            {

            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        TaskResult ValidateVersionIncrement()
        {
            var result = new TaskResult() { IsValid = true };
            try
            {

            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        TaskResult RunSetDbVersion()
        {
            var result = new TaskResult() { IsValid = true };
            try
            {

            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        TaskResult VerifyEmbeddedResource()
        {
            var result = new TaskResult() { IsValid = true };
            try
            {

            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        TaskResult BackupFiles()
        {
            var result = new TaskResult() { IsValid = true };
            try
            {

            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        TaskResult RestoreBackupFiles()
        {
            var result = new TaskResult() { IsValid = true };
            try
            {

            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

    }
}
