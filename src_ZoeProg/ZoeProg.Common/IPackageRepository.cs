namespace ZoeProg.Common
{
    using Data;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPackageRepository
    {
        Task<List<Package>> GetListAvailabePackages(string folderName, CancellationToken token);

        Task<List<InstalledPackage>> GetListInstalledPackages(CancellationToken token);

        Task<List<InstalledPackage>> GetListInstalledPackages(CancellationTokenSource cancellationTokenSource);
    }
}