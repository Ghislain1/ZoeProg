using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ZoeProg.Common;

namespace ZoeProg.PlugIns.Home.ViewModels
{
    public class HomeViewModel: BindableBase
    {
        private readonly IPowerShellService powerShellService;
        //public string Header
        //{
        //    get { return _title; }= "Home"
        //    set { SetProperty(ref _title, value); }
        //}
        public HomeViewModel(IPowerShellService powerShellService)
        {
         this. powerShellService =   powerShellService;
            this.Test();
         }

        private async Task  Test()
        {
           await  Task.Delay(1000);
         var sd= await   this.ListInstalledPackages(false, CancellationToken.None);
        }
        ObservableCollection<string> _views;
        public ObservableCollection<string> Views
        {
            get { return _views; }
            set { SetProperty(ref _views, value); }
        }
        public string Header { get; } = " Home";


     
            public async Task<IEnumerable<string>> ListInstalledPackages(bool allVersions, CancellationToken token)
            {
                token.ThrowIfCancellationRequested();

                var regex = new Regex(@"^(?<name>\S+)\s+(?<version>\d+(\.\d+)+(-[a-zA-Z0-9]+)*)$");

                IEnumerable<string> psOutput = null;
                try
                {
                    string command = "chocolatey list -localonly";
                    if (allVersions)
                        command += " -allversions";

                    psOutput = await this.powerShellService.RunCommand(token, command);
                }
                catch (TaskCanceledException) { }

            this.Views = new ObservableCollection<string>(psOutput);
            var packages = new List<string>();

                return packages;
            }
        }

    
}