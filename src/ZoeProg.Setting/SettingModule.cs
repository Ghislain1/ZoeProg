// <copyright file="SettingModule.cs" company="PlaceholderCompany">
//     Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ZoeProg.Setting
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using ZoeProg.Core;
    using ZoeProg.Setting.Views;

    /// <summary>
    /// Entry point for this component.
    /// </summary>
    /// <seealso cref="Prism.Modularity.IModule"/>
    public sealed class SettingModule : IModule
    {
        /// <summary>
        /// Notifies the module that it has been initialized.
        /// </summary>
        /// <param name="containerProvider">Container provider.</param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.HamburgerMenuItemCollectionRegion, typeof(SettingView));
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry">container registry.</param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // containerRegistry.RegisterSingleton<ICleanupService, CleanupService>();
        }
    }
}