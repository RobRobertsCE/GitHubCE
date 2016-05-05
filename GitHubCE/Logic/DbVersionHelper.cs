using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubCE.Logic
{
    public class DbVersionHelper
    {
        #region fields
        private bool _isDebug = true;
        #endregion

        #region props
        public string RepoName { get; private set; }
        public string WinUserName { get; private set; }
        public Version CurrentDbVersion { get; private set; }
        public Version NewDbVersion { get; private set; }
        public Version PendingDbVersion { get; private set; }
        public Version VersionFileVersion { get; private set; }
        public string PendingBuildNumber
        {
            get
            {
                return PendingDbVersion.Build.ToString();
            }
        }
        public string NewBuildNumber
        {
            get
            {
                return NewDbVersion.Build.ToString();
            }
        }

        protected string UpgradeProjectFolder
        {
            get
            {
                return String.Format(@"C:\Users\{0}\Source\Repos\{1}\src\AdvUpgrade\AdvUpgrade\", WinUserName, RepoName);
            }
        }
        protected string UpgradeProjectVbProjectFile
        {
            get
            {
                return String.Format(@"C:\Users\{0}\Source\Repos\{1}\src\AdvUpgrade\AdvUpgrade\AdvUpgrade.vbproj", WinUserName, RepoName);
            }
        }
        protected string VersionFile
        {
            get
            {
                return String.Format(@"C:\Users\{0}\Source\Repos\{1}\src\version.txt", WinUserName, RepoName);
            }
        }
        public string MinorVersionFolder
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\
                return String.Format(@"{0}{1}.{2}\", UpgradeProjectFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor);
            }
        }
        public string MinorVersionVbFile
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\Upgrade.16.3.vb
                return String.Format(@"{0}Upgrade.{1}.{2}.vb", MinorVersionFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor);
            }
        }

        public string PendingVersionBuildFolder
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\16.3.100\
                return String.Format(@"{0}{1}.{2}.100\", MinorVersionFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor);
            }
        }
        public string PendingVersionBuildVbFile
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\16.3.100\Upgrade.16.3.100.vb
                return String.Format(@"{0}Upgrade.{1}.{2}.100.vb", PendingVersionBuildFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor);
            }
        }

        public string NewVersionBuildFolder
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\16.3.24
                return String.Format(@"{0}{1}.{2}.{3}\", MinorVersionFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor, NewDbVersion.Build);
            }
        }
        public string NewVersionBuildVbFile
        {
            get
            {
                // C:\Users\rroberts\Source\Repos\Advantage\src\AdvUpgrade\AdvUpgrade\16.3\16.3.24\Upgrade.16.3.24.vb
                return String.Format(@"{0}Upgrade.{1}.{2}.{3}.vb", NewVersionBuildFolder, CurrentDbVersion.Major, CurrentDbVersion.Minor, NewDbVersion.Build);
            }
        }

        public IList<string> PendingBuildFiles { get; private set; }
        public IList<string> NewBuildFiles { get; private set; }

        public string NewUpgradeClassName
        {
            get
            {
                return String.Format("Upgrade{0}_{1}_{2}", NewDbVersion.Major, NewDbVersion.Minor, NewDbVersion.Build);
            }
        }
        public string PendingUpgradeClassName
        {
            get
            {
                return String.Format("Upgrade{0}_{1}_{2}", PendingDbVersion.Major, PendingDbVersion.Minor, PendingDbVersion.Build);
            }
        }

        bool RequeresUpdate
        {
            get
            {
                return File.Exists(PendingVersionBuildVbFile);
            }
        }
        #endregion

        #region ctor
        public DbVersionHelper(string repoName, string winUserName)
        {
            this.RepoName = repoName;
            this.WinUserName = winUserName;
            ReadUpgradeProject();
        }
        #endregion

        #region public
        public TaskResult UpdateProject()
        {
            var result = new TaskResult() { IsValid = true };
            try
            {
                result = ValidateVersionIncrement(result);
                if (!result.IsValid)
                    return result;

                result = BackupFiles(result);
                if (!result.IsValid)
                    return result;

                result = UpdateBuildFiles(result);
                if (!result.IsValid)
                    return result;

                result = UpdateMinorVersionFile(result);
                if (!result.IsValid)
                    return result;

                result = RunSetDbVersion(result);
                if (!result.IsValid)
                    return result;
            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }
        #endregion

        #region private
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
        #endregion

        #region private [update]
        /// <summary>
        /// Renames all of the files in the build directory, and then renames the directory.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        TaskResult UpdateBuildFiles(TaskResult result)
        {
            try
            {
                var pendingBuildFileDirectory = Path.GetDirectoryName(PendingVersionBuildVbFile);

                // rename the files in the build directory.
                foreach (string pendingSqlBuildFile in PendingBuildFiles)
                {
                    if (pendingSqlBuildFile.ToUpper().EndsWith("SQL"))
                    {
                        // verify embedded resource
                        result = VerifyEmbeddedResource(result, pendingSqlBuildFile);
                        if (!result.IsValid)
                            return result;
                    }

                    var pendingBuildFileName = Path.GetFileName(pendingSqlBuildFile);
                    var newBuildFileTitle = pendingBuildFileName.Replace(PendingBuildNumber, NewBuildNumber);
                    var newBuildFile = Path.Combine(pendingBuildFileDirectory, newBuildFileTitle);
                    if (_isDebug)
                    {
                        Console.WriteLine("Renaming file {0} to {1}", pendingSqlBuildFile, newBuildFile);
                    }
                    // rename the script
                    File.Move(pendingSqlBuildFile, newBuildFile);
                }
                // update the build vb file content.
                UpdateBuildVersionVbFileContent(result);
                if (!result.IsValid)
                    return result;

                var newBuildVbFile = Path.Combine(pendingBuildFileDirectory, Path.GetFileName(NewVersionBuildVbFile));
                if (_isDebug)
                {
                    Console.WriteLine("Renaming file {0} to {1}", PendingVersionBuildVbFile, newBuildVbFile);
                }
                // rename the build file.
                File.Move(PendingVersionBuildVbFile, newBuildVbFile);

                if (_isDebug)
                {
                    Console.WriteLine("Renaming directory {0} to {1}", PendingVersionBuildFolder, NewVersionBuildFolder);
                }
                // rename the build directory
                Directory.Move(PendingVersionBuildFolder, NewVersionBuildFolder);
            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        /// <summary>
        /// Updates the build-specific vb file.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        TaskResult UpdateBuildVersionVbFileContent(TaskResult result)
        {
            try
            {
                var pendingFileContent = File.ReadAllText(PendingVersionBuildVbFile);
                // update the class name.
                // Upgrade16_4_100
                var newFileContent = pendingFileContent.Replace(PendingUpgradeClassName, NewUpgradeClassName);
                // update the version declaration
                // Private Shared ReadOnly VersionConst As New Version(16, 4, 100)
                var pendingVersionDeclaration = String.Format(@"Private Shared ReadOnly VersionConst As New Version({0}, {1}, {2})", PendingDbVersion.Major, PendingDbVersion.Minor, PendingDbVersion.Build);
                var newVersionDeclaration = String.Format(@"Private Shared ReadOnly VersionConst As New Version({0}, {1}, {2})", NewDbVersion.Major, NewDbVersion.Minor, NewDbVersion.Build);
                newFileContent = newFileContent.Replace(pendingVersionDeclaration, newVersionDeclaration);

                if (_isDebug)
                {
                    Console.WriteLine("Replacing File Content\r\n{0}\r\n--------------- with ---------------\r\n{1}", pendingFileContent, newFileContent);
                }

                File.WriteAllText(PendingVersionBuildVbFile, newFileContent);
            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        /// <summary>
        /// Updates the Minor version vb file.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        TaskResult UpdateMinorVersionFile(TaskResult result)
        {
            try
            {
                var fileContent = File.ReadAllText(MinorVersionVbFile);
                // update the class name.
                //Public Class Upgrade16_4_100
                if (fileContent.Contains(PendingUpgradeClassName))
                {
                    fileContent = fileContent.Replace(PendingUpgradeClassName, NewUpgradeClassName);
                }
                else
                {
                    // need to add the new class to the end of the list.
                    fileContent = BuildMinorVersionVbFile();
                }
                File.WriteAllText(MinorVersionVbFile, fileContent);
            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        /// <summary>
        /// Builds the vb file for the minor version folder.
        /// </summary>
        /// <returns></returns>
        string BuildMinorVersionVbFile()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"' ReSharper disable once InconsistentNaming");
            sb.AppendLine(@"' ReSharper disable once CheckNamespace");
            sb.AppendFormat("Public Class Upgrade{0}_{1}\r\n", NewDbVersion.Major, NewDbVersion.Minor);
            sb.AppendLine(@"    Inherits UpgradeSet");
            sb.AppendLine();
            sb.AppendLine(@"    Public Sub New()");
            sb.AppendLine(@"        MyBase.New(New UpgradeBase() {");
            foreach (var buildDirectory in Directory.GetDirectories(MinorVersionFolder))
            {
                var buildDirectoryVersion = new Version(Path.GetFileName(buildDirectory)); // GetFileName gets the directory name from a directory path.
                if (buildDirectoryVersion == NewDbVersion)
                {
                    // no comma for the last one.
                    sb.AppendFormat("                       New Upgrade{0}_{1}_{2}()\r\n", buildDirectoryVersion.Major, buildDirectoryVersion.Minor, buildDirectoryVersion.Build);
                }
                else
                {
                    //                       New Upgrade16_4_0(),
                    sb.AppendFormat("                       New Upgrade{0}_{1}_{2}(),\r\n", buildDirectoryVersion.Major, buildDirectoryVersion.Minor, buildDirectoryVersion.Build);
                }
            }
            sb.AppendLine(@"                   })");
            sb.AppendLine(@"    End Sub");
            sb.AppendLine();
            sb.AppendLine(@"End Class");

            return sb.ToString();
        }

        /// <summary>
        /// Validates the version number increment.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        TaskResult ValidateVersionIncrement(TaskResult result)
        {
            try
            {
                if (CurrentDbVersion.Major != VersionFileVersion.Major || CurrentDbVersion.Minor != VersionFileVersion.Minor || CurrentDbVersion.Build != VersionFileVersion.Build)
                    result.AddError("Version file and AdvUpgrade project out of sync!");
            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        /// <summary>
        /// Executes the SetVersion script
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        TaskResult RunSetDbVersion(TaskResult result)
        {
            try
            {
                //Process.Start(@"C:\Users\rroberts\Source\Repos\Advantage\tools\version\SetVersion.ps1 -IncrementDb");
            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        TaskResult VerifyEmbeddedResource(TaskResult result, string fileName)
        {
            try
            {
                var fileContent = File.ReadAllText(UpgradeProjectVbProjectFile);
                var targetFileName = Path.GetFileName(fileName);
                //var targetFileLine = String.Format(@"xxx", 0, 1, 2, 3);
                var targetFileLine = String.Format("<EmbeddedResource Include=\"{0}.{1}\\{0}.{1}.{2}\\{3}\" />", PendingDbVersion.Major, PendingDbVersion.Minor, PendingDbVersion.Build, targetFileName);
                //<EmbeddedResource Include="16.4\16.4.5\NotifyEventTypes.16.4.5.sql" />
                //<EmbeddedResource Include="{0}.{1}\{0}.{1}.{2}\{3}" />
                if (fileContent.Contains(targetFileLine))
                {
                    var newFileLine = String.Format("<EmbeddedResource Include=\"{0}.{1}\\{0}.{1}.{2}\\{3}\" />", NewDbVersion.Major, NewDbVersion.Minor, NewDbVersion.Build, targetFileName);
                    fileContent = fileContent.Replace(targetFileLine, newFileLine);
                    File.WriteAllText(UpgradeProjectVbProjectFile, fileContent);
                }
                else
                {
                    result.AddError(String.Format("{0} is not set as an embedded resource!", targetFileName));
                }
            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        TaskResult UpdateProjectFileReferences(TaskResult result)
        {
            try
            {
                // For the build-level vb file:
                // Change
                //< Compile Include = "16.4\16.4.100\Upgrade.16.4.100.vb" /> 
                // To
                //< Compile Include = "16.4\16.4.6\Upgrade.16.4.6.vb" />   

                // For Each build-level sql file:

                // Check for:
                //<Content Include="16.4\16.4.100\NotifyEventTypes.16.4.100.sql" />

                // Change
                //<EmbeddedResource Include="16.4\16.4.100\NotifyEventTypes.16.4.100.sql" />
                // To
                //<EmbeddedResource Include="16.4\16.4.6\NotifyEventTypes.16.4.6.sql" />

            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        TaskResult BackupFiles(TaskResult result)
        {
            try
            {
                var backupDir = @"c:\Backups\DbVersionHelper\";

                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }

                var backupVersionDir = Path.Combine(backupDir, DateTime.Now.ToString("mmDDyyyy") + "-" + NewDbVersion.ToString());
                if (_isDebug)
                {
                    Console.WriteLine("Backing up directory {0}\r\n--------------- to ---------------\r\n{1}", PendingVersionBuildFolder, backupVersionDir);
                }
                DirectoryCopy(PendingVersionBuildFolder, backupVersionDir, true);
            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        TaskResult RestoreBackupFiles(TaskResult result)
        {
            try
            {

            }
            catch (Exception ex)
            {
                result.AddException(ex);
            }
            return result;
        }
        #endregion
    }
}
