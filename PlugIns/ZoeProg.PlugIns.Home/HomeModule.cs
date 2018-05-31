namespace ZoeProg.PlugIns.Home
{
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;

    using ZoeProg.Common;
    using ZoeProg.Common.Data;
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
            ILinkMetadata linkMetaData = new LinkMetaData();
            linkMetaData.DisplayName = "Home";
            linkMetaData.ParentName = "ZoeProg Center";
            linkMetaData.Source = $"/ZoeProg.PlugIns.Home;component/Views/{nameof(HomeView)}.xaml";

            this.linkMetadataService.Registry(linkMetaData);
        }
    }

    internal class LinkMetaData : ILinkMetadata
    {
        public string DisplayName { get; set; }
        public string ParentName { get; set; }
        public string Source { get; set; }
    }
}