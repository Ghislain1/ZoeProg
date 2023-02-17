// <copyright company="Ghislain One Inc.">
//  Copyright (c) GhislainOne
//  This computer program includes confidential, proprietary
//  information and is a trade secret of GhislainOne. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of Ghis. All Rights Reserved.
// </copyright>

namespace ZoeProg.PlugIns.ApplicationList.ViewModels
{
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using ZoeProg.Core;

    public class ApplicationListViewModel : BindableBase, IPlugin
    {
        public ICommand? Command { get; set; }
        public Type? CommandParameter { get; set; }
        public string? Description { get; set; }
       
        public bool IsSelected { get; set; }
        public string Kind { get; set; } = "Adjust";

        public string? NavigatePath { get; set; }
        public string? Tag { get; set; }


        public string Header { get; set; } = "Softwares";
    }
}