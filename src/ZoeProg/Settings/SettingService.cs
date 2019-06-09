using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZoeProg.Common;
using ZoeProg.Common.Models;

namespace ZoeProg.Settings
{
    public class SettingService : ISettingService
    {
        private readonly IPowerShellService powerShellService;

        public SettingService(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;
        }

        public async Task<List<Drive>> GetDriverList(ProviderType providerType = ProviderType.FileSystem)
        {
            List<Drive> result = new List<Drive>();
            // var cmd = "Get-PSDrive -Scope Global -PSProvider " + providerType + " | Format-List";
            var cmd = "Get-PSDrive -Scope Global -PSProvider  " + providerType;
            try
            {
                var collectionPSObject = await this.powerShellService.RunCommand<string>(cmd, "Format-List");
                // Used Free CurrentLocation Name Provider Root Description MaximumSize Credential DisplayRoot
                foreach (var item in collectionPSObject)
                {
                    //var name = item.Members["Name"];
                    //var provider = item.Members["Provider"];
                    //var root = item.Members["Root"];

                    var drive = new Drive()
                    {
                        Name = item.ToString(),
                        Root =  item
                    };
                    result.Add(drive);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}