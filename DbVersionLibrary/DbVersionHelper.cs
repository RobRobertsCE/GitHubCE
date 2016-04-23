using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbVersionLibrary
{
    public class DbVersionHelper
    {
        #region public

        #region Get Minor Version
        public DbMinorVersion GetLatestMinorVersion()
        {
            return LoadVersions().OrderBy(v => v.VersionNumber).LastOrDefault();
        }

        public DbMinorVersion GetMinorVersion(Version versionNumber)
        {
            return LoadVersions().FirstOrDefault(v => v.VersionNumber == versionNumber);
        }

        public IList<DbMinorVersion> GetVersions()
        {
            return LoadVersions();
        }
        #endregion        

        #region Update Build Version '100' files/directory
        public TaskResult<DbVersion> UpdateDbBuildVersion(DbMinorVersion versionToUpdate)
        {
            var result = new TaskResult<DbVersion>();
            try
            {
                if (!versionToUpdate.RequiresUpgrade)
                {
                    throw new InvalidOperationException("Upgrade folder not found!");
                }
                // need to confirm that we have a x.x.100 version!
                var upgradeVersion = versionToUpdate.UpgradeBuildVersion;
                var currentDbVersion = GetCurrentBuildVersion(versionToUpdate);
                var newBuildNumber = currentDbVersion.VersionNumber.Build + 1;
                var newVersionNumber = new Version(versionToUpdate.VersionNumber.Major, versionToUpdate.VersionNumber.Minor, newBuildNumber);
                var newVersionDirectoryPath = Path.Combine(versionToUpdate.RootPath, newVersionNumber.MajorMinorBuildVersion().ToString());
                // rename the files in the build version being updated. (Replace '100' with the new build #)
                foreach (var buildVersionFile in upgradeVersion.Files)
                {
                    File.Move(buildVersionFile.FullPath, buildVersionFile.UpdatedVersionPath(newBuildNumber));
                }
                // Update the build version vb file (16.2.100) to use the new build number (class name, version declaration, vb upgrade file name.
                var buildVersionUpgradeFile = upgradeVersion.BuildUpgradeVbFile;
                var content = buildVersionUpgradeFile.Content.Replace(Constants.UpgradeBuildNumber.ToString(), newBuildNumber.ToString());
                File.WriteAllText(upgradeVersion.BuildUpgradeVbFile.FullPath, content);
                var newFilePath = upgradeVersion.BuildUpgradeVbFile.UpdatedVersionPath(newBuildNumber);
                File.Move(upgradeVersion.BuildUpgradeVbFile.FullPath, newFilePath);                
                // rename the folder in the build version being updated (16.2.100->16.2.20, replace '100' with the new build #)
                Directory.Move(upgradeVersion.RootPath, upgradeVersion.UpdatedVersionPath(newBuildNumber));
                // Add the call to the new class in the minor version upgrade vb file.
                var minorUpgradeClassContent = versionToUpdate.UpgradeVbFile.Content;
                var lastVersionUpgradeClassName = String.Format("Upgrade{0}_{1}_{2}()", upgradeVersion.VersionNumber.Major, upgradeVersion.VersionNumber.Minor, (newBuildNumber-1));
                var newVersionUpgradeClassName = String.Format("Upgrade{0}_{1}_{2}()", upgradeVersion.VersionNumber.Major, upgradeVersion.VersionNumber.Minor, newBuildNumber);
                var lastBuildCallIndex = minorUpgradeClassContent.IndexOf(lastVersionUpgradeClassName);
                if (lastBuildCallIndex > 0)
                {
                    minorUpgradeClassContent = minorUpgradeClassContent.Insert(lastBuildCallIndex + lastVersionUpgradeClassName.Length, "," + Environment.NewLine + "                       New " + newVersionUpgradeClassName);
                    File.WriteAllText(versionToUpdate.UpgradeVbFile.FullPath, minorUpgradeClassContent);
                }
                upgradeVersion = new DbBuildVersion(newVersionNumber, newVersionDirectoryPath);
                // TODO: confirm file property set to EmbeddedResource
                // TODO: Confirm update versus adding          
                // TODO: Run SetVersion -IncrementDb               
            }
            catch (Exception ex)
            {
                result.AddException(ex);
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
        #endregion

        public Version GetVersionFileVersion()
        {
            var fileContent = File.ReadAllText(Constants.VersionFilePath);
            return new Version(fileContent);
        }

        #endregion

        #region protected virtual

        protected virtual internal IList<DbMinorVersion> LoadVersions()
        {
            var versions = new List<DbMinorVersion>();
            var directories = System.IO.Directory.GetDirectories(Constants.ProjectPath);
            foreach (var directoryPath in directories)
            {
                var directoryName = new DirectoryInfo(directoryPath).Name;
                var versionNumber = new Version();
                if (Version.TryParse(directoryName, out versionNumber))
                {
                    if (versionNumber.Major > 14)
                    {
                        var versionToAdd = new DbMinorVersion(versionNumber, directoryPath);
                        versionToAdd.Builds = LoadBuilds(versionToAdd.RootPath);
                        versions.Add(versionToAdd);
                    }
                }
            }
            return versions;
        }

        protected virtual internal IList<DbBuildVersion> LoadBuilds(string majorMinorVersionRoot)
        {
            var buildVersions = new List<DbBuildVersion>();
            var directories = System.IO.Directory.GetDirectories(majorMinorVersionRoot);
            foreach (var directoryPath in directories)
            {
                var directoryName = new DirectoryInfo(directoryPath).Name;
                var versionNumber = new Version();
                if (Version.TryParse(directoryName, out versionNumber))
                {
                    buildVersions.Add(new DbBuildVersion(versionNumber, directoryPath));
                }
            }
            return buildVersions;
        }

        protected virtual internal DbBuildVersion GetCurrentBuildVersion(DbMinorVersion currentVersion)
        {
            return currentVersion.Builds.OrderByDescending(b => b.VersionNumber).FirstOrDefault(b => !b.IsUpgradeVersion);
        }

        protected virtual internal DbBuildVersion GetBuildUpgradeVersion(DbMinorVersion currentVersion)
        {
            return currentVersion.Builds.FirstOrDefault(b => b.IsUpgradeVersion);
        }

        protected virtual internal void UpdateBuildFiles(DbBuildVersion build)
        {
            foreach (var item in build.Files)
            {
                var originalName = "";
                var newName = "";
                Console.WriteLine("Update {0} to {1}", originalName, newName);
            }
        }

        protected virtual internal void UpdateBuildUpgradeFile(DbBuildVersion currentBuild, DbBuildVersion newBuild)
        {
            Console.WriteLine("Change File {0} to {1}", currentBuild.BuildUpgradeVbFile.FileName, newBuild.BuildUpgradeVbFile.FileName);
            Console.WriteLine("Change Class {0} to {1}", currentBuild.UpgradeClassName, newBuild.UpgradeClassName);
        }

        protected virtual internal void UpdateMajorMinorUpgradeFile(DbMinorVersion version, DbBuildVersion newBuild)
        {
            // add the new class.
            Console.WriteLine("Add Class {0} to {1} in file {2}", newBuild.UpgradeClassName, version.UpgradeClassName, version.UpgradeVbFile.FileName);
        }

        #endregion
    }
}
