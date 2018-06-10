namespace ZoeProg.PlugIns.TaskManager.ViewModels
{
    using Microsoft.Practices.Unity;
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZoeProg.Common;

    public class TaskManagerViewModel : BindableBase
    {
        private readonly IPowerShellService powerShellService;
        private readonly IUnityContainer unityContainer;

        private ObservableCollection<ProcessViewModel> processCollection;

        public TaskManagerViewModel(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;

            this.Load();
        }

        public ObservableCollection<ProcessViewModel> ProcessCollection
        {
            get => this.processCollection;
            set => this.SetProperty(ref this.processCollection, value);
        }

        private async void Load()
        {
            var cmd = "(Get-Process | Select-Object *)";
            var prs = await this.powerShellService.RunCommand(cmd);
            this.ProcessCollection = new ObservableCollection<ProcessViewModel>();
            foreach (var item in prs)
            {
                var vm = new ProcessViewModel()
                {
                    Id = item.Properties["Id"].Value.ToString(),
                    Name = item.Properties["Name"].Value.ToString()
                };
                this.ProcessCollection.Add(vm);
            }
        }
    }
}