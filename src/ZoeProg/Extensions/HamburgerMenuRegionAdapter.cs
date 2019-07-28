

namespace ZoeProg.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Controls;
    using MahApps.Metro.Controls;
    using Prism.Regions;
    using ZoeProg.Common;

    [Obsolete("Use HamburgerMenuItemCollection instead : Ghislain why? because HM store his items into HamburgerMenuItemCollection")]
    public class HamburgerMenuRegionAdapter : RegionAdapterBase<HamburgerMenu>
    {
        public HamburgerMenuRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }
        protected override void Adapt(IRegion region, HamburgerMenu regionTarget)
        {
            region.ActiveViews.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        foreach (var t in e.NewItems)
                        {
                            var tb = new HamburgerMenuItem();
                            var iv = ((UserControl)e.NewItems[0]).DataContext as IPlugin;
                            tb.Label = iv.Header;
                          //  tb.DataContext = iv;
                            // tb.Content = ((UserControl)e.NewItems[0]);
                            regionTarget.Items.Insert(regionTarget.Items.Count, tb);
                            regionTarget.SelectedIndex = regionTarget.Items.Count - 1;
                        }
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (var t in e.OldItems)
                        {
                            for (var i = 0; i < regionTarget.Items.Count; i++)
                            {
                                var tab = (HamburgerMenuItem)regionTarget.Items[i];
                                if (tab.Label == e.OldItems[0])
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

        protected override IRegion CreateRegion() => new AllActiveRegion();

    }
}