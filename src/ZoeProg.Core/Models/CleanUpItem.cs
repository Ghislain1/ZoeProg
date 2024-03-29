﻿

namespace ZoeProg.Core.Models;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class CleanUpItem
{
    public CleanUpItem(string fullPath)
    {
        var fileInfo = new FileInfo(fullPath);
        this.Path = fileInfo.FullName;
        this.Size = (fileInfo.Length / 1024 + 1) + " KB";
        this.Date = fileInfo.LastAccessTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        this.Extension = System.IO.Path.GetExtension(fileInfo.FullName).ToLower();
        this.Name = fileInfo.Name;
    }
    public string Name { get; set; }
    public string Date { get; set; }
    public string Extension { get; set; }
    public string Path { get; set; }
    public string Size { get; set; }
    public bool IsLockedFile { get; set; }
    public bool IsUnauthorizedAccess { get; set; }

}