namespace ZoeProg.PlugIns.Cleanup
{
    using Prism.Ioc;
    using Prism.Modularity;
    using System.Collections.Generic;
    using Unity;
    using Unity.Lifetime;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Cleanup.Services;
    using ZoeProg.PlugIns.Cleanup.Views;

    public class CleanupModule : IModule
    {
        private readonly ILinkMetadataService moduleMetadataService;

        private IUnityContainer container;

        public CleanupModule(ILinkMetadataService moduleMetadataService, IUnityContainer container)
        {
            this.container = container;
            this.moduleMetadataService = moduleMetadataService;
            this.container.RegisterType<ICleanupService, CleanupService>(new ContainerControlledLifetimeManager());
        }

        public List<ILinkMetadata> SourceLinks { get; set; }
        public string Title { get; set; }

        public void Initialize()
        {
            ILinkMetadata linkMetaData = new LinkMetadata();
            linkMetaData.DisplayName = "Junks";
            linkMetaData.ParentName = "Clean explorer";

            linkMetaData.Source = $"/ZoeProg.PlugIns.Cleanup;component/Views/{nameof(CleanupView)}.xaml";
            this.moduleMetadataService.Registry(linkMetaData);

            //Cookies
            ILinkMetadata cookieLinkMetaData = new LinkMetadata();
            cookieLinkMetaData.DisplayName = "Cookies";
            cookieLinkMetaData.ParentName = "Clean explorer";

            cookieLinkMetaData.Source = $"/ZoeProg.PlugIns.Cleanup;component/Views/{nameof(CookieView)}.xaml";
            this.moduleMetadataService.Registry(cookieLinkMetaData);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new System.NotImplementedException();
        }
    }
}