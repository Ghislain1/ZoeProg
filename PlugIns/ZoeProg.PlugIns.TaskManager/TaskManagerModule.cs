namespace ZoeProg.PlugIns.TaskManager
{
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.TaskManager.Views;

    public class TaskManagerModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly ILinkMetadataService linkMetadataService;

        public TaskManagerModule(ILinkMetadataService linkMetadataService, IUnityContainer container)
        {
            this.linkMetadataService = linkMetadataService;
            this.container = container;
        }

        public void Initialize()
        {
            ILinkMetadata linkMetaData = this.container.Resolve<LinkMetadata>();
            linkMetaData.ParentName = "Task Manager";
            linkMetaData.DisplayName = "Processes";
            linkMetaData.Source = $"/ZoeProg.PlugIns.TaskManager;component/Views/{nameof(TaskManagerView)}.xaml";

            this.linkMetadataService.Registry(linkMetaData);
        }
    }
}