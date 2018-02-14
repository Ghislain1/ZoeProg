using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoeProg.WebApi.Directory.Models;

namespace ZoeProg.WebApi.Directory
{
    public interface IDirectoryService
    {
        string GetFileFolderName(string path);
        List<DirectoryItem> GetLogicalDrives();
        List<DirectoryItem> GetDirectoryContents(string fullPath);
    }
}
