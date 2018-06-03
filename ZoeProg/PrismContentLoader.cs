namespace ZoeProg
{
    using FirstFloor.ModernUI.Presentation;
    using FirstFloor.ModernUI.Windows;
    using Prism.Regions;
    using System;
    using System.Linq;
    using ZoeProg.Common;

    //public interface IContentService
    //{
    //    Dictionary<IContent, IContentMetadata> Contents { get; }

    //    void Add(IContent conten, IContentMetadata meta);
    //}

    //public class ContentService : IContentService
    //{
    //    private Dictionary<IContent, IContentMetadata> ontents;

    // public ContentService() { this.ontents = new Dictionary<IContent, IContentMetadata>(); }

    // public Dictionary<IContent, IContentMetadata> Contents => this.ontents;

    //    public void Add(IContent conten, IContentMetadata meta)
    //    {
    //        this.Contents.Add(conten, meta);
    //    }
    //}

    public class PrismContentLoader : DefaultContentLoader
    {
        private readonly LinkCollection contents;
        private readonly ILinkMetadataService moduleMetadataService;
        private IRegionManager regionManager;

        public PrismContentLoader(ILinkMetadataService scs)
        {
            // this.contents = scs.Contents;
            this.moduleMetadataService = scs;
            var doc = this.moduleMetadataService.LinkMetaDataList;
            this.contents = new LinkCollection(from p in doc
                                               let name = p.DisplayName
                                               let src = p.Source
                                               orderby name
                                               select new Link
                                               {
                                                   DisplayName = string.IsNullOrWhiteSpace(name) ? "[untitled]" : name,
                                                   Source = new Uri(src, UriKind.RelativeOrAbsolute)
                                               });
        }

        protected override object LoadContent(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Invalid uri: " + uri);
            }
            //TODO: case of setting
            if (uri.OriginalString.Contains("Setting") || uri.OriginalString.Contains("About"))
            {
                return base.LoadContent(uri);
            }
            // lookup the content based on the content uri in the content metadata
            var content = contents.FirstOrDefault(r => r.Source.ToString() == uri.OriginalString);

            if (content == null) throw new ArgumentException("Invalid uri: " + uri);

            return base.LoadContent(uri);
        }
    }
}