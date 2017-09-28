namespace ZoeProg.Services
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;
  using ZoeProg.Common;
  using Common.Data;
  using System.Text.RegularExpressions;

  public class PackageRepository : IPackageRepository
  {
    private readonly IPowerShellService powerShellService;

    public PackageRepository(IPowerShellService powerShellService)
    {
      this.powerShellService = powerShellService;
    }

    public Task<List<Package>> GetListAvailabePackages(string folderName, CancellationToken token)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Package>> GetListInstalledPackages(CancellationToken token)
    {
      string test = @"\\DESKTOP-0OD702C\root\cimv2:Win32_Product.IdentifyingNumber=" + "{A66F82FB-85EE-48D2-B19C-3A98147D5167}" +
      ", Name=" + "e5 Secure Download Manager" + ",Version=" + "3.2.249.0";

      var regex = new Regex(@"^(?<name>\S+)\s+(?<version>\d+(\.\d+)+(-[a-zA-Z0-9]+)*)$");

      var package = this.CreateInstalledPackage(test);
      IEnumerable<string> psOutput = null;
      string cmd = Cmds.ListInstalledPackCmd;
      var result = new List<Package>();
      try
      {
        psOutput = await this.powerShellService.RunCommand(token, cmd);
      }
      catch (Exception)
      {
        throw;
      }

      foreach (var item in psOutput)
      {
        var match = regex.Match(item);
        if (match.Success)
        {
          //var package = this.CreateInstalledPackage();
          //result.Add(package);
        }
        else
        {
          throw new Exception("Impossible");
        }
      }
      return result;
    }

    private InstalledPackage CreateInstalledPackage(string input)
    {
      string[] keys = { "Name=", "Version=", "Win32_Product.IdentifyingNumber=" };
      InstalledPackage installedPackage = new InstalledPackage();
      foreach (var key in keys)
      {
        string regexString = string.Format(@"{0}+\s*(\w*)", key);
        var regex = new Regex(regexString);
        var match = regex.Match(input);

        if (match.Success)
        {
          switch (key)
          {
            case "Name=": installedPackage.Title = match.Groups[1].Value; break;
            case "Version=": installedPackage.Version = match.Groups[1].Value; break;
            default: break;
          }
        }
      }
      return installedPackage;
    }

    public class PackageService : IPackageService
    {
      public Task Install(PackageVersion package)
      {
        throw new NotImplementedException();
      }

      public Task Install(Package package, Action<string> onDataReceived, CancellationToken cancelToken)
      {
        throw new NotImplementedException();
      }

      public Task Uninstall(PackageVersion package)
      {
        throw new NotImplementedException();
      }

      public Task UnInstall(Package package, Action<string> onDataReceived, CancellationToken cancelToken)
      {
        throw new NotImplementedException();
      }
    }
  }
}