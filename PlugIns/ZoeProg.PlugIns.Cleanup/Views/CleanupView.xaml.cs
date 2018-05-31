using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ZoeProg.Common;

namespace ZoeProg.PlugIns.Cleanup.Views
{
    /// <summary>
    /// Interaction logic for CleanupView.xaml
    /// </summary>
    public partial class CleanupView : UserControl
    {
        public CleanupView()
        {
            InitializeComponent();
            this.DisplayName = "CleanUp";
            this.Source = "";
        }

        public string DisplayName { get; set; }
        public string Source { get; set; }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }
    }
}