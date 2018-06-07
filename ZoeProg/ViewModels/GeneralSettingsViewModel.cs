using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoeProg.Common;

namespace ZoeProg.ViewModels
{
    public class GeneralSettingsViewModel : BindableBase
    {
        private readonly ISettingService settingService;

        private ObservableCollection<object> driverItems;

        public GeneralSettingsViewModel(ISettingService settingService)
        {
            this.settingService = settingService;
            this.LoadDrivers();
        }

        public ObservableCollection<object> DriverItems
        {
            get { return driverItems; }
            set { SetProperty(ref driverItems, value); }
        }

        private async void LoadDrivers()
        {
            var res = await this.settingService.GetDriverList();
            this.DriverItems = new ObservableCollection<object>(res);
        }
    }
}