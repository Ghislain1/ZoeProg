using System.Windows.Controls;
using ZoeProg.ViewModels;

namespace ZoeProg.Views
{
    /// <summary>
    /// Interaction logic for SettingsAppearance.xaml
    /// </summary>
    public partial class SettingsAppearance : UserControl
    {
        public SettingsAppearance()
        {
            InitializeComponent();
            this.DataContext = new SettingsAppearanceViewModel();
        }
    }
}