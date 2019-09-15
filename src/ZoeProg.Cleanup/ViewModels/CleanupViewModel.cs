using System;

namespace ZoeProg.Cleanup.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Prism.Commands;
    using Prism.Mvvm;
    using ZoeProg.Cleanup.Services;
    using ZoeProg.Core;

    /// <summary>
    /// TODO:
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase"/>
    /// <seealso cref="ZoeProg.Common.IPlugin"/>
    public class CleanupViewModel : BindableBase, IPlugin
    {
        private readonly ICleanupService cleanupService;
        private bool canDelete;

        private string deleteCommandDisplayName = "Delete";
        private bool isSelected = false;
        private ObservableCollection<string> todos = new ObservableCollection<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanupViewModel"/> class.
        /// </summary>
        /// <param name="cleanupService"></param>
        public CleanupViewModel(ICleanupService cleanupService)
        {
            this.cleanupService = cleanupService ?? throw new ArgumentNullException(nameof(cleanupService));

            this.CommandParameter = this.GetType();

            this.DeleteCommand = new DelegateCommand(async () =>
                        {
                            this.IsBusy = true;
                            await this.cleanupService.RemoveFileAsnyc(this.Todos.ToList());
                            this.Todos.Clear();
                            this.IsBusy = false;
                        });

            this.ScanCommand = new DelegateCommand(async () =>
          {
              var result = new List<string>();
              this.IsBusy = true;
              await this.cleanupService.LoadTempFilesAsync(path => result.Add(path));
              this.Todos.Clear();
              foreach (var item in result)
              {
                  this.Todos.Add(item);
              }

              this.IsBusy = false;
          });

            //Todos.Add("User and Windows Temporary Directories");
            //Todos.Add(" Windows Installer Cache");
            //Todos.Add("Windows Logs Directory");
            //Todos.Add("Prefetch Cache");
            //Todos.Add("Crash Dump Directory");
            //Todos.Add("Google Chrome Cache");
            //Todos.Add("Steam Redistributable Packages");
        }

        /// <inheritdoc/>
        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICommand Command { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Type CommandParameter { get; set; }

        public DelegateCommand DeleteCommand { get; private set; }

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
        public string Glyph { get; set; } = "\uf368";
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
                if (this.SetProperty<bool>(ref this.canDelete, value))
                {
                    this.DeleteCommand.RaiseCanExecuteChanged();
                }
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
        public DelegateCommand ScanCommand { get; private set; }
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
                if (this.SetProperty<ObservableCollection<string>>(ref this.todos, value))
                {
                    this.DeleteCommandDisplayName = $" Delete({ (value == null ? 0 : value.Count)})";
                }
            }
        }
    }
}