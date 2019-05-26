namespace ZoeProg.PlugIns.TaskManager
{
    using Prism.Ioc;
    using Prism.Modularity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;
    using Unity.Lifetime;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.TaskManager.ViewModels;
    using ZoeProg.PlugIns.TaskManager.Views;

    public class TaskManagerModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly ILinkMetadataService linkMetadataService;

        public TaskManagerModule(ILinkMetadataService linkMetadataService, IUnityContainer container)
        {
            this.linkMetadataService = linkMetadataService;
            this.container = container;

            this.container.RegisterType<ITaskManagerService, TaskManagerService>(new ContainerControlledLifetimeManager());
        }

        public void Initialize()
        {
            ILinkMetadata linkMetaData = this.container.Resolve<LinkMetadata>();
            linkMetaData.ParentName = "Task Manager";
            linkMetaData.DisplayName = "Processes";
            linkMetaData.Source = $"/ZoeProg.PlugIns.TaskManager;component/Views/{nameof(TaskManagerView)}.xaml";

            this.linkMetadataService.Registry(linkMetaData);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }
    }
}