using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbVersionLibrary
{
    public static class VersionExtensions
    {
        public static Version MajorMinorVersion(this Version versionNumber)
        {
            if (null != versionNumber)
                return new Version(versionNumber.Major, versionNumber.Minor);
            else
                return new Version();
        }

        public static Version MajorMinorBuildVersion(this Version versionNumber)
        {
            if (null != versionNumber)
                return new Version(versionNumber.Major, versionNumber.Minor, versionNumber.Build);
            else
                return new Version();
        }
    }
}
