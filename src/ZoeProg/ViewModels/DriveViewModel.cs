

namespace ZoeProg.ViewModels
{
    using Prism.Mvvm;
    using ZoeProg.Common;
    using ZoeProg.Common.Models;

    public class DriveViewModel : BindableBase
    {
        private readonly IApplicationCommands applicationCommands;
        private double freeGB;
        private bool isChecked;

        private string name;

        private ProviderType provider;

        private string root;
        private ISettingService settingService;

        public DriveViewModel(ISettingService settingService, IApplicationCommands applicationCommands)
        {
            this.applicationCommands = applicationCommands;
            this.settingService = settingService;
        }

        public double FreeGB
        {
            get { return freeGB; }
            set { SetProperty(ref freeGB, value); }
        }

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                SetProperty(ref isChecked, value);
                if (value)
                {
                    var driver = new Drive() { Name = name };
                    // this.settingService.UpdateDrivers( )
                }
            }
        }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public ProviderType Provider
        {
            get { return provider; }
            set { SetProperty(ref provider, value); }
        }

        public string Root
        {
            get { return root; }
            set { SetProperty(ref root, value); }
        }

        public double UsedGB { get; set; }

        public void Init(Drive i)
        {
            this.Name = i.Name;
            this.Provider = i.Provider; this.Root = i.Root;
            this.FreeGB = i.FreeGB;
        }
    }
}