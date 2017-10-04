namespace ZoeProg.PlugIns.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.Practices.Unity;
    using Prism.Regions;
    using Prism.Modularity;
    using Services;
    using Common;
    using Views;
    using ZoeProg.Common.Data;
    using Prism.Unity;

    public class SettingModule : PlugInBase, IModule, IPlugIn
    {
        private readonly IUnityContainer container;
        private readonly IPlugInService plugInService;
        private readonly IRegionManager regionManager;

        public SettingModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
            this.NavigatePath = nameof(SettingView);
        }

        public void Initialize()
        {
            this.container.RegisterType<ISettingService, SettingService>(new ContainerControlledLifetimeManager());

            this.regionManager.RegisterViewWithRegion(RegionNames.TabRegion, typeof(SettingView));

            this.container.RegisterTypeForNavigation<SettingView>();
        }
    }
}