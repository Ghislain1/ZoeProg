// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="PlaceholderCompany">
//     Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ZoeProg
{
    using System.Windows;
    using Ghis.PowershellLib;
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using ZoeProg.Extensions;
    using ZoeProg.Views;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// The ConfigureRegionAdapterMappings.
        /// </summary>
        /// <param name="regionAdapterMappings">The regionAdapterMappings <see cref="RegionAdapterMappings"/>.</param>
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings mappings)
        {
            // WOrk around: https://github.com/dotnet/wpf/issues/738
            // Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            base.ConfigureRegionAdapterMappings(mappings);
            mappings.RegisterMapping(typeof(HamburgerMenuItemCollection), this.Container.Resolve<HamburgerMenuItemCollectionRegionAdapter>());
        }

        /// <summary>
        /// The CreateModuleCatalog.
        /// </summary>
        /// <returns>The <see cref="IModuleCatalog"/>.</returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        /// <summary>
        /// The CreateShell.
        /// </summary>
        /// <returns>The <see cref="Window"/>.</returns>
        protected override Window CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        /// <summary>
        /// The RegisterTypes.
        /// </summary>
        /// <param name="containerRegistry">The containerRegistry <see cref="IContainerRegistry"/>.</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPowershellService, PowershellService>();
            // We dont  need it ==>  Dialog:DialogParticipation.Register="{Binding}" on desired view
            containerRegistry.RegisterSingleton<IDialogCoordinator>( () =>DialogCoordinator.Instance);

        }
    }
}