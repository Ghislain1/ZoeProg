using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZoeProg.PlugIns.Cleanup.Models;

namespace ZoeProg.PlugIns.Cleanup.Services
{
    public interface ICleanupService
    {
        Task<bool> DeleteJunkFiles();

        Task<List<object>> GetListJunkFile(CancellationToken token);

        Task<List<JunkFile>> GetListJunkFile();
    }
}