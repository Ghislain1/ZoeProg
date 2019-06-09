

namespace ZoeProg.PlugIns.Home.ViewModels
{
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using ZoeProg.Common;
    public class HomeViewModel : BindableBase, IPlugin
    {
        private readonly IPowerShellService powerShellService;
        
        public HomeViewModel(IPowerShellService powerShellService)
        {
         this. powerShellService =   powerShellService;
            this.Test().GetAwaiter();
         }

        private async Task  Test()
        {
           await  Task.Delay(1000);
         var sd= await   this.ListInstalledPackages(false, CancellationToken.None);
        }
        ObservableCollection<object> _views;
        public ObservableCollection<object> Views
        {
            get { return _views; }
            set { SetProperty(ref _views, value); }
        }
        public string Header { get; } = " Home";
        public string Code { get   ; set  ; }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsSelected { get; set; } = true;
        public string NavigatePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get; set; } = "Home";
        public string Kind { get; set; } = "Home";

        public async Task<IEnumerable<string>> ListInstalledPackages(bool allVersions, CancellationToken token)
            {
                token.ThrowIfCancellationRequested();

                var regex = new Regex(@"^(?<name>\S+)\s+(?<version>\d+(\.\d+)+(-[a-zA-Z0-9]+)*)$");

                IEnumerable<object> psOutput = null;
                try
                {
                    string command = "chocolatey list -localonly";
                    if (allVersions)
                        command += " -allversions";

                    psOutput = await this.powerShellService.RunCommand(token, command);
                }
                catch (TaskCanceledException) { }

            this.Views = new ObservableCollection<object>(psOutput);
            var packages = new List<string>();

                return packages;
            }
        }

    
}