namespace ZoeProg.PlugIns.Cleanup
{
    using FirstFloor.ModernUI.Presentation;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Cleanup.Views;

    public class CleanupModule : LinkGroup, IModule, ILinkGroup
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public CleanupModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<CleanupView>();
        }
    }
}