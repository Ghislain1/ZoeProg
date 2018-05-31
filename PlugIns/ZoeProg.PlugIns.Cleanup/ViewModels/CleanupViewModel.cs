namespace ZoeProg.PlugIns.Cleanup.ViewModels
{
    using Prism.Mvvm;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Cleanup.Services;

    public class CleanupViewModel : BindableBase
    {
        private ICleanupService cleanupService;

        private int counter;

        /// <summary>
        /// A list of all children contained inside this item
        /// </summary>
        private ObservableCollection<JunkItemViewModel> junkCollection;

        public CleanupViewModel(ICleanupService cleanupService)
        {
            this.cleanupService = cleanupService;

            this.Load();
        }

        public int Counter
        {
            get { return counter; }
            set { SetProperty(ref counter, value); }
        }

        public ObservableCollection<JunkItemViewModel> JunkCollection
        {
            get { return junkCollection; }
            set { SetProperty(ref junkCollection, value); }
        }

        private async void Load()
        {
            var xx = await this.cleanupService.GetListJunkFile();
            this.junkCollection = new ObservableCollection<JunkItemViewModel>(xx.Select(it => new JunkItemViewModel() { FullPath = it.Name }));
            this.counter = this.junkCollection.Count;
        }
    }

    public class JunkItemViewModel : BindableBase
    {
        /// <summary>
        /// The full path to the item
        /// </summary>
        private string fullPath;

        public string FullPath
        {
            get { return fullPath; }
            set { SetProperty(ref fullPath, value); }
        }
    }
}