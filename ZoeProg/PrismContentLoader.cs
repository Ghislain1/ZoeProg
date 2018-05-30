

namespace ZoeProg
{
    using FirstFloor.ModernUI.Presentation;
    using FirstFloor.ModernUI.Windows;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class PrismContentLoader :DefaultContentLoader
    {
        IRegionManager regionManager;
        private readonly Dictionary<IContent, IContentMetadata> contents;
       
        public PrismContentLoader( IContentService scs)
        {
            this.contents =scs. Contents;
        }

        protected override object LoadContent(Uri uri)
        {
            // lookup the content based on the content uri in the content metadata
            var content = contents.Where(r => r.Key.ToString() == uri.OriginalString)
                .Select(r => r.Value)
                .FirstOrDefault();
            if (content == null) throw new ArgumentException("Invalid uri: " + uri);
            return content;
        }
    }

    public interface IContentMetadata
    {
        string ContentUri { get; }
          
    }

    public interface IContentService
    {
        Dictionary<IContent, IContentMetadata> Contents { get; }
    }

    
}