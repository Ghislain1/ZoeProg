namespace ZoeProg.Views
{
    using FirstFloor.ModernUI.Windows.Controls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : ModernWindow
    {
        public Shell()
        {
            InitializeComponent();
           // LoadLinks();
        }

        private async void LoadLinks()
        {
            var loader = (PrismContentLoader)this.ContentLoader;

            try
            {
                // load image links and assign to tab list
                this.MenuLinkGroups = new FirstFloor.ModernUI.Presentation.LinkGroupCollection();

                var linkGr = new FirstFloor.ModernUI.Presentation.LinkGroup();
          
                
                
                 var Links = await loader.GetInterestingnessListAsync();

                // select first link
              //  linkGr.SelectedSource = Links.Select(l => l.Source).FirstOrDefault();
            }
            catch (Exception e)
            {
                ModernDialog.ShowMessage(e.Message, "Failure", MessageBoxButton.OK);
            }
        }
    }
}