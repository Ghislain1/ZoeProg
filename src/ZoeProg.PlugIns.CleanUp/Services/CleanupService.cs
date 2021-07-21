using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Prism.Events;
using ZoeProg.Infrastructure;

namespace ZoeProg.PlugIns.CleanUp.Services
{
    public class CleanupService : ICleanupService
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IPowershellService powerShellService;
        private readonly List<string> tempFiles;

        public CleanupService(IPowershellService powerShellService, IEventAggregator eventAggregator)
        {
            this.powerShellService = powerShellService ?? throw new ArgumentNullException(nameof(powerShellService));
            this.eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));

            this.DoAsync().GetAwaiter();
        }

        /// <summary>
        /// Cleans the temporary files asynchronous.
        /// </summary>
        /// <returns>representing the asynchronous operation.</returns>
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

        /// <summary>
        /// Loads the temporary files asynchronous.
        /// </summary>
        /// <param name="onData">The on data.</param>
        /// <returns>a Task</returns>
        public Task LoadTempFilesAsync(Action<string> onData)
        {
            var rList = new List<string>();
            var folderPath = System.IO.Path.GetTempPath();// Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var cmd = $"Get-ChildItem {folderPath} -Recurse ";
            return this.powerShellService.RunCommand(cmd, path =>
            {
                onData(path);
            });
        }

        /// <summary>
        /// Removes the file asnyc.
        /// </summary>
        /// <param name="filePathList">The file path list.</param>
        /// <returns>task</returns>
        public async Task RemoveFileAsnyc(List<string> filePathList)
        {
            foreach (var item in filePathList)
            {
                await this.RemoveFileAsnyc(item);
            }
        }

        /// <summary>
        /// Removes the file asnyc.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Task</returns>
        public Task RemoveFileAsnyc(string filePath)
        {
            var scriptString = $"Remove-Item -Path {filePath} -Force";
            return this.powerShellService.RunCommand(CancellationToken.None, scriptString);
        }

        private async Task DoAsync()
        {
            await Task.Delay(1000);
            var cmd = "Get-ChildItem $env:TEMP -File -Recurse";
            await this.powerShellService.RunCommand(CancellationToken.None, cmd);
            //this.tempFiles = new List<string>(sd);
            //this.eventAggregator.GetEvent<TempFileEvent>().Publish();
        }
    }

    public class TempFileEvent : PubSubEvent
    {
    }
}