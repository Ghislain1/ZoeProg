
namespace ZoeProg.PlugIns.CleanUp.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using ZoeProg.Core.Models;


    public interface ICleanupService
    {




        // TODO- TOremove
        Task<IEnumerable<CleanUpItem>> GetAllAsync(string locationFolder, CancellationToken cancellationToken);
        Task DeleteFileForDemoAsync();
        // TODO- TOremove
        Task CleanTempFilesAsync(Action onCompleted);

        Task DeleteAsync(string fullPath, Action<Exception> onError);



        IEnumerable<CleanUpItem> GetAll();

        Task LoadTempFilesAsync();





    }
}