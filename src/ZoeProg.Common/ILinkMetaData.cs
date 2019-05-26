using System.Collections.Generic;

namespace ZoeProg.Common
{
    public interface ILinkMetadata
    {
        string DisplayName { get; set; }
        string ParentName { get; set; }
        string Source { get; set; }
    }

    public interface IModuleMetadata
    {
        List<ILinkMetadata> SourceLinks { get; set; }
        string Title { get; set; }
    }

    public class LinkMetadata : ILinkMetadata
    {
        public string DisplayName { get; set; }
        public string ParentName { get; set; }
        public string Source { get; set; }
    }
}