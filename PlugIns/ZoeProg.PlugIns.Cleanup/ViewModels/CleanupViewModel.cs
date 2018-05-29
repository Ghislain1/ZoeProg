namespace ZoeProg.PlugIns.Cleanup.ViewModels
{
    using Prism.Mvvm;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CleanupViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
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