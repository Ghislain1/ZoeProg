namespace ZoeProg.PlugIns.Audit
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using ZoeProg.Core;
    using ZoeProg.PlugIns.Audit.Services;
    using ZoeProg.PlugIns.Audit.Views;

    public class AuditModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.HamburgerMenuItemCollectionRegion, typeof(AuditView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IProcessProvider, ProcessProvider>();
        }
    }
}