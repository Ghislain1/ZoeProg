namespace ZoeProg
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using ZoeProg.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell(IShellViewModel shellViewModel)
        {
            InitializeComponent();
            this.DataContext = shellViewModel;
        }
    }
}