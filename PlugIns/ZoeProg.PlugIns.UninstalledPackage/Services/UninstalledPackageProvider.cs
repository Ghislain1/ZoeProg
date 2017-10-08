namespace ZoeProg.PlugIns.UninstalledPackage.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using ZoeProg.Common;
    using ZoeProg.Common.Data;

    public class UninstalledPackageProvider : IUninstalledPackageProvider
    {
        private readonly IPowerShellService powerShellService;

        public UninstalledPackageProvider(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;
        }

        public List<UninstalledPackage> GetMSIFilesList()
        {
            List<UninstalledPackage> result = new List<UninstalledPackage>();

            return result;
        }

        public Task<List<UninstalledPackage>> GetMSIFilesList(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UninstalledPackage>> GetMSIFilesListAsync()
        {
            var cmd = @"Get-Childitem –Path C:\Users\Zoe\Downloads\ -Include  *.exe -File -Recurse";
            var resultCommand = await this.powerShellService.RunCommand(cmd);

            List<UninstalledPackage> listToReturn = new List<UninstalledPackage>();
            foreach (var item in resultCommand)
            {
                listToReturn.Add(new UninstalledPackage() { Title = item, Version = "hh" });
            }
            return listToReturn;
        }
    }
}