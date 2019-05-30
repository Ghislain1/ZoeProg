namespace ZoeProg
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Unity;
    using System.Windows;
    using ZoeProg.Common;
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
    }
}