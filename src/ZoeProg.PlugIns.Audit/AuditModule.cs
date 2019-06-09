

namespace ZoeProg.PlugIns.Audit
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Audit.Services;
    using ZoeProg.PlugIns.Audit.Views;

    public class AuditModule : IModule
        {
            public void OnInitialized(IContainerProvider containerProvider)
            {
                var regionManager = containerProvider.Resolve<IRegionManager>();
                regionManager.RegisterViewWithRegion(RegionNames.TabRegion ,typeof(AuditView));
                
            }

            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                  containerRegistry.Register<IProcessProvider, ProcessProvider>();
       
            }
        }
    
}
