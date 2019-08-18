using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Events;
using ZoeProg.Common;

namespace ZoeProg.Cleanup.Services
{
    public interface ICleanupService
    {
        Task CleanTempFilesAsync();

        Task DeleteFileForDemoAsync();

        List<string> GetAll();

        Task<List<string>> GetFilesJustForDemo();

        Task<IList<string>> GetTempFilesAsync();
    }

    public class CleanupService : ICleanupService
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IPowerShellService powerShellService;
        private List<string> tempFiles;

        public CleanupService(IPowerShellService powerShellService, IEventAggregator eventAggregator)
        {
            this.powerShellService = powerShellService ?? throw new ArgumentNullException(nameof(powerShellService));
            this.eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));

            this.DoAsync().GetAwaiter();
        }

        /// <summary>
        /// Cleans the temporary files asynchronous.
        /// </summary>
        public async Task CleanTempFilesAsync()
        {
            var path = "$env:TEMP";
            var cmd = $"Remove-Item -Path {path} -Force -Recurse";
            await this.powerShellService.RunCommand<string>(cmd, "List");
        }

        public async Task DeleteFileForDemoAsync()
        {
            var path = @"C:\Users\Zoe\Desktop\___Z_Todelte\AutoCADwpfDeno";
            var cmd = $"Remove-Item -Path {path} -Force -Recurse";
            await this.powerShellService.RunCommand<string>(cmd, "List");
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>list of</returns>
        public List<string> GetAll()
        {
            return this.tempFiles;
        }

        public async Task<List<string>> GetFilesJustForDemo()
        {
            var list = new List<string>();
            var path = @"C:\Users\Zoe\Desktop\___Z_Todelte\AutoCADwpfDeno";
            var cmd = $"Get-ChildItem -Path {path}  -Recurse";
            var sx = await this.powerShellService.RunCommand<string>(cmd, "List");
            list.AddRange(sx);

            return list;
        }

        public async Task<IList<string>> GetTempFilesAsync()
        {
            var cmd = "Get-ChildItem $env:TEMP -Recurse";
            var rList = await this.powerShellService.RunCommand<string>(cmd, "List");
            return rList;
        }

        private async Task DoAsync()
        {
            await Task.Delay(1000);
            var cmd = "Get-ChildItem $env:TEMP";
            var sd = await this.powerShellService.RunCommand<string>(cmd, "List");
            this.tempFiles = new List<string>(sd);
            this.eventAggregator.GetEvent<TempFileEvent>().Publish();
        }
    }

    public class TempFileEvent : PubSubEvent
    {
    }
}