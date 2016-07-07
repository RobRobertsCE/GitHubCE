using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitHubCE.Advantage
{
    public class PullRequestAssembyHelper
    {
        #region consts
        private const string VBFileExtension = ".vb";
        private const string CSharpFileExtension = ".cs";
        private const string VBProjectFileFilter = "*.vbproj";
        private const string CSharpProjectFileFilter = "*.csproj";
        private const string RepoPathTemplate = @"C:\Users\{0}\Source\Repos\{1}";
        #endregion

        #region enums
        private enum DotNetLanguage
        {
            Unknown,
            VB,
            CSharp
        }
        #endregion

        #region fields
        IList<string> _assemblies = new List<string>();
        IList<string> _changedFiles { get; set; }
        #endregion

        #region properties
        public string RepoName { get; private set; }
        public string WinUserName { get; private set; }
        public PullRequestView PullRequest { get; private set; }
        #endregion

        #region read only properties
        public string RepoFolder
        {
            get
            {
                return String.Format(RepoPathTemplate, WinUserName, RepoName);
            }
        }
        public IList<string> AssemblyFiles
        {
            get
            {
                return _assemblies.ToList();
            }
        }
        #endregion

        #region ctor           
        public PullRequestAssembyHelper(PullRequestView pullRequest, string winUser)
        {
            this.WinUserName = winUser;
            this.PullRequest = pullRequest;
            this.RepoName = pullRequest.RepoName;
            _changedFiles = pullRequest.Files.Where(f=>!f.Contains("UnitTest")).ToList();
            _assemblies = GetAssemblyList();
        }
        #endregion

        #region private
        IList<string> GetAssemblyList()
        {
            var assemblies = new List<string>();
            // get the assemblies for each changed file.
            foreach (var codeFile in _changedFiles)
            {
                // get the project file for the code file.
                var projectFile = GetProjectFile(codeFile);
                if (!String.IsNullOrEmpty(projectFile))
                {
                    // get the assembly from the project file.
                    var assemblyName = GetAssemblyName(projectFile);
                    if (!assemblies.Contains(assemblyName))
                    {
                        assemblies.Add(assemblyName);
                    }
                }
            }
            return assemblies;
        }

        string GetProjectFile(string codeFile)
        {
            var projFile = String.Empty;

            DotNetLanguage language = DotNetLanguage.Unknown;
            if (codeFile.EndsWith(VBFileExtension))
                language = DotNetLanguage.VB;
            else if (codeFile.EndsWith(CSharpFileExtension))
                language = DotNetLanguage.CSharp;
            else // resx? trdx?
                language = DotNetLanguage.VB;

            var fullName = Path.Combine(RepoFolder, codeFile);
            var dirName = Path.GetDirectoryName(fullName);
            if (Directory.Exists(dirName))
            {
                var dir = new DirectoryInfo(dirName);
                projFile = GetProjectFile(dir, language);
            }
            return projFile;
        }
        string GetProjectFile(DirectoryInfo dir, DotNetLanguage language)
        {
            string projectFileFilter = String.Empty;
            if (language == DotNetLanguage.VB)
                projectFileFilter = VBProjectFileFilter;
            else if (language == DotNetLanguage.CSharp)
                projectFileFilter = CSharpProjectFileFilter;

            var projectFiles = dir.GetFiles(projectFileFilter, SearchOption.TopDirectoryOnly);

            if (null == projectFiles || projectFiles.Count() == 0)
            {
                if (null != dir.Parent)
                {
                    var projFile = GetProjectFile(dir.Parent, language);
                    return projFile;
                }
                else
                {
                    return String.Empty;
                }
            }
            else
            {
                return projectFiles[0].FullName;
            }
        }
        string GetAssemblyName(string projectFile)
        {
            var content = File.ReadAllText(projectFile);
            var startTag = @"<AssemblyName>";
            var endTag = @"</AssemblyName>";
            var asmNameIdx = content.IndexOf(startTag);
            var endIdx = content.IndexOf(endTag, asmNameIdx + endTag.Length);
            var startIdx = asmNameIdx + startTag.Length;
            var asmName = content.Substring(startIdx, endIdx - startIdx);
            var suffix = GetOutputSuffix(content);
            return asmName + suffix;
        }
        string GetOutputSuffix(string projectFileContent)
        {
            // <OutputType>Library</OutputType> dll
            // <OutputType>WinExe</OutputType> exe
            // <OutputType>Exe</OutputType> exe
            var libraryOutputType = @"<OutputType>Library</OutputType>";
            var libraryOutputTypeIdx = projectFileContent.IndexOf(libraryOutputType);
            if (libraryOutputTypeIdx > 0)
            {
                return ".dll";
            }

            var winExeOutputType = @"<OutputType>WinExe</OutputType>";
            var winExeOutputTypeIdx = projectFileContent.IndexOf(winExeOutputType);
            if (winExeOutputTypeIdx > 0)
            {
                return ".exe";
            }

            var exeOutputType = @"<OutputType>Exe</OutputType>";
            var exeOutputTypeIdx = projectFileContent.IndexOf(exeOutputType);
            if (exeOutputTypeIdx > 0)
            {
                return ".exe";
            }

            return "???";

        }
        #endregion
    }
}
