namespace ZoeProg.Extensions
{
    using System.Windows.Controls;
    using Prism.Regions;
    using ZoeProg.Core;

    public sealed class ListViewRegionAdapter : RegionAdapterBase<ListView>
    {
        public ListViewRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        { }

        protected override void Adapt(IRegion region, ListView regionTarget)
        {
            region.ActiveViews.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        foreach (var t in e.NewItems)
                        {
                            var tb = new ListViewItem();
                            var iv = ((UserControl)e.NewItems[0]).DataContext as IPlugin;
                            tb.DataContext = iv;
                            tb.Content = e.NewItems[0];
                            regionTarget.Items.Insert(regionTarget.Items.Count, tb);
                            regionTarget.SelectedIndex = regionTarget.Items.Count - 1;
                        }
                        break;

                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        foreach (var t in e.OldItems)
                        {
                            for (var i = 0; i < regionTarget.Items.Count; i++)
                            {
                                var tab = (ListViewItem)regionTarget.Items[i];
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

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}