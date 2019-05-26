namespace ZoeProg.PlugIns.TaskManager.ViewModels
{
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;
    using ZoeProg.Common;

    public class ProcessViewModel : BindableBase
    {
        private readonly IPowerShellService powerShellService;
        private readonly IUnityContainer unityContainer;

        private string name;

        public ProcessViewModel()
        {
            // this.powerShellService = powerShellService;
        }

        public string Id { get; set; }

        public string Name
        {
            get { return this.name; }
            set { SetProperty(ref this.name, value); }
        }
    }
}