namespace ZoeProg.PlugIns.InstalledList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common;
    using InstalledList.Views;
    using Microsoft.Practices.Unity;
    using Prism.Regions;
    using Prism.Modularity;
    using Services;
    using System.ComponentModel;
    using ZoeProg.Common.Data;
    using Prism.Unity;

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