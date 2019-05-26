namespace ZoeProg.PlugIns.Home
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Unity;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Home.Views;

    public class HomeModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly ILinkMetadataService linkMetadataService;

        public HomeModule(ILinkMetadataService linkMetadataService, IUnityContainer container)
        {
            this.linkMetadataService = linkMetadataService;
            this.container = container;
        }

        public void Initialize()
        {
            ILinkMetadata linkMetaData = new LinkMetadata();
            linkMetaData.DisplayName = "Home";
            linkMetaData.ParentName = "ZoeProg Center";
            linkMetaData.Source = $"/ZoeProg.PlugIns.Home;component/Views/{nameof(HomeView)}.xaml";

            this.linkMetadataService.Registry(linkMetaData);
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