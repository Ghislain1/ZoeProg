// --------------------------------------------------------------------------------------------------------------
// <copyright file="HamburgerMenuItemCollectionRegionAdapter.cs" company="CompanyName">
//     Copyright 2021 - GhislainOne Inc.
//     Developer: GHISPC\Zoe ( 10.02.2021 18:19:30 )
// </copyright>
// ---------------------------------------------------------------------------------------------------------------

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
            return;
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (var element in e.NewItems)
                    {
                        var plugin = ((UserControl)element).DataContext as IPlugin;
                        var hamburgerMenuGlyphItem = new HamburgerMenuGlyphItem();
                        hamburgerMenuGlyphItem.Glyph = plugin.Glyph;
                        hamburgerMenuGlyphItem.Label = plugin.Label;
                        hamburgerMenuGlyphItem.CommandParameter = plugin.CommandParameter;
                        hamburgerMenuGlyphItem.Tag = (UserControl)element;
                        hamburgerMenuGlyphItem.CommandParameter = element.GetType();

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