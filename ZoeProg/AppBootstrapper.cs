namespace ZoeProg
{
    using Common;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Unity;
    using Services;
    using System.Windows;
    using Unity.Lifetime;
    using ZoeProg.ViewModels;
    using static Services.PackageRepository;

    public class AppBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            this.Container.RegisterType<IShellViewModel, ShellViewModel>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IProgressMonitor, ProgressMonitor>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ITaskService, TaskService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IProgressService, ProgressService>(new ContainerControlledLifetimeManager());

            base.ConfigureContainer();
        }

        protected override void ConfigureServiceLocator()
        {
            this.Container.RegisterType<IPowerShellService, PowerShellService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IPackageService, PackageService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IPackageRepository, PackageRepository>(new ContainerControlledLifetimeManager());

            this.Container.RegisterType<IPlugInService, PlugInService>(new ContainerControlledLifetimeManager());

            base.ConfigureServiceLocator();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
        }

        //protected override Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        //{
        //  var factory = base.ConfigureDefaultRegionBehaviors();
        //  return factory;
        //}

        //protected override void ConfigureModuleCatalog()
        //{
        //  base.ConfigureModuleCatalog();
        //}

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow.Show();
        }
    }
}