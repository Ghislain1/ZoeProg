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

namespace ZoeProg.Extensions
{
    using System.Windows.Controls;
    using MahApps.Metro.Controls;
    using Prism.Regions;
    using ZoeProg.Core;

    /// <summary>
    /// Defines the <see cref="HamburgerMenuItemCollectionRegionAdapter"/>.
    /// </summary>
    public class HamburgerMenuItemCollectionRegionAdapter : RegionAdapterBase<HamburgerMenuItemCollection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HamburgerMenuItemCollectionRegionAdapter"/> class.
        /// </summary>
        /// <param name="regionBehaviorFactory">The regionBehaviorFactory <see cref="IRegionBehaviorFactory"/>.</param>
        public HamburgerMenuItemCollectionRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        /// <summary>
        /// The Adapt.
        /// </summary>
        /// <param name="region">The region <see cref="IRegion"/>.</param>
        /// <param name="regionTarget">The regionTarget <see cref="HamburgerMenuItemCollection"/>.</param>
        protected override void Adapt(IRegion region, HamburgerMenuItemCollection regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (var element in e.NewItems)
                    {
                        var sd = new TabItem();
                        // Glyph = "/Assets/OptionOne.png";

                        // Label = "Option One";

                        // Command = ApplicationCommands.NavigateCommand;

                        // CommandParameter = typeof(OptionOnePageView);
                        var plugin = ((UserControl)element).DataContext as IPlugin;
                        var hamburgerMenuGlyphItem = new HamburgerMenuGlyphItem();
                        hamburgerMenuGlyphItem.Glyph = plugin.Glyph; // @"C:\Users\Zoe\Desktop\___Z_Todelte\ZoeProg\src\ZoeProg\images\background.love.jpg";
                        hamburgerMenuGlyphItem.Label = plugin.Label;
                        hamburgerMenuGlyphItem.CommandParameter = plugin.CommandParameter;
                        hamburgerMenuGlyphItem.Tag = element;

                        // hamburgerMenuGlyphItem. CommandParameter = element.GetType();
                        regionTarget.Add(hamburgerMenuGlyphItem);
                        // regionTarget.Freeze();
                    }
                }
            };
        }

        /// <summary>
        /// The CreateRegion.
        /// </summary>
        /// <returns>The <see cref="IRegion"/>.</returns>
        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}