namespace ZoeProg.PlugIns.Cleanup.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Cleanup.Models;

    public class CleanupService : ICleanupService
    {
        private IPowerShellService powerShellService;

        public CleanupService(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;
        }

        public Task<List<object>> GetListJunkFile(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JunkFile>> GetListJunkFile()
        {
            await Task.Delay(2300);

            var cmd = "ls";
            await this.powerShellService.RunCommand(cmd);
            var res = new List<JunkFile>();
            for (int i = 1; i < 20; i++)
            {
                res.Add(new JunkFile() { Name = "LoloNr. " + i });
            }

            return res;
        }
    }
}