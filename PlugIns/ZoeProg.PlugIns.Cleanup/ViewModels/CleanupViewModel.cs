namespace ZoeProg.PlugIns.Cleanup.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;
    using System.Collections.ObjectModel;
    using System.Linq;
    using ZoeProg.PlugIns.Cleanup.Services;

    public class CleanupViewModel : BindableBase
    {
        private ICleanupService cleanupService;

        private int counter;

        private bool isBusy;

        /// <summary>
        /// A list of all children contained inside this item
        /// </summary>
        private ObservableCollection<JunkItemViewModel> junkCollection;

        public CleanupViewModel(ICleanupService cleanupService)
        {
            this.cleanupService = cleanupService;
            this.JunkCollection = new ObservableCollection<JunkItemViewModel>();

            this.ScanCommand = new DelegateCommand(this.ExecuteScan, this.CanScan).ObservesProperty(() => this.IsBusy);
            this.DeleteCommand = new DelegateCommand(this.ExecuteDelete, this.CanDelete).ObservesProperty(() => this.IsBusy);
        }

        public int Counter
        {
            get { return counter; }
            set { SetProperty(ref counter, value); }
        }

        public DelegateCommand DeleteCommand { get; private set; }

        public bool IsBusy
        {
            get { return this.isBusy; }
            set { SetProperty(ref this.isBusy, value); }
        }

        public ObservableCollection<JunkItemViewModel> JunkCollection
        {
            get { return junkCollection; }
            set { SetProperty(ref junkCollection, value); }
        }

        public DelegateCommand ScanCommand { get; private set; }

        private bool CanDelete()
        {
            if (this.JunkCollection == null)
            {
                return false;
            }
            return this.JunkCollection.Any();
        }

        private bool CanScan()
        {
            return !this.IsBusy;
        }

        private async void ExecuteDelete()
        {
            this.IsBusy = true;
            var result = await this.cleanupService.DeleteJunkFiles();

            if (result)
            {
                //Check again
                this.JunkCollection = null;
            }

            this.IsBusy = false;
        }

        private void ExecuteScan()
        {
            this.Load();
        }

        private async void Load()
        {
            this.IsBusy = true;
            var junks = await this.cleanupService.GetListJunkFile();
            if (junks == null)
            {
                this.IsBusy = false;
                return;
            }
            this.JunkCollection = new ObservableCollection<JunkItemViewModel>(junks.Select(it => new JunkItemViewModel() { FullPath = it.Name }));
            this.Counter = this.junkCollection.Count;
            this.IsBusy = false;
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