namespace ZoeProg
{
    using MahApps.Metro.Controls;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using System.Windows;
    using System.Windows.Controls;
    using ZoeProg.Common;
    using ZoeProg.Extensions;
    using ZoeProg.Services;
    using ZoeProg.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
             
            containerRegistry.RegisterSingleton<IPowerShellService, PowerShellService>();
        }

        protected override  void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            RegionAdapterMappings mappings = regionAdapterMappings;
            var regionBehaviorFactory = Container.Resolve<IRegionBehaviorFactory>();
            // mappings.RegisterMapping(typeof(TabablzControl), new TabablzControlRegionAdapter(regionBehaviorFactory));
          //  mappings.RegisterMapping(typeof(ListView), new ListViewRegionAdapter(regionBehaviorFactory));
            mappings.RegisterMapping(typeof(TabControl), new TabControlRegionAdapter(regionBehaviorFactory));

            mappings.RegisterMapping(typeof(HamburgerMenuItemCollection), this.Container.Resolve<HamburgerMenuItemCollectionRegionAdapter>());        



        }
    }
}