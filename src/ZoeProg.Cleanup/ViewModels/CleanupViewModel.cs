using System;
using System.Collections.Generic;

namespace ZoeProg.Cleanup.ViewModels
{
    using System.Windows.Input;
    using Prism.Mvvm;
    using ZoeProg.Common;

    public class CleanupViewModel : BindableBase, IPlugin
    {
        private bool isSelected = false;

        public CleanupViewModel()
        {
            this.CommandParameter = this.GetType();
            this.Todos = new List<string>();
            Todos.Add("User and Windows Temporary Directories");
            Todos.Add(" Windows Installer Cache");
            Todos.Add("Windows Logs Directory");
            Todos.Add("Prefetch Cache");
            Todos.Add("Crash Dump Directory");
            Todos.Add("Google Chrome Cache");
            Todos.Add("Steam Redistributable Packages");
        }

        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand Command { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Type CommandParameter { get; set; }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Glyph { get; set; } = "\uE90F";
        public string Header => throw new NotImplementedException();
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
        public List<string> Todos { get; }
    }
}