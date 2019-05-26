namespace ZoeProg.PlugIns.Settings.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZoeProg.Common;
    using ZoeProg.Common.Models;

    public class SettingService : ISettingService
    {
        public Task<List<Drive>> GetDriverList(ProviderType providerType = ProviderType.FileSystem)
        {
            throw new NotImplementedException();
        }
    }
}