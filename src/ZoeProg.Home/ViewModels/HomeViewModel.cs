﻿

namespace ZoeProg.Home.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Prism.Mvvm;
    using ZoeProg.Common;
    public class HomeViewModel : BindableBase, IPlugin
    {
        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSelected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get; set; } = "Home";
        public string Kind { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Header => "Home";
    }
}
