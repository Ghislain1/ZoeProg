

namespace ZoeProg.Home
{
    using System;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using ZoeProg.Common;
    using ZoeProg.Home.Views;

    /// <summary>
    /// Home for logic module
    /// </summary>
    /// <seealso cref="Prism.Modularity.IModule" />
    public class HomeModule : IModule
    {
        /// <summary>
        /// Notifies the module that it has been initialized.
        /// </summary>
        /// <param name="containerProvider"> Container provider </param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.HamburgerMenuItemCollectionRegion, typeof(HomeView));

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
