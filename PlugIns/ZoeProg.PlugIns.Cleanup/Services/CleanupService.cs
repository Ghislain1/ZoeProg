namespace ZoeProg.PlugIns.Cleanup.Services
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Cleanup.Models;

    public class CleanupService : ICleanupService
    {
        private IEnumerable<PSObject> JunkFileList;
        private IPowerShellService powerShellService;

        public CleanupService(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;
        }

        public async Task<bool> DeleteJunkFiles()
        {
            await Task.Delay(122);
            var path = "";

            foreach (var item in this.JunkFileList)
            {
                var cmd = $"Remove-Item -Path {item} -Force";
                await this.powerShellService.RunCommand(cmd);
            }
            //clear the list
            this.JunkFileList = null;
            return true;
        }

        public Task<List<object>> GetListJunkFile(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List of Junkfile
        /// </summary>
        /// <returns></returns>
        public async Task<List<JunkFile>> GetListJunkFile()
        {
            //TODO: Must be removed!! just test Delay()Method
            await Task.Delay(100);
            var path = @"C:\Users\Zoe\AppData\Local\Temp";
            var cmd = $"get-childitem  -Path {path}  -include *.tmp -recurse";

            this.JunkFileList = await this.powerShellService.RunCommand(cmd);

            //TODO: Send More File JUnk information next time
            //Only the  fullFileName has been senden!!
            var res = new List<JunkFile>();
            foreach (var item in this.JunkFileList)
            {
                var junkFile = new JunkFile() { FullPath = item.ToString() };
                res.Add(junkFile);
            }
            return res;
        }
    }
}