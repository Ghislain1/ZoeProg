using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ZoeProg.PlugIns.Cleanup.Views
{
    /// <summary>
    /// Interaction logic for CleanupView.xaml
    /// </summary>
    public partial class CleanupView : UserControl, IContent
    {
        public CleanupView()
        {
            InitializeComponent();
        }

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