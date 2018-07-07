namespace ZoeProg.PlugIns.Cleanup.ViewModels
{
    using Microsoft.Practices.Unity;
    using Prism.Commands;
    using Prism.Mvvm;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Cleanup.Models;
    using ZoeProg.PlugIns.Cleanup.Services;

    public class CleanupViewModel : BindableBase
    {
        private readonly IUnityContainer unityContainer;
        private IApplicationCommands applicationCommands;
        private ICleanupService cleanupService;

        private int counter;

        private bool isBusy;

        /// <summary>
        /// A list of all children contained inside this item
        /// </summary>
        private ObservableCollection<JunkItemViewModel> junkCollection;

        public CleanupViewModel(IUnityContainer unityContainer, IApplicationCommands applicationCommands, ICleanupService cleanupService)
        {
            this.applicationCommands = applicationCommands;
            this.unityContainer = unityContainer;
            this.cleanupService = cleanupService;
            this.JunkCollection = new ObservableCollection<JunkItemViewModel>();

            this.SaveCommand = new DelegateCommand(this.Save);
            this.applicationCommands.SaveCommand.RegisterCommand(this.SaveCommand);
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

        public ObservableCollection<JunkItemViewModel> JunkCollection { get => this.junkCollection; set => this.SetProperty(ref this.junkCollection, value); }

        public DelegateCommand SaveCommand { get; private set; }
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

            var items = junks.Select(it =>
            {
                var vm = this.unityContainer.Resolve<JunkItemViewModel>();
                //TODO: Find better away to create a VM with parameter using PRISM.
                vm.Init(it);
                return vm;
            });

            this.JunkCollection = new ObservableCollection<JunkItemViewModel>(items);
            this.Counter = this.JunkCollection.Count;
            this.IsBusy = false;
        }

        private void Save()
        {
            throw new NotImplementedException();
        }
    }
}