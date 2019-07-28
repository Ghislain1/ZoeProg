

namespace ZoeProg.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Controls;
    using MahApps.Metro.Controls;
    using Prism.Regions;
    using Prism.Regions.Behaviors;
    using ZoeProg.Common;

    public class HamburgerMenuItemCollectionRegionAdapter : RegionAdapterBase<HamburgerMenuItemCollection>
    {
        public HamburgerMenuItemCollectionRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }
       
        protected override void Adapt(IRegion region, HamburgerMenuItemCollection regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (var element in e.NewItems)
                    {
                        var plugin = ((UserControl)element).DataContext  as IPlugin;
                        var hamburgerMenuGlyphItem = new HamburgerMenuGlyphItem();
                        hamburgerMenuGlyphItem.Glyph = plugin.Glyph; // @"C:\Users\Zoe\Desktop\___Z_Todelte\ZoeProg\src\ZoeProg\images\background.love.jpg";
                        hamburgerMenuGlyphItem.Label = plugin.Label;
                        hamburgerMenuGlyphItem.Tag = element;
                         
                        hamburgerMenuGlyphItem. CommandParameter = element.GetType();
                        regionTarget.Add(hamburgerMenuGlyphItem);
                      //  regionTarget.Freeze();
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
