﻿namespace ZoeProg.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    public class ShellViewModel : BindableBase, IShellViewModel
    {
        private readonly IRegionManager _regionManager;

        private string _title = "ZoeProg -  Tool";

        private ObservableCollection<object> _views = new ObservableCollection<object>();

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.Regions.CollectionChanged += Regions_CollectionChanged;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ObservableCollection<object> Views
        {
            get { return _views; }
            set { SetProperty(ref _views, value); }
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }

        private void Regions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var region = (IRegion)e.NewItems[0];
                region.Views.CollectionChanged += Views_CollectionChanged;
            }
        }

        private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Views.Add(e.NewItems[0].GetType().Name);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Views.Remove(e.OldItems[0].GetType().Name);
            }
        }
    }
}