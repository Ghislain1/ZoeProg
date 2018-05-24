namespace ZoeProg.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using ZoeProg.Common;

    public interface IShellViewModel
    {
        Guid DialogHostIdentifier { get; }
        bool IsBusy { get; }
        bool IsLeftDrawerOpen { get; set; }
        ICommand OpenManagementCommand { get; }
        IPlugIn SelectedPlugIn { get; set; }
        ICommand ShutDownCommand { get; }
        ICommand StartupCommand { get; }
        // ISnackbarMessageQueue SnackbarMessageQueue { get; }
    }
}