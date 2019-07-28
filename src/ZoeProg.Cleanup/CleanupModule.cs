using System;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ZoeProg.Cleanup.Views;
using ZoeProg.Common;

namespace ZoeProg.Cleanup
{
    public sealed class CleanupModule:IModule
    {


        /// <summary>
        /// Notifies the module that it has been initialized.
        /// </summary>
        /// <param name="containerProvider"> Container provider </param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.HamburgerMenuItemCollectionRegion, typeof(CleanupView));

        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry">container registry </param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
