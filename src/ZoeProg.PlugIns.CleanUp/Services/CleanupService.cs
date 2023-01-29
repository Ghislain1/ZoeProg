

namespace ZoeProg.PlugIns.CleanUp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Prism.Events;
    using ZoeProg.Core.Models;
    using ZoeProg.Core.Utils;
    public class CleanupService : ICleanupService
    {
        private readonly IEventAggregator eventAggregator;

        private readonly List<string>? tempFiles;

        public CleanupService(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));
        }

        public async Task DeleteAsync(string fullPath, Action<Exception> onError)
        {

            await Task.Run(() =>
            {
                try
                {
                    File.Delete(fullPath);
                }
                catch (Exception ex)
                {

                    onError(ex);
                }

            }
            );

        }
        public async Task<IEnumerable<CleanUpItem>> GetAllAsync(string locationFolder, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
              {
                  var result = new List<CleanUpItem>();
                  try
                  {
                      var filees = Directory.EnumerateFiles(locationFolder, "*", SearchOption.AllDirectories);
                      foreach (var filePath in filees)
                      {

                          result.Add(new CleanUpItem(filePath));
                      }

                  }
                  catch (FileNotFoundException)
                  {
                  }
                  catch (UnauthorizedAccessException)
                  {

                  }


                  return result;


              }, cancellationToken);
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
        public IEnumerable<CleanUpItem> GetAll()
        {
            throw new NotImplementedException();

            //var result = new List<CleanUpItem>();

            //foreach (var item in directories.Keys)
            //{

            //    try
            //    {
            //        var filees = Directory.EnumerateFiles(directories[item], "*", SearchOption.AllDirectories);
            //        foreach (var filePath in filees)
            //        {

            //            result.Add(this.CreateCleanUpItem(new FileInfo(filePath), item));
            //        }
            //    }
            //    catch (FileNotFoundException)
            //    {
            //    }
            //    catch (UnauthorizedAccessException)
            //    {

            //    }


            //}
            //return result;

            //foreach (var item in directories.Keys)
            //{
            //    try
            //    {
            //        //  TODO@Ghislain: pop poweshel window 
            //       // var cmd = $"Get-ChildItem {directories[item]} -Recurse -File";
            //       // PowerShellHelper.ExecuteCommand(cmd);   

            //        // TODO@GhZe: Find best way with Powershell
            //        var filees = Directory.EnumerateFiles(directories[item], "*", SearchOption.AllDirectories);
            //        foreach (var filePath in filees)
            //        {
            //            FileInfo fileInfo = new FileInfo(filePath);
            //            var fileSize = fileInfo.Length / 1024 + 1;
            //            var cleanItem = new CleanUpItemViewModel
            //            {
            //                Path = fileInfo.FullName,
            //                Size = fileSize + " KB",
            //                Date = fileInfo.LastAccessTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
            //                Extension = Path.GetExtension(filePath).ToLower(),
            //                Group = item
            //            };
            //            result.Add(cleanItem);
            //        }
            //    }
            //    catch (FileNotFoundException)
            //    {
            //    }
            //    catch (UnauthorizedAccessException)
            //    {

            //    }

            //}
            // return result;


        }

        public Task LoadTempFilesAsync()
        {
            var rList = new List<string>();
            var cmd = "Get-ChildItem $env:TEMP -Recurse -File";
            return Task.Delay(1000);
        }







        public async Task<IEnumerable<CleanUpItem>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() => this.GetAll(), cancellationToken);
        }


    }
}