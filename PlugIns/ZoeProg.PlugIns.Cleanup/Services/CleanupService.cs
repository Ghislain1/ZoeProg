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
        private IEnumerable<string> JunkFileList;
        private IPowerShellService powerShellService;

        public CleanupService(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;
        }

        public async Task<bool> DeleteJunkFiles()
        {
            await Task.Delay(122);
            var format = @"Remove-Item -Path {0} -Force";
            foreach (var item in this.JunkFileList)
            {
                var cmd = string.Format(format, item);
                await this.powerShellService.RunCommand(cmd);
            }

            return true;
        }

        public Task<List<object>> GetListJunkFile(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JunkFile>> GetListJunkFile()
        {
            await Task.Delay(100);

            var cmd = @"get-childitem c:\ -include *.tmp -recurse";
            this.JunkFileList = await this.powerShellService.RunCommand(cmd);
            var res = new List<JunkFile>();
            foreach (var item in this.JunkFileList)
            {
                res.Add(new JunkFile() { Name = item });
            }
            return res;
        }
    }
}