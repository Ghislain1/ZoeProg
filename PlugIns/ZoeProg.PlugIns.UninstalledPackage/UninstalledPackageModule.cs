namespace ZoeProg.PlugIns.UninstalledPackage
{
    using ZoeProg.Common;
    using System;
    using ZoeProg.Common.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class UninstalledPackageModule : PlugInBase, IPlugIn
    {
        //private readonly IUnityContainer container;
        //private readonly IPlugInService plugInService;
        //private readonly IRegionManager regionManager;
        private string code;

        private string description;
        private string id;
        private bool isSelected;
        private string title;

        //public UninstalledPackageModule(IRegionManager regionManager, IUnityContainer container) : base()
        //{
        //    this.regionManager = regionManager;
        //    this.container = container;
        //    base.NavigatePath = nameof(UninstalledPackageListView);
        //    base.Title = "Uninstalled Package";
        //}

        public void Initialize()
        {
            //    this.container.RegisterType<IUninstalledPackageProvider, UninstalledPackageProvider>(new ContainerControlledLifetimeManager());

            //  //  this.container.RegisterTypeForNavigation<UninstalledPackageListView>();

            //    this.IsSelected = true;
        }
    }
}