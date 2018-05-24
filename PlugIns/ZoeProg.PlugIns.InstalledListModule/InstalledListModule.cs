namespace ZoeProg.PlugIns.InstalledList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using InstalledList.Views;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using Services;
    using ZoeProg.Common.Data;

    public class InstalledListModule : PlugInBase, IModule, IPlugIn
    {
        private readonly IUnityContainer container;
        private readonly IPlugInService plugInService;
        private readonly IRegionManager regionManager;
        private string code;
        private string description;
        private string id;
        private bool isSelected;
        private string title;

        public InstalledListModule(IRegionManager regionManager, IUnityContainer container) : base()
        {
            this.regionManager = regionManager;
            this.container = container;
            base.NavigatePath = "InstalledListView";
            base.Title = "Installed Package";
        }

        public void Initialize()
        {
            this.container.RegisterType<IInstalledProgramService, InstalledProgramService>(new ContainerControlledLifetimeManager());
            //this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(InstalledListView));
            this.container.RegisterTypeForNavigation<InstalledListView>();

            this.IsSelected = true;
        }
    }
}