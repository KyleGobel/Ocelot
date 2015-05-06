using System;
using System.Collections.Generic;
using System.Linq;
using NuGet;

namespace Ocelot.Core
{
    public class Nuget
    {
        public static void GetPackage()
        {
            var packageId = "ServiceStack.Text";
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");

            List<IPackage> packages = repo.FindPackagesById(packageId).ToList();
            packages = packages.Where(x => x.IsReleaseVersion() == true).ToList();

            foreach (var pkg in packages.OrderBy(x => x.Version))
            {
                Console.WriteLine(pkg.GetFullName());
            }
        }
        public static void InstallLatestPackage(string baseDirectory)
        {
            var packageId = "ServiceStack.Text";
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("https://packages.nuget.org/api/v2");

            List<IPackage> packages = repo.FindPackagesById(packageId).ToList();
            packages = packages.Where(x => x.IsReleaseVersion() == true).ToList();

            var pkg = packages.OrderByDescending(x => x.Version).First();


            var pkgManager = new PackageManager(repo, baseDirectory);

            pkgManager.PackageInstalled += (sender, e) =>
            {
            }
            pkgManager.InstallPackage(pkg.Id, pkg.Version);
        }
    }
}
