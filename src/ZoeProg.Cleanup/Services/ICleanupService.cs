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
    }
}