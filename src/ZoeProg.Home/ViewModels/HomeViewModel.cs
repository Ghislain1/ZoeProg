namespace ZoeProg.Home.ViewModels
{
    using System;
    using System.Windows.Input;
    using Prism.Mvvm;
    using ZoeProg.Common;

    public class HomeViewModel : BindableBase, IPlugin
    {
        public HomeViewModel()
        {
            this.CommandParameter = this.GetType();
        }

        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICommand Command { get; set; }
        public Type CommandParameter { get; set; }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // http://modernicons.io/segoe-mdl2/cheatsheet/ For windows10 shoud use \u first
        public string Glyph { get; set; } = "\uE80F";

        public string Header => "Home";
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Kind { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Label { get; set; } = "Home";
        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Tag { get; set; } = "OpenHomeMaker";
        public string Title { get; set; } = "Home";
    }
}