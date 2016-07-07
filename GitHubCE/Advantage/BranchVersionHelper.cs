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

        //public Version GetVersion(BranchTitle branch)
        //{
        //    switch (branch)
        //    {
        //        case BranchTitle.master:
        //            {
        //                return Master;
        //            }
        //        case BranchTitle.alpha:
        //            {
        //                return Alpha;
        //            }
        //        case BranchTitle.develop:
        //            {
        //                return Develop;
        //            }
        //        default:
        //            {
        //                throw new ArgumentException("branch");
        //            }
        //    }
        //}

        //public Version GetVersion(string branchName)
        //{
        //    BranchTitle branch = BranchTitle.none;
        //    if (!Enum.TryParse(branchName, out branch))
        //    {
        //        for (int i = 0; i < BranchNames.Count(); i++)
        //        {
        //            var name = BranchNames[i];
        //            if (name.ToUpper() == branchName.ToUpper())
        //            {
        //                branch = (BranchTitle)i;
        //                break;
        //            }
        //        }
        //    }

        //    if (branch == BranchTitle.none)
        //    {
        //        return new Version(0, 0);
        //    }

        //    switch (branch)
        //    {
        //        case BranchTitle.master:
        //            {
        //                return Master;
        //            }
        //        case BranchTitle.alpha:
        //            {
        //                return Alpha;
        //            }
        //        case BranchTitle.develop:
        //            {
        //                return Develop;
        //            }
        //        default:
        //            {
        //                throw new ArgumentException("branch");
        //            }
        //    }
        //}

        //public string GetBranchName(BranchTitle branch)
        //{
        //    return BranchNames[(int)branch];
        //}

        //public Version GetBranch(Version version)
        //{
        //    if (version.Major == Master.Major && version.Minor == Master.Minor)
        //        return Master;
        //    else if (version.Major == Alpha.Major && version.Minor == Alpha.Minor)
        //        return Alpha;
        //    else if (version.Major == Develop.Major && version.Minor == Develop.Minor)
        //        return Develop;
        //    else
        //        return null;
        //}

        //public BranchTitle GetBranchTitle(Version version)
        //{
        //    if (version.Major == Master.Major && version.Minor == Master.Minor)
        //        return BranchTitle.master;
        //    else if (version.Major == Alpha.Major && version.Minor == Alpha.Minor)
        //        return BranchTitle.alpha;
        //    else if (version.Major == Develop.Major && version.Minor == Develop.Minor)
        //        return BranchTitle.develop;
        //    else
        //        return BranchTitle.none;
        //}

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
            return Branches.FirstOrDefault(b => b.Name == branchName);
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
