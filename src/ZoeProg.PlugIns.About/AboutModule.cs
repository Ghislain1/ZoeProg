namespace ZoeProg.PlugIns.About
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using ZoeProg.Core.Constants;
    using ZoeProg.PlugIns.Home.Views;

    /// <summary>
    /// About for logic module
    /// </summary>
    /// <seealso cref="Prism.Modularity.IModule"/>
    public class AboutModule : IModule
    {
        /// <summary>
        /// Notifies the module that it has been initialized.
        /// </summary>
        /// <param name="containerProvider">Container provider</param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.OptionRegion, typeof(AboutView));
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry">container registry</param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}