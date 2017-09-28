namespace ZoeProg.PlugIns.InstalledList
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using Common;
  using InstalledList.Views;
  using Microsoft.Practices.Unity;
  using Prism.Regions;
  using Prism.Modularity;
  using Services;

  public class InstalledListModule : IModule
  {
    private readonly IUnityContainer container;
    private readonly IRegionManager regionManager;

    public InstalledListModule(IRegionManager regionManager, IUnityContainer container)
    {
      this.regionManager = regionManager;
      this.container = container;
    }

    public void Initialize()
    {
      this.container.RegisterType<IInstalledProgramService, InstalledProgramService>(new ContainerControlledLifetimeManager());

      this.regionManager.RegisterViewWithRegion(RegionNames.TabRegion, typeof(InstalledView));
    }
  }
}