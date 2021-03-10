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

namespace ZoeProg.PlugIns.CleanUp
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using ZoeProg.Cleanup.Services;

    using ZoeProg.Core.Constants;
    using ZoeProg.PlugIns.CleanUp.Views;

    /// <summary>
    /// Defines the <see cref="CleanUpModule"/>.
    /// </summary>
    public sealed class CleanUpModule : IModule
    {
        /// <summary>
        /// Notifies the module that it has been initialized.
        /// </summary>
        /// <param name="containerProvider">Container provider.</param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            // regionManager.AddToRegion(RegionNames.HamburgerMenuItemCollectionRegion, containerProvider.Resolve<CleanupView>());
            regionManager.RegisterViewWithRegion(RegionNames.HamburgerMenuItemCollectionRegion, typeof(CleanUpView));
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        /// <param name="containerRegistry">container registry.</param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICleanupService, CleanupService>();
        }
    }
}