
namespace ZoeProg.PlugIns.CleanUp.Services;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ZoeProg.Core.Models;


public interface ICleanupService
{
    IDictionary<string, string> GetPresetDirectories();
    Task<IEnumerable<CleanUpItem>> GetAllAsync(string locationFolder, CancellationToken cancellationToken);
    Task DeleteFileForDemoAsync();
    Task CleanTempFilesAsync(Action onCompleted);
    Task DeleteAsync(string fullPath, Action<Exception> onError);
    IEnumerable<CleanUpItem> GetAll();
    Task LoadTempFilesAsync();
}