using System;

namespace ZoeProg.Cleanup.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Prism.Commands;
    using Prism.Mvvm;
    using ZoeProg.Cleanup.Services;
    using ZoeProg.Common;

    public class CleanupViewModel : BindableBase, IPlugin
    {
        private readonly ICleanupService cleanupService;
        private bool canDelete;
        private DelegateCommand deleteCommand;
        private string deleteCommandDisplayName = "Delete";
        private bool isSelected = false;
        private ObservableCollection<string> todos;

        public CleanupViewModel(ICleanupService cleanupService)
        {
            this.cleanupService = cleanupService ?? throw new ArgumentNullException(nameof(cleanupService));

            LoadForDemo().GetAwaiter();

            this.deleteCommand = new DelegateCommand(
                async () =>
             {
                 this.IsBusy = true;
                 await this.cleanupService.CleanTempFilesAsync(() =>
                 {
                     this.IsBusy = false;
                 });
             }, () => !this.IsBusy);

            this.CommandParameter = this.GetType();

            //Todos.Add("User and Windows Temporary Directories");
            //Todos.Add(" Windows Installer Cache");
            //Todos.Add("Windows Logs Directory");
            //Todos.Add("Prefetch Cache");
            //Todos.Add("Crash Dump Directory");
            //Todos.Add("Google Chrome Cache");
            //Todos.Add("Steam Redistributable Packages");
        }

        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICommand Command { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Type CommandParameter { get; set; }

        public DelegateCommand DeleteCommand
        {
            get { return this.deleteCommand; }
        }

        public string DeleteCommandDisplayName
        {
            get
            {
                return this.deleteCommandDisplayName;
            }
            set
            {
                this.SetProperty<string>(ref this.deleteCommandDisplayName, value);
            }
        }

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Glyph { get; set; } = "\uE90F";

        public string Header => throw new NotImplementedException();

        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsBusy

        {
            get
            {
                return this.canDelete;
            }
            set
            {
                this.SetProperty<bool>(ref this.canDelete, value);
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.SetProperty<bool>(ref this.isSelected, value);
            }
        }

        public string Kind { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Label { get; set; } = "Clean Up";

        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Tag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ObservableCollection<string> Todos
        {
            get
            {
                return this.todos;
            }
            set
            {
                this.SetProperty<ObservableCollection<string>>(ref this.todos, value);
            }
        }

        private async Task LoadForDemo()
        {
            var collection = await this.cleanupService.GetTempFilesAsync();
            this.Todos = new ObservableCollection<string>(collection);
            this.DeleteCommandDisplayName = $" Delete({ this.Todos.Count})";
            this.IsBusy = false;
            this.DeleteCommand.RaiseCanExecuteChanged();
        }
    }
}