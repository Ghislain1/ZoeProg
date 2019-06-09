namespace ZoeProg.PlugIns.Home
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using ZoeProg.PlugIns.Home.Views;

    public class HomeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("TabRegion", typeof(HomeView));
           
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}