﻿using System.Windows.Controls;

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
    }
}