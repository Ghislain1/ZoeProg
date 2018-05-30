namespace ZoeProg.PlugIns.Cleanup.ViewModels
{
    using Prism.Mvvm;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZoeProg.Common;

    public class CleanupViewModel : BindableBase, INavigationAware, IRegionMemberLifetime, IContentMetadata
    {
        public CleanupViewModel()
        {
        }

        public bool KeepAlive
        {
            get
            {
                return false;
            }
        }

        public string Name { get; set; } = "GHislaib CleanUP";
        public string Source { get; set; } = "/Views/CleanupView.xaml";

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}