using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZoeProg.Common;
using ZoeProg.PlugIns.Uninstall.Models;

namespace ZoeProg.PlugIns.Uninstall.ViewModels
{
    public class UninstallPackagesViewModel : BindableBase
    {
        private readonly IPowerShellService powerShellService;

        public UninstallPackagesViewModel(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;
            this.LoadAsync().GetAwaiter();
        }

        private async Task LoadAsync()
        {
            var token = CancellationToken.None;
            var command = "Get-WmiObject -Query 'Select * from win32_product'";
            var collection = await this.powerShellService.RunCommand(token, command);
            this.Items = new ObservableCollection<InstalledPackage>();
            foreach (var item in collection)
            {
                var pkg = new InstalledPackage() { Title = item.ToString()};
                this.items.Add(pkg);
            }
        }
        ObservableCollection<InstalledPackage> items;
        public ObservableCollection<InstalledPackage> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }
        public string Header { get; } = " Uninstall Programs";



    }

    
}
