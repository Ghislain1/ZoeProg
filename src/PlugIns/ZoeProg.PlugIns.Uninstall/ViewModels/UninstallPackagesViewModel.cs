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
    public class UninstallPackagesViewModel : BindableBase, IPluginHeader
    {
        private readonly IPowerShellService powerShellService;
        ObservableCollection<InstalledPackage> items;
        bool isBusy;

        public UninstallPackagesViewModel(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;
         
            this.LoadAsync().GetAwaiter();
        }

        private async Task LoadAsync()
        {
            this.IsBusy = true;
            var token = CancellationToken.None;
            var command = "Get-WmiObject -Query 'Select * from win32_product'";
            var collection = await this.powerShellService.RunCommand(token, command);
            this.Items = new ObservableCollection<InstalledPackage>();
            foreach (var item in collection)
            {
                var pkg = new InstalledPackage() { Title = item.ToString()};
                this.items.Add(pkg);
            }
            this.IsBusy = false;
        }
    
        public ObservableCollection<InstalledPackage> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public  bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }


        
        public string Header { get; } = " Uninstall Programs";



    }

    
}
