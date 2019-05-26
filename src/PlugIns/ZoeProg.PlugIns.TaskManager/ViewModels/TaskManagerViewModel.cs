namespace ZoeProg.PlugIns.TaskManager.ViewModels
{
    using Newtonsoft.Json;
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Unity;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.TaskManager.Models;

    public interface ITaskManagerService
    {
        Task<bool> DeleteJunkFiles();

        Task<List<ProcessModel>> GetProcessList(CancellationToken token);
    }

    public class TaskManagerService : ITaskManagerService
    {
        private readonly IPowerShellService powerShellService;

        public TaskManagerService(IPowerShellService powerShellService)
        {
            this.powerShellService = powerShellService;
        }

        public Task<bool> DeleteJunkFiles()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProcessModel>> GetProcessList(CancellationToken token)
        {
            List<ProcessModel> result = new List<ProcessModel>();
            var cmd = "Get-Process | Select-Object *";
            var prs = await this.powerShellService.RunCommand(cmd);

            foreach (var item in prs)
            {
                var serialized = JsonConvert.SerializeObject(item.Properties.ToDictionary(k => k.Name, v => v.Value));
                var deseialized = JsonConvert.DeserializeObject<ProcessModel>(serialized);
                result.Add(deseialized);
            }

            return result;
        }
    }

    public class TaskManagerViewModel : BindableBase
    {
        private readonly IPowerShellService powerShellService;
        private readonly ITaskManagerService taskManagerService;
        private readonly IUnityContainer unityContainer;

        private ObservableCollection<ProcessViewModel> processCollection;

        public TaskManagerViewModel(ITaskManagerService taskManagerService)
        {
            this.taskManagerService = taskManagerService;

            this.Load();
        }

        public ObservableCollection<ProcessViewModel> ProcessCollection
        {
            get => this.processCollection;
            set => this.SetProperty(ref this.processCollection, value);
        }

        private async void Load()
        {
            var cmd = "Get-Process | Select-Object *";
            var prs = await this.taskManagerService.GetProcessList(CancellationToken.None);
            this.ProcessCollection = new ObservableCollection<ProcessViewModel>();
            foreach (var item in prs)
            {
                //var vm = new ProcessViewModel()
                //{
                //    Id = item.Properties["Id"].Value.ToString(),
                //    Name = item.Properties["Name"].Value.ToString()
                //};
                //this.ProcessCollection.Add(vm);
            }
        }
    }
}