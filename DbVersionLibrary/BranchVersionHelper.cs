using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbVersionLibrary
{
    public class BranchVersionHelper
    {
        BranchMap _map;
        public BranchMap Map
        {
            get
            {
                return _map;
            }
        }

        public Version Current
        {
            get
            {
                return GetVersionOnDate(DateTime.Now);
            }
        }

        public BranchVersionHelper()
        {
            var develop = this.Current;
            var alpha = new Version(develop.Major, develop.Minor - 1);
            var master = new Version(develop.Major, develop.Minor - 2);
            _map = new BranchMap(master, alpha, develop);
        }

        public Version GetVersionOnDate(DateTime dateToCalculateVersionOn)
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

    public class BranchMap
    {
        public enum BranchTitle
        {
            master,
            alpha,
            develop,
            none
        }

        public string[] BranchNames = new string[] { "master", "", "develop" };

        public Version Master { get; set; }
        public Version Alpha { get; set; }
        public Version Develop { get; set; }

        public BranchMap(Version master, Version alpha, Version develop)
        {
            this.Master = master;
            this.Alpha = alpha;
            this.Develop = develop;
            BranchNames[(int)BranchTitle.alpha] = String.Format("release-{0}.{1}", alpha.Major, alpha.Minor); ;
        }

        public Version GetVersion(BranchTitle branch)
        {
            switch (branch)
            {
                case BranchTitle.master:
                    {
                        return Master;
                    }
                case BranchTitle.alpha:
                    {
                        return Alpha;
                    }
                case BranchTitle.develop:
                    {
                        return Develop;
                    }
                default:
                    {
                        throw new ArgumentException("branch");
                    }
            }
        }

        public Version GetVersion(string branchName)
        {
            BranchTitle branch = BranchTitle.none;
            if (!Enum.TryParse(branchName, out branch))
            {
                for (int i = 0; i < BranchNames.Count(); i++)
                {
                    var name = BranchNames[i];
                    if (name.ToUpper() == branchName.ToUpper())
                    {
                        branch = (BranchTitle)i;
                        break;
                    }
                }
            }

            if (branch == BranchTitle.none)
            {
                return new Version(0, 0);
            }

            switch (branch)
            {
                case BranchTitle.master:
                    {
                        return Master;
                    }
                case BranchTitle.alpha:
                    {
                        return Alpha;
                    }
                case BranchTitle.develop:
                    {
                        return Develop;
                    }
                default:
                    {
                        throw new ArgumentException("branch");
                    }
            }
        }

        public string GetBranchName(BranchTitle branch)
        {
            return BranchNames[(int)branch];
        }

        public Version GetBranch(Version version)
        {
            if (version.Major == Master.Major && version.Minor == Master.Minor)
                return Master;
            else if (version.Major == Alpha.Major && version.Minor == Alpha.Minor)
                return Alpha;
            else if (version.Major == Develop.Major && version.Minor == Develop.Minor)
                return Develop;
            else
                return null;
        }

        public BranchTitle GetBranchTitle(Version version)
        {
            if (version.Major == Master.Major && version.Minor == Master.Minor)
                return BranchTitle.master;
            else if (version.Major == Alpha.Major && version.Minor == Alpha.Minor)
                return BranchTitle.alpha;
            else if (version.Major == Develop.Major && version.Minor == Develop.Minor)
                return BranchTitle.develop;
            else
                return BranchTitle.none;
        }
    }
}
