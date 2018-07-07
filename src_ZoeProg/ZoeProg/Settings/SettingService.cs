using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var collectionPSObject = await this.powerShellService.RunCommand(cmd);
                // Used Free CurrentLocation Name Provider Root Description MaximumSize Credential DisplayRoot
                foreach (var item in collectionPSObject)
                {
                    var name = item.Members["Name"];
                    var provider = item.Members["Provider"];
                    var root = item.Members["Root"];

                    var drive = new Drive()
                    {
                        Name = name.Value.ToString(),
                        Root = root.Value.ToString()
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