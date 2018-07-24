using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace RadGridViewWpfApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = new MainWindowViewModel();
    }

    private void radWatermarkSerachTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
      var searchByTextComand = Telerik.Windows.Controls.RadGridViewCommands.SearchByText as System.Windows.Input.RoutedUICommand;

      searchByTextComand.Execute(this.radWatermarkSerachTextBox.Text, this.RadGridView1);
    }
  }
}