namespace ZoeProg.PlugIns.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using Services;
    using Unity;
    using Views;
    using ZoeProg.Common.Data;

    public class SettingModule : PlugInBase, IModule, IPlugIn
    {
        private readonly IUnityContainer container;
        private readonly IPlugInService plugInService;
        private readonly IRegionManager regionManager;

        public SettingModule(IRegionManager regionManager, IUnityContainer container)
        {
            //this.regionManager = regionManager;
            //this.container = container;
            //this.NavigatePath = nameof(SettingView);
            //this.Title = "Settings";
        }

        public void Initialize()
        {
            //this.container.RegisterType<ISettingService, SettingService>(new ContainerControlledLifetimeManager());

            //this.regionManager.RegisterViewWithRegion(RegionNames.TabRegion, typeof(SettingView));

            //this.container.RegisterTypeForNavigation<SettingView>();
        }
    }
}