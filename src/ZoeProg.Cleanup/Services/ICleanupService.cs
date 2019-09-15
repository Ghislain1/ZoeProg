using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZoeProg.Cleanup.Services
{
    public interface ICleanupService
    {
        Task CleanTempFilesAsync();

        Task CleanTempFilesAsync(Action onCompleted);

        Task DeleteFileForDemoAsync();

        List<string> GetAll();

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