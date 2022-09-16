using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ZoeProg.Core.Models;

namespace ZoeProg.PlugIns.CleanUp.Services
{
    public interface ICleanupService
    {
        Task CleanTempFilesAsync();

        Task<IEnumerable<FileInfo>> GetAllAsync(CancellationToken cancellationToken);

        Task CleanTempFilesAsync(Action onCompleted);

        Task DeleteFileForDemoAsync();

        IEnumerable<FileInfo> GetAll();

        Task LoadTempFilesAsync();

        Task LoadTempFilesAsync(Action<string> onDataReceived);

        /// <summary>
        /// Removes the file asnyc.
        /// </summary>
        /// <param name="filePathList">The file path list.</param>
        /// <returns>task</returns>
        Task RemoveFileAsnyc(List<string> filePathList);

        /// <summary>
        /// Removes the file asnyc.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Task</returns>
        Task RemoveFileAsnyc(string filePath);
    }
}
