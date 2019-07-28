using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ZoeProg.Common;

namespace ZoeProg.Cleanup.ViewModels
{
    public class CleanupViewModel : IPlugin
    {
     public    CleanupViewModel()
        {
            this.Todos = new List<string>();
            Todos.Add("User and Windows Temporary Directories");
            Todos.Add(" Windows Installer Cache");
            Todos.Add("Windows Logs Directory");
            Todos.Add("Prefetch Cache");
            Todos.Add("Crash Dump Directory");
            Todos.Add("Google Chrome Cache");
            Todos.Add("Steam Redistributable Packages");

        }
        public List<string> Todos { get; }
        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Glyph { get; set; } = "\uE90F";
        public string Label { get; set; } = "Clean Up";
        public string Tag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand Command { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Kind { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Header => throw new NotImplementedException();
    }
}
