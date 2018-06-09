namespace ZoeProg
{
    using FirstFloor.ModernUI.Presentation;
    using Microsoft.Practices.Unity;

    using Prism.Modularity;
    using Prism.Unity;
    using System;
    using System.Linq;
    using System.Windows;
    using ZoeProg.Common;
    using ZoeProg.Services;
    using ZoeProg.Settings;
    using ZoeProg.Views;

    public class AppBootstrapper : UnityBootstrapper
    {
        private IModuleMetadata moduleMetadata;
        private Shell shell;

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            ///
            this.Container.RegisterType<ISettingService, SettingService>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IApplicationCommands, ApplicationCommands>(new ContainerControlledLifetimeManager());

            this.Container.RegisterType<IPowerShellService, PowerShellService>(new ContainerControlledLifetimeManager());

            this.Container.RegisterType<ILinkMetadataService, LinkMetadataService>(new ContainerControlledLifetimeManager());
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            shell = Container.Resolve<Shell>();
            return shell;
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();

            var moduleMetadataService = this.Container.Resolve<ILinkMetadataService>();
            var collection = moduleMetadataService.LinkMetaDataList;
            foreach (var item in collection)
            {
                //Update shell with each link!!
                this.UpdateShell(item);
            }

            //Add now a resource for the all app.
            var prismContentLoader = this.Container.Resolve<PrismContentLoader>();
            Application.Current.Resources.Add("PrismContentLoader", prismContentLoader);
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        private void UpdateShell(ILinkMetadata item)
        {
            var linkGroup = shell.MenuLinkGroups.FirstOrDefault(i => i.DisplayName == item.ParentName);
            if (linkGroup == null)
            {
                linkGroup = new LinkGroup();
                linkGroup.DisplayName = item.ParentName;
                shell.MenuLinkGroups.Add(linkGroup);
            }

            var link = new Link() { DisplayName = item.DisplayName, Source = new Uri(item.Source, UriKind.RelativeOrAbsolute) };
            linkGroup.Links.Add(link);
        }

        //protected override void ConfigureContainer()
        //{
        //    //this.Container.RegisterType<IShellViewModel, ShellViewModel>(new ContainerControlledLifetimeManager());
        //    //this.Container.RegisterType<IProgressMonitor, ProgressMonitor>(new ContainerControlledLifetimeManager());
        //    //this.Container.RegisterType<ITaskService, TaskService>(new ContainerControlledLifetimeManager());
        //    //this.Container.RegisterType<IProgressService, ProgressService>(new ContainerControlledLifetimeManager());

        //    base.ConfigureContainer();
        //}

        //protected override void ConfigureServiceLocator()
        //{
        //    //this.Container.RegisterType<IPowerShellService, PowerShellService>(new ContainerControlledLifetimeManager());
        //    //this.Container.RegisterType<IPackageService, PackageService>(new ContainerControlledLifetimeManager());
        //    //this.Container.RegisterType<IPackageRepository, PackageRepository>(new ContainerControlledLifetimeManager());

        // //this.Container.RegisterType<IPlugInService, PlugInService>(new ContainerControlledLifetimeManager());

        //    base.ConfigureServiceLocator();
        //}

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new ConfigurationModuleCatalog();
        //}

        //protected override DependencyObject CreateShell()
        //{
        //    return Container.Resolve<Shell>();
        //}

        //protected override void InitializeModules()
        //{
        //    base.InitializeModules();
        //}

        //protected override Prism.Regions.IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        //{
        //  var factory = base.ConfigureDefaultRegionBehaviors();
        //  return factory;
        //}

        //protected override void ConfigureModuleCatalog()
        //{
        //  base.ConfigureModuleCatalog();
        //}

        //protected override void InitializeShell()
        //{
        //    base.InitializeShell();

        //    App.Current.MainWindow.Show();
        //}
    }
}