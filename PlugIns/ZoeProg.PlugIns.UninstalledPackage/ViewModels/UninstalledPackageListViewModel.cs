namespace ZoeProg.PlugIns.UninstalledPackage.ViewModels
{
    using Common;
    using Common.Data;
    using MaterialDesignThemes.Wpf;
    using Microsoft.Practices.Unity;
    using Prism.Commands;
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using ZoeProg.PlugIns.UninstalledPackage.Services;

    public class UninstalledPackageListViewModel : BindableBase, ITabItem
    {
        private readonly IUnityContainer container;
        private readonly object lockObj;

        private readonly IProgressMonitor progressMonitor;

        private readonly SemaphoreSlim syncLock;
        private readonly IUninstalledPackageProvider uninstalledPackageProvider;
        private CancellationTokenSource cancellationTokenSource;
        private PackIconKind iconTitle;
        private bool isBusy;
        private ObservableCollection<UninstalledPackage> items;
        private CancellationTokenSource loadCancelToken;
        private string title;

        public UninstalledPackageListViewModel(IProgressMonitor progressMonitor, IUninstalledPackageProvider uninstalledPackageProvider, IUnityContainer container)
        {
            this.uninstalledPackageProvider = uninstalledPackageProvider;
            this.progressMonitor = progressMonitor;
            this.container = container;
            this.title = "Uninstalled Packages";
            this.iconTitle = PackIconKind.Star;
            this.items = new ObservableCollection<UninstalledPackage>();

            this.lockObj = new object();
            this.syncLock = new SemaphoreSlim(1);
            this.cancellationTokenSource = null;

            this.LoadCommand = new DelegateCommand(() =>
            {
                this.Load();
            });
        }

        public string BackgroudImage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PackIconKind IconTitle
        {
            get
            {
                return this.iconTitle;
            }
        }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            {
                this.isBusy = value;
            }
        }

        public ObservableCollection<UninstalledPackage> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }

        public ICommand LoadCommand { get; private set; }

        public string Title
        {
            get
            {
                return this.title;
            }
        }

        private async void Load()
        {
            try
            {
                this.IsBusy = true;
                this.progressMonitor.BeginTask("Loading...", 100);
                this.Items.Clear();
                var collection = await this.uninstalledPackageProvider.GetMSIFilesListAsync();

                foreach (var item in collection)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this.IsBusy = false;
                this.progressMonitor.Done();
            }
        }
    }
}