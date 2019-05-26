namespace ZoeProg.PlugIns.UninstalledPackage.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using ZoeProg.Common.Data;

    public interface IUninstalledPackageProvider
    {
        List<UninstalledPackage> GetMSIFilesList();

        Task<List<UninstalledPackage>> GetMSIFilesList(CancellationToken cancellationToken);

        Task<List<UninstalledPackage>> GetMSIFilesListAsync();
    }
}