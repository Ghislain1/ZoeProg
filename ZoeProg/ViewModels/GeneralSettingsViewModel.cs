using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoeProg.Common;
using ZoeProg.Common.Models;

namespace ZoeProg.ViewModels
{
    public class GeneralSettingsViewModel : BindableBase
    {
        private readonly ISettingService settingService;

        private ObservableCollection<DriveViewModel> driverItems;

        public GeneralSettingsViewModel(ISettingService settingService)
        {
            this.settingService = settingService;
            this.LoadDrivers();
        }

        public ObservableCollection<DriveViewModel> DriverItems
        {
            get { return driverItems; }
            set { SetProperty(ref driverItems, value); }
        }

        private async void LoadDrivers()
        {
            var res = await this.settingService.GetDriverList();

            var list = res.Select(i => new DriveViewModel() { Name = i.Name, Provider = i.Provider, Root = i.Root, FreeGB = i.FreeGB });
            this.DriverItems = new ObservableCollection<DriveViewModel>(list);
        }
    }
}