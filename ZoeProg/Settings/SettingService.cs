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
            var cmd = "Get-PSDrive -Scope Global -PSProvider " + providerType;
            try
            {
                var res = await this.powerShellService.RunCommand(cmd);
                result = res.Select(i => new Drive() { Name = i }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}