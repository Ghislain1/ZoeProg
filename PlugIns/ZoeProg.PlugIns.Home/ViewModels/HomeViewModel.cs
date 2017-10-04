namespace ZoeProg.PlugIns.Home.ViewModels
{
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

    public class HomeViewModel : BindableBase
    {
        private readonly object lockObj;

        private readonly SemaphoreSlim syncLock;
        private CancellationTokenSource cancellationTokenSource;

        private bool isBusy;
        private CancellationTokenSource loadCancelToken;
        private string title;

        public HomeViewModel()
        {
            this.title = "Overview";

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

        public ICommand LoadCommand { get; private set; }

        public string Title
        {
            get
            {
                return this.title;
            }
        }

        private void Load()
        {
        }
    }
}