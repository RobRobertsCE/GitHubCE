using DbVersionLibrary;
using GitHubCE.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace GitHubCE.Advantage
{

    public class PatchHelper
    {
        #region consts
        // c:\users\rroberts\patchBackups\Advantage\16\16.2.21.215\04232016-1123\
        private const string AssmeblyBackupPathTemplate = @"C:\Users\{0}\PatchBackups\{1}\{2}\{3}\{4}\";
        private const string RepoPathTemplate = @"C:\Users\{0}\Source\Repos\{1}";
        private const string BinPathTemplate = @"C:\Users\{0}\Source\Repos\{1}\bin";
        private const string PatchFolderTemplate = @"\\ceserver\Development\Test Program Setups\{0}\{1}\Version {2}\Patch";
        private const string VersionFileTemplate = @"C:\Users\{0}\Source\Repos\{1}\src\version.txt";
        #endregion

        #region fields
        IList<FileInfo> _sourceAssemblies = new List<FileInfo>();
        IList<FileInfo> _targetAssemblies = new List<FileInfo>();
        DateTime _startupTimestamp;
        #endregion

        #region properties
        public PullRequestAssembyHelper AssemblyHelper { get; private set; }
        public Version PatchTargetVersion { get; set; }
        public DateTime BuildTimestampLimit { get; set; }
        #endregion

        #region read only properties
        public string RepoName
        {
            get
            {
                return AssemblyHelper.RepoName;
            }
        }
        public string WinUserName
        {
            get
            {
                return AssemblyHelper.WinUserName;
            }
        }
        public Version RepoVersion
        {
            get
            {
                var versionFileContent = File.ReadAllText(VersionFile);
                return new Version(versionFileContent);
            }
        }
        public string RepoFolder
        {
            get
            {
                return String.Format(RepoPathTemplate, WinUserName, RepoName);
            }
        }
        public string BinFolder
        {
            get
            {
                return String.Format(BinPathTemplate, WinUserName, RepoName);
            }
        }
        public string PatchFolder
        {
            get
            {
                return String.Format(PatchFolderTemplate, RepoName, RepoVersion.Major.ToString(), RepoVersion.ToString());
            }
        }
        public string VersionFile
        {
            get
            {
                return String.Format(VersionFileTemplate, WinUserName, RepoName);
            }
        }
        public string AssemblyBackupFolder
        {
            get
            {
                return String.Format(AssmeblyBackupPathTemplate, WinUserName, RepoName, PatchTargetVersion.Major, PatchTargetVersion, _startupTimestamp.ToString("yyyyMMdd-hhmm"));
            }
        }
        public IList<FileInfo> SourceAssemblies
        {
            get
            {
                if (null== _sourceAssemblies)
                    _sourceAssemblies = GetSourceAssmeblies();
                return _sourceAssemblies;
            }
        }
        #endregion

        #region ctor       
        public PatchHelper(PullRequestAssembyHelper assemblyHelper, Version patchTargetVersion)
        {
            this.AssemblyHelper = assemblyHelper;
            this.PatchTargetVersion = patchTargetVersion;
            this.BuildTimestampLimit = AssemblyHelper.PullRequest.Updated.DateTime.ToLocalTime();
            _startupTimestamp = DateTime.Now;
        }
        #endregion

        #region private
        public TaskResult ValidatePatchProcess()
        {
            var result = new TaskResult() { IsValid = true };
            // pull request merged?
            if (!AssemblyHelper.PullRequest.Merged)
            {
                result.AddError(String.Format("Pull Request {0} has not been merged yet.", AssemblyHelper.PullRequest.Id));
                // no further validation may be done. Bail...
                return result;
            }

            try
            {
                // repo at the correct version?
                if (PatchTargetVersion.Build == -1 && PatchTargetVersion.Revision == -1)
                {
                    if (RepoVersion.Major != PatchTargetVersion.Major || RepoVersion.Minor != PatchTargetVersion.Minor)
                    {
                        result.AddError(String.Format("Repo version, {0}, does match patch target version, {1}.", RepoVersion.ToString(), PatchTargetVersion.ToString()));
                        // no further validation may be done. Bail...
                        return result;
                    }
                    else
                    {
                        PatchTargetVersion = RepoVersion;
                    }
                }

                _sourceAssemblies = GetSourceAssmeblies();
                // assembly exists?                
                foreach (var assemblyFileName in _sourceAssemblies)
                {
                    if (!File.Exists(assemblyFileName.FullName))
                    {
                        result.AddError(String.Format("Built assembly {0} is not found.", assemblyFileName.FullName));
                    }
                    else
                    {
                        // versions correct?
                        var versInfo = FileVersionInfo.GetVersionInfo(assemblyFileName.FullName);
                        String fileVersion = versInfo.FileVersion;
                        String productVersion = versInfo.ProductVersion;

                        //example for own display version string, built of the four version parts:
                        String myVers = String.Format("V{0}.{1}.{2} build {3}", versInfo.FileMajorPart, versInfo.FileMinorPart,
                                                                                 versInfo.FileBuildPart, versInfo.FilePrivatePart);

                        Console.WriteLine("{0}: File Version:{1}; Product Version:{2}; myVers:{3}; IsDebug:{4}", assemblyFileName.FullName, fileVersion, productVersion, myVers, versInfo.IsDebug);
                        if (PatchTargetVersion.ToString() != fileVersion)
                        {
                            result.AddError(String.Format("Built assembly {0} is at version {1}, patching to version {2}.", assemblyFileName, fileVersion, PatchTargetVersion.ToString()));
                        }

                        // built since request made?
                        var binAssemblyFileInfo = new FileInfo(assemblyFileName.FullName);
                        DateTime binAssemblyLastModified = binAssemblyFileInfo.LastWriteTime;
                        if (BuildTimestampLimit > binAssemblyLastModified)
                        {
                            result.AddError(String.Format("Built assembly {0} is out of date. Last build was {1}, build cutoff timestamp is {2}.", assemblyFileName.FullName, binAssemblyLastModified, BuildTimestampLimit));
                        }

                        // debug?
                        if (versInfo.IsDebug)
                        {
                            result.AddError(String.Format("Built assembly {0} is a DEBUG assembly.", assemblyFileName.FullName));
                        }

                        var targetAssembly = Path.Combine(PatchFolder, assemblyFileName.Name);
                        if (File.Exists(targetAssembly))
                        {
                            result.AddDebug(String.Format("Assembly {0} exists in patch folder.", targetAssembly));
                            // target assembly not newer than source assembly?
                            var patchFolderAssemblyFileInfo = new FileInfo(targetAssembly);

                            if (binAssemblyLastModified < patchFolderAssemblyFileInfo.LastWriteTime)
                            {
                                result.AddError(String.Format("Built assembly {0} is out of date. Assembly currently in Patch folder has more recent build timestamp, {1}.", assemblyFileName.Name, binAssemblyLastModified, patchFolderAssemblyFileInfo.LastWriteTime));
                            }
                            // target assembly build timestamp same as source? (same build time and version)
                            if (binAssemblyLastModified == patchFolderAssemblyFileInfo.LastWriteTime)
                            {
                                result.AddError(String.Format("Assembly {0} has the same build timestamp in Patch and Bin folders.", assemblyFileName.Name));
                            }
                        }

                        // confirm commit(s) in current branch.


                        if (!Directory.Exists(AssemblyBackupFolder))
                        {
                            var backupInfo = Directory.CreateDirectory(AssemblyBackupFolder);
                            if (null==backupInfo)
                            {
                                result.AddError(String.Format("Error creating backup directory {0}.", AssemblyBackupFolder));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex.ToString());
            }
            return result;
        }

        IList<FileInfo> GetSourceAssmeblies()
        {
            var sourceFiles = new List<FileInfo>();

            foreach (var assemblyFileName in AssemblyHelper.AssemblyFiles)
            {
                if (!assemblyFileName.Contains("AdvUpgrade"))
                {
                    var builtAssemblyFilePath = Path.Combine(BinFolder, assemblyFileName);
                    sourceFiles.Add(new FileInfo(builtAssemblyFilePath));
                }
            }

            return sourceFiles;
        }

        IList<FileInfo> GetExistingTargetAssmeblies()
        {
            var targetFiles = new List<FileInfo>();


            return targetFiles;
        }
        #endregion

    }
}
