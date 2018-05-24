namespace ZoeProg.PlugIns.Home
{
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZoeProg.Common;
    using ZoeProg.Common.Data;

    public class HomeModule : PlugInBase, IModule, IPlugIn
    {
        private readonly IUnityContainer container;
        private readonly IPlugInService plugInService;
        private readonly IRegionManager regionManager;

        public HomeModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
            this.Id = Guid.NewGuid().ToString();
            //   base.NavigatePath = nameof(HomeView);

            base.Title = "Overview";
        }

        public void Initialize()
        {
            // this.container.RegisterType<IInstalledProgramService, InstalledProgramService>(new ContainerControlledLifetimeManager());

            //this.container.RegisterTypeForNavigation<HomeView>();
        }
    }
}