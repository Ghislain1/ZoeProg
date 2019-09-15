namespace ZoeProg.Extensions
{
    using System.Windows.Controls;
    using MahApps.Metro.Controls;
    using Prism.Regions;
    using ZoeProg.Core;

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

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}