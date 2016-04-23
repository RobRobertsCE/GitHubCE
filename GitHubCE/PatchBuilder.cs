using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitHubCE
{
    public class PatchBuilder
    {
        private const string RepoDirectory = @"C:\Users\rroberts\Source\Repos\Advantage";

        public PullRequestView Request { get; set; }

        public IList<string> Assemblies { get; set; }

        public PatchBuilder(PullRequestView request)
        {
            this.Request = request;
            Assemblies = GetAssemblyList();
        }

        IList<string> GetAssemblyList()
        {
            var assemblies = new List<string>();
            // get the assemblies for each changed file.
            foreach (var codeFile in Request.Files )
            {
                if (!codeFile.StartsWith("res/reports/"))
                {
                    // get the project file for the code file.
                    var projectFile = GetProjectFile(codeFile);
                    if (!String.IsNullOrEmpty(projectFile))
                    {
                        // get the assembly from the project file.
                        var asmName = GetAssemblyName(projectFile);
                        if (!assemblies.Contains(asmName))
                        {
                            assemblies.Add(asmName);
                        }
                    }
                }
                else
                {
                    //TODO: Handle Reports
                }
            }

            return assemblies;
        }

        string GetProjectFile(string codeFile)
        {
            var projFile = String.Empty;

            var fullName = Path.Combine(RepoDirectory, codeFile);
            var dirName = Path.GetDirectoryName(fullName);
            if (Directory.Exists(dirName))
            {
                var dir = new DirectoryInfo(dirName);
                projFile = GetProjectFile(dir);
            }
            return projFile;
        }

        string GetProjectFile(DirectoryInfo dir)
        {
            var projectFiles = dir.GetFiles("*.vbproj", SearchOption.TopDirectoryOnly);
            if (null == projectFiles || projectFiles.Count() == 0)
            {
                if (null!=dir.Parent)
                {
                    var projFile = GetProjectFile(dir.Parent);
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
            var startIdx = asmNameIdx +startTag.Length;
            var asmName = content.Substring(startIdx, endIdx - startIdx);
            var suffix = GetOutputSuffix(content);
            return asmName + suffix;
        }

        string GetOutputSuffix(string projectFileContent)
        {
            // <OutputType>Library</OutputType> dll
            // <OutputType>WinExe</OutputType> exe
            var libraryOutputType = @"<OutputType>Library</OutputType>";
            var libraryOutputTypeIdx = projectFileContent.IndexOf(libraryOutputType);
            if (libraryOutputTypeIdx > 0)
            {
                return ".dll";
            }

            var exeOutputType = @"<OutputType>WinExe</OutputType>";
            var exeOutputTypeIdx = projectFileContent.IndexOf(exeOutputType);
            if (exeOutputTypeIdx > 0)
            {
                return ".exe";
            }
            else
            {
                return "???";
            }
        }
    }
}
