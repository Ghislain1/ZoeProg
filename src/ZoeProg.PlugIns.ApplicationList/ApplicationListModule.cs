// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace ZoeProg.PlugIns.ApplicationList;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ZoeProg.Core.Constants;
using System;
using ZoeProg.PlugIns.ApplicationList.Services;
using ZoeProg.PlugIns.ApplicationList.Views;

public sealed class ApplicationListModule : IModule
{
    /// <summary>
    /// Notifies the module that it has been initialized.
    /// </summary>
    /// <param name="containerProvider">Container provider.</param>
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(RegionNames.HamburgerMenuItemCollectionRegion, typeof(ApplicationListView));
    }

    /// <summary>
    /// Used to register types with the container that will be used by your application.
    /// </summary>
    /// <param name="containerRegistry">container registry.</param>
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IApplicationListService, ApplicationListService>();
    }
}

