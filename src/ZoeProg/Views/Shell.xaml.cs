namespace ZoeProg.Views
{
    using MahApps.Metro.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : MetroWindow
    {
        public Shell()
        {
            InitializeComponent();
        }

        private void HamburgerMenuControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            // this.HamburgerMenuControl.Content = (e.ClickedItem as HamburgerMenuGlyphItem).Tag;
            // this.HamburgerMenuControl.IsPaneOpen = false;
            var ds = this.HamburgerMenuControl.SelectedItem;
        }
    }
}