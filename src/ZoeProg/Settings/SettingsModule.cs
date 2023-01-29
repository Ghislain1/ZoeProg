// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace ZoeProg.Settings;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoeProg.Core.Constants;
using ZoeProg.Settings.Views;

public class SettingsModule : IModule
{
    /// <summary>
    /// Notifies the module that it has been initialized.
    /// </summary>
    /// <param name="containerProvider">Container provider.</param>
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion(RegionNames.OptionRegion, typeof(SettingView));
    }

    /// <summary>
    /// Used to register types with the container that will be used by your application.
    /// </summary>
    /// <param name="containerRegistry">container registry.</param>
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
}