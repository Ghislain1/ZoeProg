using System.Collections.Generic;
using System.Threading.Tasks;
using ZoeProg.Common.Models;

namespace ZoeProg.Common
{
    public interface ISettingService
    {
        Task<List<Drive>> GetDriverList(ProviderType providerType = ProviderType.FileSystem);
    }
}