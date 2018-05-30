namespace ZoeProg
{
    using FirstFloor.ModernUI.Presentation;
    using Microsoft.Practices.Unity;

    using Prism.Modularity;
    using Prism.Unity;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Cleanup;
    using ZoeProg.Views;

    public class AppBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()       {
             
           

             var prismContentLoader = this.Container.Resolve<PrismContentLoader>();

            Application.Current.Resources.Add("PrismContentLoader", prismContentLoader);

            var shell= Container.Resolve<Shell>();
           // shell.ContentLoader = prismContentLoader;

            return shell;
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
            bool MyInterfaceFilter(Type typeObj, Object criteriaObj)
        {
            if (typeObj.ToString() == criteriaObj.ToString())
                return true;
            else
                return false;
        }
        protected override void ConfigureModuleCatalog()
        {
         


            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(CleanupModule));

             var linkGroupCollection = new LinkGroupCollection();
            var typeFilter = new TypeFilter(MyInterfaceFilter);

            foreach (var module in catalog.Items)
            {
                return;
                var mi = (ModuleInfo)module;

                   mi.Ref = "ZoeProg.PlugIns.Cleanup.dll";
                var asm = Assembly.LoadFrom(mi.Ref);

                foreach (Type t in asm.GetTypes())
                {
                    var myInterfaces = t.FindInterfaces(typeFilter, typeof(ILinkGroup).ToString());

                    if( myInterfaces.Any())
                    {
                        // We found the type that implements the ILinkGroupService interface
                        var linkGroupService = (ILinkGroup)asm.CreateInstance(t.FullName);
                        // var linkGroup = linkGroupService.GetLinkGroup();
                      //  linkGroupCollection.Add(linkGroup);
                    }
                }
            }

            

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

        //    //this.Container.RegisterType<IPlugInService, PlugInService>(new ContainerControlledLifetimeManager());

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