using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitHubCE
{
    public static class BranchVersionHelper
    {
        #region consts      
        private const string VersionFileTemplate = @"C:\Users\{0}\Source\Repos\{1}\src\version.txt";
        private const string WinUserName = "rroberts";
        private const string RepoName = "ADVANTAGE";
        #endregion

        static BranchMap _map;
        public static BranchMap Map
        {
            get
            {
                return _map;
            }
        }

        public static RepoBranch DevelopBranch
        {
            get
            {
                return _map.DevelopBranch;
            }
        }
        public static RepoBranch AlphaBranch
        {
            get
            {
                return _map.AlphaBranch;
            }
        }
        public static RepoBranch MasterBranch
        {
            get
            {
                return _map.MasterBranch;
            }
        }

        public static Version CurrentVersion
        {
            get
            {
                var versionFileContent = File.ReadAllText(VersionFile);
                return new Version(versionFileContent);
            }
        }

        public static RepoBranch CurrentBranch
        {
            get
            {
                return _map.GetRepoBranch(CurrentVersion);
            }
        }

        public static string VersionFile
        {
            get
            {
                return String.Format(VersionFileTemplate, WinUserName, RepoName);
            }
        }

        static BranchVersionHelper()
        {
            var develop = GetVersionOnDate(DateTime.Now);
            var alpha = new Version(develop.Major, develop.Minor - 1);
            var master = new Version(develop.Major, develop.Minor - 2);
            _map = new BranchMap(master, alpha, develop);
        }

        public static Version GetVersionOnDate(DateTime dateToCalculateVersionOn)
        {
            var startVer = new Version(Properties.Resources.StartVersion);
            var versionStartDate = DateTime.Parse(Properties.Resources.StartDate);
            var sprintCountPerMinorVersion = Int32.Parse(Properties.Resources.SprintCountPerVersion);
            var sprintLengthDays = Int32.Parse(Properties.Resources.SprintLengthDays);

            var daysSinceStart = (int)dateToCalculateVersionOn.Subtract(versionStartDate).TotalDays;
            var sprintsSinceStart = (int)(daysSinceStart / sprintLengthDays);


            var minorVesionsSinceStart = 0;
            if (sprintsSinceStart > 0)
            {
                minorVesionsSinceStart = (int)(sprintsSinceStart / sprintCountPerMinorVersion);
            }

            var majorVersionNumber = Int32.Parse(versionStartDate.Year.ToString().Substring(2, 2));
            var minorVersionNumber = startVer.Minor + minorVesionsSinceStart;
            // only 6 minor versions per year.. hardening spring throws it off.
            if (minorVersionNumber == 7) minorVersionNumber = 6;

            var version = new Version(majorVersionNumber, minorVersionNumber);

            Console.WriteLine("Version on {0}: {1}", dateToCalculateVersionOn.ToShortDateString(), version.ToString());
            return version;
        }
    }

    public enum BranchTitle
    {
        master,
        alpha,
        develop,
        none
    }
    
    public class BranchMap
    {
        private IList<RepoBranch> Branches { get; set; }

        public RepoBranch MasterBranch { get; set; }
        public RepoBranch AlphaBranch { get; set; }
        public RepoBranch DevelopBranch { get; set; }

        public BranchMap()
        {
            var developVersion = BranchVersionHelper.GetVersionOnDate(DateTime.Now);
            var alphaVersion = new Version(developVersion.Major, developVersion.Minor, developVersion.Revision - 1);
            var masterVersion = new Version(developVersion.Major, developVersion.Minor, developVersion.Revision - 2);
            Initialize(masterVersion, alphaVersion, developVersion);
        }

        public BranchMap(Version masterVersion, Version alphaVersion, Version developVersion)
        {
            Initialize(masterVersion, alphaVersion, developVersion);
        }

        void Initialize(Version masterVersion, Version alphaVersion, Version developVersion)
        {
            Branches = new List<RepoBranch>();

            MasterBranch = new RepoBranch()
            {
                Version = masterVersion,
                Name = "master",
                Title = BranchTitle.master,
                RequiresPatches=true
            };
            AlphaBranch = new RepoBranch()
            {
                Version = alphaVersion,
                Name = String.Format("release-{0}.{1}", alphaVersion.Major, alphaVersion.Minor),
                Title = BranchTitle.alpha,
                Child = MasterBranch,
                RequiresPatches = true
            };
            MasterBranch.Parent = AlphaBranch;
            DevelopBranch = new RepoBranch()
            {
                Version = developVersion,
                Name = "develop",
                Title = BranchTitle.develop,
                Child = AlphaBranch,
                RequiresPatches = false
            };
            AlphaBranch.Parent = DevelopBranch;

            Branches.Add(MasterBranch);
            Branches.Add(AlphaBranch);
            Branches.Add(DevelopBranch);
        }

        public RepoBranch GetRepoBranch(Version version)
        {
            return Branches.FirstOrDefault(b => b.Version.Major == version.Major && b.Version.Minor == version.Minor);
        }
        public RepoBranch GetRepoBranch(BranchTitle branch)
        {
            return Branches.FirstOrDefault(b => b.Title == branch);
        }
        public RepoBranch GetRepoBranch(string branchName)
        {
            var branchBuffer = Branches.FirstOrDefault(b => b.Name == branchName);
            if (null== branchBuffer)
            {
                var branchNameSections = branchName.Split('-');
                if (branchNameSections[0].ToUpper()=="EPIC")
                {
                    branchBuffer = GetEpicRepoBranch(branchNameSections);
                }
                else
                {
                    var branchVersionSections = branchNameSections[1].Split('.');
                    var branchVersion = new Version(Convert.ToInt32(branchVersionSections[0]), Convert.ToInt32(branchVersionSections[1]));
                    branchBuffer = GetRepoBranch(branchVersion);
                }             
            }
            return branchBuffer;
        }

        public RepoBranch GetEpicRepoBranch(string[] branchNameSections)
        {
            RepoBranch branchBuffer = null;
            if (branchNameSections[0].ToUpper() == "EPIC")
            {
                if (branchNameSections[1].ToUpper() == "ADVANTAGE") // created from the develop branch
                {
                    branchBuffer = GetRepoBranch(BranchTitle.develop);
                }
            }
            return branchBuffer;
        }
    }

    public class RepoBranch
    {
        public Version Version { get; set; }
        public string Name { get; set; }
        public BranchTitle Title { get; set; }
        public bool RequiresPatches { get; set; }
        public RepoBranch Parent { get; set; }
        public RepoBranch Child { get; set; }
    }
}
