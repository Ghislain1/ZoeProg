using System.Collections.Generic;

namespace ZoeProg.Common
{
    public interface IContentMetadata
    {
        List<IContentMetadata> Children { get; set; }
        string Name { get; set; }
        string Source { get; set; }
    }

    public interface IContentMetadataProvider
    {
        List<IContentMetadata> LinkGroups { get; set; }
    }
}