using Prism.Mvvm;
using System;

using System.Collections.ObjectModel;

using System.Threading;
using System.Threading.Tasks;
using ZoeProg.Common;
using ZoeProg.PlugIns.Uninstall.Models;

namespace ZoeProg.PlugIns.Uninstall.ViewModels
{
  public class UninstallPackagesViewModel : BindableBase, IPlugin
  {
    private readonly IPowerShellService powerShellService;
    private ObservableCollection<InstalledPackage> items;
    private bool isBusy;

    public UninstallPackagesViewModel(IPowerShellService powerShellService)
    {
      this.powerShellService = powerShellService;

      this.LoadAsync().GetAwaiter();
    }

    private async Task LoadAsync()
    {
      this.IsBusy = true;
      var token = CancellationToken.None;
      //var command = "Get-WmiObject -Query 'Select * from win32_product'";
      var command = @"Get-ChildItem -Path HKLM:\Software\Microsoft\Windows\CurrentVersion\";
      var collection = await this.powerShellService.RunCommand(token, command);
      this.Items = new ObservableCollection<InstalledPackage>();
      foreach (var item in collection)
      {
        var pkg = new InstalledPackage() { Title = item.ToString() };
        this.items.Add(pkg);
      }
      this.IsBusy = false;
    }

    public ObservableCollection<InstalledPackage> Items
    {
      get { return items; }
      set { SetProperty(ref items, value); }
    }

    public bool IsBusy
    {
      get { return isBusy; }
      set { SetProperty(ref isBusy, value); }
    }

    public string Header { get; } = " Uninstall Programs";
    public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Title { get; set; } = "Packages";
    public string Kind { get; set; } = "Hops";
  }
}