using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoeProg.PlugIns.Uninstall.Views;

namespace ZoeProg.PlugIns.Uninstall
{
    public class UninstallModule   : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("TabRegion", typeof(UninstallPackagesView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}