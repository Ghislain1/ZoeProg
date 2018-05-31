﻿namespace ZoeProg.PlugIns.Cleanup
{
    using FirstFloor.ModernUI.Presentation;
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ZoeProg.Common;
    using ZoeProg.PlugIns.Cleanup.Views;

    public class CleanupModule : IModule
    {
        private readonly ILinkMetadataService moduleMetadataService;

        private IUnityContainer container;

        public CleanupModule(ILinkMetadataService moduleMetadataService, IUnityContainer container)
        {
            this.container = container;
            this.moduleMetadataService = moduleMetadataService;
        }

        public List<ILinkMetadata> SourceLinks { get; set; }
        public string Title { get; set; }

        public void Initialize()
        {
            ILinkMetadata linkMetaData = new LinkMetaData();
            linkMetaData.DisplayName = "Junks";
            linkMetaData.ParentName = "Clean explorer";

            linkMetaData.Source = $"/ZoeProg.PlugIns.Cleanup;component/Views/{nameof(CleanupView)}.xaml";
            this.moduleMetadataService.Registry(linkMetaData);
        }
    }

    internal class LinkMetaData : ILinkMetadata
    {
        public string DisplayName { get; set; }
        public string ParentName { get; set; }
        public string Source { get; set; }
    }
}