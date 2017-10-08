namespace ZoeProg.PlugIns.UninstalledPackage
{
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZoeProg.Common;
    using ZoeProg.Common.Data;
    using ZoeProg.PlugIns.UninstalledPackage.Services;
    using ZoeProg.PlugIns.UninstalledPackage.Views;

    public class UninstalledPackageModule : PlugInBase, IModule, IPlugIn
    {
        private readonly IUnityContainer container;
        private readonly IPlugInService plugInService;
        private readonly IRegionManager regionManager;
        private string code;
        private string description;
        private string id;
        private bool isSelected;
        private string title;

        public UninstalledPackageModule(IRegionManager regionManager, IUnityContainer container) : base()
        {
            this.regionManager = regionManager;
            this.container = container;
            base.NavigatePath = nameof(UninstalledPackageListView);
            base.Title = "Uninstalled Package";
        }

        public void Initialize()
        {
            this.container.RegisterType<IUninstalledPackageProvider, UninstalledPackageProvider>(new ContainerControlledLifetimeManager());

            this.container.RegisterTypeForNavigation<UninstalledPackageListView>();

            this.IsSelected = true;
        }
    }
}