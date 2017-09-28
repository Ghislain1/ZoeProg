using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
      this.Width = this.Owner.Width;
      this.Height = this.Owner.Height;
      this.WindowStyle = WindowStyle.None;
      this.WindowStartupLocation = this.Owner.WindowStartupLocation;
      this.Top = this.Owner.Top;
      this.Left = this.Owner.Left;
      this.MouseMove += (s, e) => { };
    }
  }
}