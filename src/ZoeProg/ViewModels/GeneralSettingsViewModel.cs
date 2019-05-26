using Prism.Mvvm;
using System.Collections.ObjectModel;
using Unity;
using ZoeProg.Common;

namespace ZoeProg.ViewModels
{
    public class GeneralSettingsViewModel : BindableBase
    {
        private readonly ISettingService settingService;
        private readonly IUnityContainer unityContainer;

        private ObservableCollection<DriveViewModel> driverItems;

        public GeneralSettingsViewModel(IUnityContainer unityContainer, ISettingService settingService)
        {
            this.unityContainer = unityContainer;
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
            this.DriverItems = new ObservableCollection<DriveViewModel>();
            foreach (var item in res)
            {
                //TODO: Find a way to resolve with paramter
                var driveViewModel = this.unityContainer.Resolve<DriveViewModel>();
                driveViewModel.Init(item);
                this.DriverItems.Add(driveViewModel);
            }
        }
    }
}