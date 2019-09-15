using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ghis.PowershellLib;
using Prism.Events;

namespace ZoeProg.Cleanup.Services
{
    public class CleanupService : ICleanupService
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IPowershellService powerShellService;
        private List<string> tempFiles;

        public CleanupService(IPowershellService powerShellService, IEventAggregator eventAggregator)
        {
            this.powerShellService = powerShellService ?? throw new ArgumentNullException(nameof(powerShellService));
            this.eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));

            this.DoAsync().GetAwaiter();
        }

        /// <summary>
        /// Cleans the temporary files asynchronous.
        /// </summary>
        public Task CleanTempFilesAsync()
        {
            var path = "$env:TEMP";
            var cmd = $"Remove-Item -Path {path} -Force -Recurse";
            return this.powerShellService.RunCommand(CancellationToken.None, cmd);
        }

        public Task CleanTempFilesAsync(Action onCompleted)
        {
            var path = "$env:TEMP";
            var cmd = $"Get-ChildItem -Path {path} -Force -Recurse | " + " ForEach-Object($_){ Remove-Item -Path $_.FullName -Force -Recurse}";
            var cmd2 = $"Remove-Item -Path {path} -Force -Recurse ";
            return this.powerShellService.RunCommand(CancellationToken.None, cmd);
        }

        public async Task DeleteFileForDemoAsync()
        {
            var path = @"C:\Users\Zoe\Desktop\___Z_Todelte\AutoCADwpfDeno";
            var cmd = $"Remove-Item -Path {path} -Force -Recurse";
            await this.powerShellService.RunCommand(CancellationToken.None, cmd);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>list of</returns>
        public List<string> GetAll()
        {
            return this.tempFiles;
        }

        public Task LoadTempFilesAsync()
        {
            var rList = new List<string>();
            var cmd = "Get-ChildItem $env:TEMP -Recurse -File";
            return this.powerShellService.RunCommand(cmd, path =>
            {
                rList.Add(path);
            });
        }

        public async Task LoadTempFilesAsync(Action<string> onData)
        {
            //var path = "$env:TEMP";
            //var cmd = $"Remove-Item -Path {path} -Force -Recurse";
            //await this.powerShellService.RunCommand(onData, cmd);
        }

        private async Task DoAsync()
        {
            await Task.Delay(1000);
            var cmd = "Get-ChildItem $env:TEMP -File -Recurse";
            var sd = await this.powerShellService.RunCommand(CancellationToken.None, cmd);
            this.tempFiles = new List<string>(sd);
            this.eventAggregator.GetEvent<TempFileEvent>().Publish();
        }
    }

    public class TempFileEvent : PubSubEvent
    {
    }
}