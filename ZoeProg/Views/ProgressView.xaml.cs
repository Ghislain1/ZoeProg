using System.Windows;

namespace ZoeProg.Views
{
    /// <summary>
    /// Interaction logic for ProgressView.xaml
    /// </summary>
    public partial class ProgressView : Window
    {
        public ProgressView()
        {
            InitializeComponent();
            this.Owner = Application.Current.MainWindow;
            this.Width = this.Owner.ActualWidth;
            this.Height = this.Owner.ActualHeight;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = false;
            this.WindowStartupLocation = this.Owner.WindowStartupLocation;
            this.Top = this.Owner.Top;
            this.Left = this.Owner.Left;
            this.MouseMove += (s, e) => { };
        }
    }
}