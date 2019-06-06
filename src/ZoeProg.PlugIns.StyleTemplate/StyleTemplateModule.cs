

namespace ZoeProg.PlugIns.StyleTemplate
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZoeProg.PlugIns.StyleTemplate.Views;

    public class StyleTemplateModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("TabRegion", typeof(StyleTemplateView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}