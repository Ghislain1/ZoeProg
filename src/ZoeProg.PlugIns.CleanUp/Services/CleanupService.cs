using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Prism.Events;
using ZoeProg.Core.Models;

namespace ZoeProg.PlugIns.CleanUp.Services
{
    public class CleanupService : ICleanupService
    {
        private readonly IEventAggregator eventAggregator;

        private readonly List<string> tempFiles;

        public CleanupService(IEventAggregator eventAggregator)
        {

            this.eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));


        }

        /// <summary>
        /// Cleans the temporary files asynchronous.
        /// </summary>
        /// <returns>representing the asynchronous operation.</returns>
        public Task CleanTempFilesAsync()
        {
            var path = "$env:TEMP";
            var cmd = $"Remove-Item -Path {path} -Force -Recurse";
            return Task.Delay(1000);
        }

        public Task CleanTempFilesAsync(Action onCompleted)
        {
            var path = "$env:TEMP";
            var cmd = $"Get-ChildItem -Path {path} -Force -Recurse | " + " ForEach-Object($_){ Remove-Item -Path $_.FullName -Force -Recurse}";
            var cmd2 = $"Remove-Item -Path {path} -Force -Recurse ";
            return Task.Delay(1000);
        }

        public async Task DeleteFileForDemoAsync()
        {
            var path = @"C:\Users\Zoe\Desktop\___Z_Todelte\AutoCADwpfDeno";
            var cmd = $"Remove-Item -Path {path} -Force -Recurse";
            await Task.Delay(1000);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>list of</returns>
        public IEnumerable<CleanItem> GetAll()
        {
            var directories = this.GetPresetDirectorySources();
            var result = new List<CleanItem>();
            int index = 0;
           
            foreach (var item in directories.Keys)
            {
                try
                {
                    // TODO@GhZe: Find best way with Powershell
                    var filees = Directory.EnumerateFiles(directories[item], "*", SearchOption.AllDirectories);
                    foreach (var filePath in filees)
                    {
                        FileInfo fileInfo = new FileInfo(filePath);
                        var fileSize = fileInfo.Length / 1024 + 1;
                        var cleanItem = new CleanItem
                        {
                            Path = fileInfo.FullName,
                            Size = fileSize + " KB",
                            Date = fileInfo.LastAccessTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                            Extension = Path.GetExtension(filePath).ToLower(),
                            Group = item
                        };
                        result.Add(cleanItem);
                    }
                }
                catch (FileNotFoundException)
                {
                }
                catch (UnauthorizedAccessException)
                {

                }

            }
            return result;


        }
        private Dictionary<string, string> GetPresetDirectorySources()
        {
            string winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            Dictionary<string, string> result = new Dictionary<string, string>
            {
                {"Temporary Directory", Path.GetTempPath()},
                {"Win Temporary Directory", Path.Combine(winDir, @"Temp")},
                {"Windows Installer Cache", Path.Combine(winDir, @"Installer\$PatchCache$\Managed")},
                {"Windows Update Cache", Path.Combine(winDir, @"SoftwareDistribution\Download")},
                {"Windows Logs Directory", Path.Combine(winDir, @"Logs")},
                {"Prefetch Cache", Path.Combine(winDir, @"Prefetch")},
                {
                    "Crash Dump Directory",
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        @"CrashDumps")
                },
              //  {"Google Chrome Cache", Path.Combine(Window7.ChromeDataPath, @"Default\Cache")},
             //   {"Steam Redist Packages", SteamLibraryDir}
            };
            return result;
        }
        public Task LoadTempFilesAsync()
        {
            var rList = new List<string>();
            var cmd = "Get-ChildItem $env:TEMP -Recurse -File";
            return Task.Delay(1000);
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
            return Task.Delay(1000);
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
            return Task.Delay(1000);
        }

        private async Task DoAsync()
        {
            await Task.Delay(1000);
            var cmd = "Get-ChildItem $env:TEMP -File -Recurse";
            await Task.Delay(1000);

        }


        public Task<IEnumerable<CleanItem>> GetAllAsync()
        {
            return Task.Run(() => this.GetAll());
        }




    }
}