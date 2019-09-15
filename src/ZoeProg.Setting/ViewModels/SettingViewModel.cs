namespace ZoeProg.Setting.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Prism.Commands;
    using Prism.Mvvm;
    using ZoeProg.Core;

    public class SettingViewModel : BindableBase, IPlugin
    {
        private bool isBusy;
        private ObservableCollection<string> todos = new ObservableCollection<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingViewModel"/> class.
        /// </summary>
        public SettingViewModel()
        {
            this.CommandParameter = this.GetType();

            this.ApplyCommand = new DelegateCommand(async () =>
            {
                var result = new List<string>();

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

        public DelegateCommand ApplyCommand { get; private set; }

        /// <inheritdoc/>
        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICommand Command { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        ICommand IPlugin.Command { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Type CommandParameter { get; set; }

        public DelegateCommand DeleteCommand { get; private set; }

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Glyph { get; set; } = "\uE90F";
        public string Header => throw new NotImplementedException();
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsBusy

        {
            get
            {
                return this.isBusy;
            }
            set
            {
                if (this.SetProperty<bool>(ref this.isBusy, value))
                {
                }
            }
        }

        public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Kind { get; set; }
        public string Label { get; set; } = "Clean Up";
        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Tag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Title { get; set; } = "TDISSO";

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
                }
            }
        }
    }
}