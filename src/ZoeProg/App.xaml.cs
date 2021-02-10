/*-
 * ---license-start
 * Zoe-App
 * ---
 * Copyright (C) 2021 GhislainOne and all other contributors
 * ---
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ---license-end
 */

namespace ZoeProg
{
    using System.Globalization;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using Ghis.PowershellLib;
    using MahApps.Metro.Controls;
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
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            // WOrk around: https://github.com/dotnet/wpf/issues/738
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            RegionAdapterMappings mappings = regionAdapterMappings;
            var regionBehaviorFactory = Container.Resolve<IRegionBehaviorFactory>();
            // mappings.RegisterMapping(typeof(TabablzControl), new
            // TabablzControlRegionAdapter(regionBehaviorFactory));
            // mappings.RegisterMapping(typeof(ListView), new ListViewRegionAdapter(regionBehaviorFactory));
            mappings.RegisterMapping(typeof(TabControl), new TabControlRegionAdapter(regionBehaviorFactory));

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
            return Container.Resolve<Shell>();
        }

        /// <summary>
        /// The RegisterTypes.
        /// </summary>
        /// <param name="containerRegistry">The containerRegistry <see cref="IContainerRegistry"/>.</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPowershellService, PowershellService>();
        }
    }
}