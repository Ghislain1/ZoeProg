// <copyright file="SettingsAppearance.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ZoeProg.Views
{
    using System.Windows.Controls;
    using ZoeProg.ViewModels;

    /// <summary>
    /// Interaction logic for SettingsAppearance.xaml.
    /// </summary>
    public partial class SettingsAppearance : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsAppearance"/> class.
        /// </summary>
        public SettingsAppearance()
        {
            this.InitializeComponent();
            this.DataContext = new SettingsAppearanceViewModel();
        }
    }
}