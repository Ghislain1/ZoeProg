namespace ZoeProg
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Unity;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}