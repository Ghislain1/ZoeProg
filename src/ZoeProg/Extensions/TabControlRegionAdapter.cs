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
    using Prism.Regions;
    using ZoeProg.Core;

    /// <summary>
    /// Defines the <see cref="TabControlRegionAdapter"/>.
    /// </summary>
    public sealed class TabControlRegionAdapter : RegionAdapterBase<TabControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabControlRegionAdapter"/> class.
        /// </summary>
        /// <param name="regionBehaviorFactory">The regionBehaviorFactory <see cref="IRegionBehaviorFactory"/>.</param>
        public TabControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        /// <summary>
        /// The Adapt.
        /// </summary>
        /// <param name="region">The region <see cref="IRegion"/>.</param>
        /// <param name="regionTarget">The regionTarget <see cref="TabControl"/>.</param>
        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
            region.ActiveViews.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        foreach (var t in e.NewItems)
                        {
                            var tb = new TabItem();
                            var iv = ((UserControl)e.NewItems[0]).DataContext as IPlugin;
                            tb.Header = iv.Header;
                            tb.DataContext = iv;
                            tb.Content = (UserControl)e.NewItems[0];
                            regionTarget.Items.Insert(regionTarget.Items.Count, tb);
                            regionTarget.SelectedIndex = regionTarget.Items.Count - 1;
                        }

                        break;

                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (var t in e.OldItems)
                        {
                            for (var i = 0; i < regionTarget.Items.Count; i++)
                            {
                                var tab = (TabItem)regionTarget.Items[i];
                                if (tab.Content == e.OldItems[0])
                                {
                                    regionTarget.Items.Remove(tab);
                                }
                            }
                            regionTarget.SelectedIndex = regionTarget.Items.Count - 1;
                        }

                        break;
                }
            };
        }

        /// <summary>
        /// The CreateRegion.
        /// </summary>
        /// <returns>The <see cref="IRegion"/>.</returns>
        protected override IRegion CreateRegion() => new AllActiveRegion();
    }
}