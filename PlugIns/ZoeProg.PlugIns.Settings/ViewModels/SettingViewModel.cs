namespace ZoeProg.PlugIns.Settings.ViewModels
{
    using Common;
    using Common.Data;
    using MaterialDesignThemes.Wpf;
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

    public class SettingViewModel : BindableBase, ITabItem
    {
        private readonly object lockObj;

        private readonly IProgressMonitor progressService;
        private readonly ISettingService settingService;

        private readonly SemaphoreSlim syncLock;
        private string additionalFolder;
        private string backgroudImage;
        private CancellationTokenSource cancellationTokenSource;
        private PackIconKind iconTitle;
        private ObservableCollection<UninstalledPackage> installedItems;
        private bool isBusy;
        private CancellationTokenSource loadCancelToken;
        private string title;

        public SettingViewModel(ISettingService settingService, IProgressMonitor progressService)
        {
            this.progressService = progressService;
            this.title = "Settings";
            this.backgroudImage = "";
            this.settingService = settingService;
            this.iconTitle = PackIconKind.Settings;
        }

        public string AdditionalFolder
        {
            get => this.additionalFolder;
            set
            {
                if (this.SetProperty<string>(ref this.additionalFolder, value))
                {
                }
            }
        }

        public string BackgroudImage
        {
            get
            {
                return this.backgroudImage;
            }
        }

        public PackIconKind IconTitle
        {
            get
            {
                return this.iconTitle;
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
    }
}